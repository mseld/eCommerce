using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using IM.Web.Areas.Admin.Models;
using IM.Web.Domain;
using IM.Web.Helpers;
using IM.Web.Models;
using IM.Web.Services;

namespace IM.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ISettingService settings;
        private readonly IProductService productService;

        public ProductController(ISettingService settings,IProductService productService)
        {
            this.settings = settings;
            this.productService = productService;
        }

        [ChildActionOnly]
        public PartialViewResult GetProductFeatured(string locale = "en")
        {
            var model = productService.GetFeatured(locale);
            return PartialView("_ProductFeatured", model);
        }

        [ChildActionOnly]
        public PartialViewResult GetMostViewed(string locale = "en")
        {
            var model = productService.GetFeatured(locale);
            return PartialView("_MostViewed", model);
        }

        [ChildActionOnly]
        public PartialViewResult GetNewArrivals(string locale = "en")
        {
            var model = productService.GetFeatured(locale);
            return PartialView("_NewArrivals", model);
        }
        public JsonResult List(int? categoryId, int page = 1, int pageSize = 0, string keywords = null,
            bool? featured = null, int[] optionIds = null)
        {            
            return JsonSuccess(new { });
        }
   
        //// GET: Product/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View(new { });
        //}
    }
}