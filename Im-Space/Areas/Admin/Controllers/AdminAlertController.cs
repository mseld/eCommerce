using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IM.Web.DependencyResolution.Filters;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class AdminAlertController : Controller
    {
        // GET: Admin/AdminAlert
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}