using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using IM.Web.Areas.Admin.Models;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Helpers;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class ReportController : BaseController
    {
        public const int CACHE_DURATION = 30 * 60 * 60; // 30 minutes

        public ReportController(DataContext db)
            : base(db)
        {
        }

        [OutputCache(Duration = CACHE_DURATION, Location = OutputCacheLocation.Server, VaryByCustom = "lang")]
        [AccessAuthorize(OperatorRoles.REPORTS)]
        public async Task<PartialViewResult> SalesBox()
        {
            var model = new SalesBoxViewModel();
            model.Amount = 12580.50m;
            model.Difference = 98;
            return PartialView("_SalesBox", model);
        }

        [OutputCache(Duration = CACHE_DURATION, Location = OutputCacheLocation.Server, VaryByCustom = "lang")]
        [AccessAuthorize(OperatorRoles.REPORTS)]
        public async Task<PartialViewResult> OrdersBox()
        {
            var model = new OrdersBoxViewModel();

            model.Number = 251;
            model.Difference = 20;

            return PartialView("_OrdersBox", model);
        }

        [OutputCache(Duration = CACHE_DURATION, Location = OutputCacheLocation.Server, VaryByCustom = "lang")]
        [AccessAuthorize(OperatorRoles.REPORTS)]
        public async Task<PartialViewResult> VisitsBox()
        {
            var model = new VisitsBoxViewModel();
            model.Number = 16120;
            model.Difference = 44;
            return PartialView("_VisitsBox", model);
        }

        [OutputCache(Duration = CACHE_DURATION, Location = OutputCacheLocation.Server, VaryByCustom = "lang")]
        [AccessAuthorize(OperatorRoles.REPORTS)]
        public async Task<PartialViewResult> ReturnsBox()
        {
            var model = new ReturnsBoxViewModel();
            model.Rate = 2.8m;
            model.Difference = -12;

            return PartialView("_ReturnsBox", model);
        }
    }
}