using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using IM.Web.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace IM.Web.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            #region Delete old photos

            foreach (var file in Directory.GetFiles(HostingEnvironment.MapPath("~/Storage/"), "*.*"))
            {
                if (file.Contains("web.config")) continue;
                File.Delete(file);
            }

            #endregion

            #region Import countries and states

            string countryJson =
                File.ReadAllText(HostingEnvironment.MapPath("~/Content/DataInitializer/Regional/Countries.json"));
            dynamic json = JsonConvert.DeserializeObject(countryJson);

            foreach (dynamic item in json)
            {
                var country = new Country {Code = item.code, Name = item.name};
                country.IsActive = country.Code == "US" || country.Code == "BG";
                context.Countries.Add(country);

                if (item.filename != null)
                {
                    dynamic regionJson =
                        File.ReadAllText(
                            HostingEnvironment.MapPath("~/Content/DataInitializer/Regional/" + item.filename + ".json"));
                    dynamic json2 = JsonConvert.DeserializeObject(regionJson);
                    foreach (dynamic item2 in json2)
                    {
                        var region = new Region {Country = country, Code = item2.code, Name = item2.name};
                        context.Regions.Add(region);
                    }
                }
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception err)
            {
                throw err;
            }

            #endregion

            #region Create users

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create admin role
            roleManager.Create(new IdentityRole(User.ADMIN_ROLE));
            roleManager.Create(new IdentityRole(User.CUSTOMER_ROLE));

            // Create admin user
            var admin = new User
                        {
                            FirstName = "Admin",
                            LastName = "Admin",
                            Company = "Admin Inc",
                            PhoneNumber = "1-800-ADMIN",
                            UserName = "admin@test.com",
                            Email = "admin@test.com",
                        };
            IdentityResult result = userManager.Create(admin, "123pass");
            if (!result.Succeeded)
                throw new Exception(string.Join("\n", result.Errors));
            userManager.AddToRole(admin.Id, User.ADMIN_ROLE);

            // Create regular user
            var user = new User
                       {
                           FirstName = "Tester",
                           LastName = "Tester",
                           Company = "Test Ltd",
                           PhoneNumber = "1-800-USER",
                           UserName = "user@test.com",
                           Email = "user@test.com"
                       };
            userManager.Create(user, "123pass");
            userManager.AddToRole(user.Id, User.CUSTOMER_ROLE);

            #endregion

            #region Create EmailTemplates

            var templateTypes = new List<EmailTemplate>
                                {
                                    new EmailTemplate
                                    {
                                        Subject = "Order Successful",
                                        Body = "Your order has been received successfully",
                                        Type = EmailTemplateType.OrderCompleted
                                    }
                                };

            templateTypes.ForEach(t => context.EmailTemplates.AddOrUpdate(t));
            context.SaveChanges();

            #endregion

            context.SaveChanges();
            
            // Temporary until better solution is added to EF Code First
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Orders', RESEED, 101)");

            base.Seed(context);
        }
    }
}