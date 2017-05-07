using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using IM.Web.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IM.Web.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("defaultDB")
        {
        }

        public DataContext(string connectionString) : base(connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Setting> Settings { get; set; }
        public IDbSet<User> Users { get; set; }        
        public IDbSet<Upload> Uploads { get; set; }
        public IDbSet<ContentPage> ContentPages { get; set; }
        public IDbSet<EmailTemplate> EmailTemplates { get; set; }
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Translation> Translations { get; set; }
        public IDbSet<WorkProcess> WorkProcesses { get; set; }
        public IDbSet<TemplateSetting> TemplateSettings { get; set; }
        public IDbSet<Visitor> Visitors { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Distributor> Distributors { get; set; }
        public IDbSet<ContactUs> ContactUs { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Answer> Answers { get; set; }
        public IDbSet<Questionnaire> Questionnaires { get; set; }
        public IDbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public IDbSet<CustomerInformation> CustomerInformations { get; set; }
        public IDbSet<BusinessList> BusinessLists { get; set; }
        public IDbSet<Menu> Menu { get; set; }
        
        public static DataContext Current
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["DataContext"] != null)
                    return HttpContext.Current.Items["DataContext"] as DataContext;

                DataContext entities = Create();
                if (HttpContext.Current != null)
                    HttpContext.Current.Items["DataContext"] = entities;
                return entities;
            }
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {r.RoleId, r.UserId});

            modelBuilder.Entity<Menu>()
               .HasMany(x => x.Items)
                .WithOptional()
                .HasForeignKey(g => g.ParentId);
        }

        public static void DisposeCurrent()
        {
            if (HttpContext.Current.Items["DataContext"] != null)
            {
                var entities = (DataContext) HttpContext.Current.Items["DataContext"];
                entities.Dispose();
            }
        }
    }
}