using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using IM.Web.Areas.Admin.Models;
using IM.Web.DAL;
using IM.Web.Domain;

namespace IM.Web.Services
{
    public class RegionService : IRegionService
    {
        private readonly DataContext db;
                public RegionService(DataContext db)
        {
            this.db = db;
        }

        public IQueryable<Region> FindAll()
        {
            return db.Regions;
        }

        public Region Find(int id)
        {
            return db.Regions.Find(id);
        }

        public IQueryable<Region> FindByCountryCode(string countryCode)
        {
            return db.Regions.Where(r=> r.CountryCode == countryCode);
        }

        public Region AddOrUpdate(RegionViewModel model)
        {
            Region region;
            if (model.Id == 0)
            {
                region = Mapper.Map<Region>(model);
                db.Regions.Add(region);
            }
            else
            {
                region = Find(model.Id);
                Mapper.Map(model, region);
            }

            db.SaveChanges();
            return region;

        }
        public void Delete(int id)
        {
            var region = Find(id);
            db.Regions.Remove(region);
            db.SaveChanges();
        }
    }
}