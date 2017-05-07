using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IM.Web.Areas.Admin.Models;
using IM.Web.Domain;

namespace IM.Web.Services
{
    public interface ICountryService
    {
        IQueryable<Country> FindAll();
        Country Find(string code);
        Country AddOrUpdate(CountryViewModel model);
        void Delete(string code);
        void SetActive(string code, bool active);
    }
}