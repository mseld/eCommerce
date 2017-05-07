using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IM.Web.Domain;
using IM.Web.Areas.Admin.Models;

namespace IM.Web.Services
{
    public interface IMapService
    {
        IQueryable<Location> FindAll();
        Location Find(int id);
        Location AddOrUpdate(LocationViewModel model);
        void Delete(int id);
    }
}