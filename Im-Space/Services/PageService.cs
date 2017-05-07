using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using AutoMapper;
using IM.Web.DAL;
using IM.Web.Domain;
using IM.Web.Models;
using IM.Web.Helpers;
using LinqKit;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace IM.Web.Services
{
    public class PageService : IPage
    {
        private readonly DataContext db;

        public PageService(DataContext db)
        {
            this.db = db;
        }

        public Comment AddComment(CommentViewModel model)
        {
            Comment comment;
            if (model.Id == 0)
            {
                comment = Mapper.Map<Comment>(model);
                db.Comments.Add(comment);
            }
            else
            {
                comment = db.Comments.Find(model.Id);
                Mapper.Map(model, comment);
            }
            db.SaveChanges();
            return comment;
        }

        public ContactUs AddContact(ContactUsViewModel model)
        {
            ContactUs contact;
            if (model.Id == 0)
            {
                contact = Mapper.Map<ContactUs>(model);
                db.ContactUs.Add(contact);
            }
            else
            {
                contact = db.ContactUs.Find(model.Id);
                Mapper.Map(model, contact);
            }
            db.SaveChanges();
            return contact;
        }

        public Distributor AddDistributor(DistributorViewModel model)
        {
            Distributor distributor;
            if (model.Id == 0)
            {
                distributor = Mapper.Map<Distributor>(model);
                db.Distributors.Add(distributor);
            }
            else
            {
                distributor = db.Distributors.Find(model.Id);
                Mapper.Map(model, distributor);
            }
            db.SaveChanges();
            return distributor;
        }
    }
}