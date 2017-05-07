using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IM.Web.Areas.Admin.Models;
using IM.Web.Domain;

namespace IM.Web.Services
{
    public interface IRegionService
    {
        Region Find(int id);
        IQueryable<Region> FindAll();
        IQueryable<Region> FindByCountryCode(string countryCode);
        Region AddOrUpdate(RegionViewModel region);
        void Delete(int id);
    }
}