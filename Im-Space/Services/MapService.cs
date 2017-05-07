using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using AutoMapper;
using IM.Web.Areas.Admin.Models;
using IM.Web.DAL;
using IM.Web.Domain;
using IM.Web.Helpers;
using LinqKit;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace IM.Web.Services
{
    public class MapService : IMapService
    {
        private readonly DataContext db;

        public MapService(DataContext db)
        {
            this.db = db;
        }

        public IQueryable<Location> FindAll()
        {
            return db.Locations;
        }

        public Location Find(int id)
        {
            return db.Locations.Find(id);
        }

        public Location AddOrUpdate(LocationViewModel model)
        {
            Location location;
            if (model.Id == 0)
            {
                location = Mapper.Map<Location>(model);
                db.Locations.Add(location);
            }
            else
            {
                location = Find(model.Id);
                Mapper.Map(model, location);
            }
            db.SaveChanges();
            return location;
        }

        public void Delete(int id)
        {           
            var location = Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
        }
    }
}