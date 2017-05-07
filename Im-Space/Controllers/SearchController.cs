using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IM.Web.DAL;
using IM.Web.Helpers;
using IM.Web.Models;
using IM.Web.Services;

namespace IM.Web.Controllers
{
    public class SearchController : BaseController
    {
        public SearchController()
        {
        }

        public PartialViewResult SearchBox(int? categoryId, string keywords)
        {
            var model = new SearchViewModel ();
            return PartialView("_SearchBox", model);
        }

        // GET: /Search/Results?CategoryId=5&Keywords=test
        public ActionResult Results(int? categoryId, string keywords)
        {
            var model = new SearchResultsViewModel {CategoryId = categoryId, Keywords = keywords};
            ViewBag.SearchKeywords = keywords;
            return View(model);
        }
    }
}