using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IM.Web.DAL;
using IM.Web.Domain;
using IM.Web.Helpers;
using IM.Web.Models;
using IM.Web.Services;

namespace IM.Web.Controllers
{
    public class ContentPageController : BaseController
    {
        private readonly ICacheService cacheService;

        public ContentPageController(DataContext db, ICacheService cacheService) : base(db)
        {
            this.cacheService = cacheService;
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 5*60, VaryByParam = "*")]
        public PartialViewResult HeaderLinks()
        {
            var model = cacheService.Get("contentpage_headerlinks",
                () =>
                {
                    IOrderedQueryable<ContentPage> pages = db.ContentPages.Where(
                        c => c.HeaderPosition != null)
                        .OrderBy(c => c.HeaderPosition);

                    var m = new List<ContentPageLinksViewModel>();

                    foreach (ContentPage page in pages)
                    {
                        var viewItem = new ContentPageLinksViewModel();
                        viewItem.Title = page.LinkText ?? page.Title;
                        viewItem.Url = page.RedirectToUrl ??
                                       Url.Action("Details", "ContentPage",
                                           new {id = page.Id, slug = page.Title.ToSlug()});
                        viewItem.Visable = page.Visable;
                        m.Add(viewItem);
                    }
                    return m;
                }, invalidateKeys: "contentpages");

            return PartialView("_HeaderLinks", model);
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 5*60, VaryByParam = "*")]
        public PartialViewResult FooterLinks(int? section = null)
        {
            string cacheKey = "contentpage_footerlinks" + section ?? "";
            var model = cacheService.Get(cacheKey,
                () =>
                {
                    IOrderedQueryable<ContentPage> pages =
                        db.ContentPages.Where(c => c.FooterPosition != null && c.FooterSection == section).OrderBy(c => c.FooterPosition);

                    var m = new List<ContentPageLinksViewModel>();

                    foreach (ContentPage page in pages)
                    {
                        var viewItem = new ContentPageLinksViewModel();
                        viewItem.LinkText = page.LinkText ?? page.Title;
                        viewItem.Title = page.Title;
                        viewItem.Url = page.RedirectToUrl ??
                                       Url.Action("Details", "ContentPage",
                                           new { id = page.Id, slug = page.Title.ToSlug() });
                        viewItem.Visable = page.Visable;
                        m.Add(viewItem);
                    }
                    return m;
                }, invalidateKeys: "contentpages");

            return PartialView("_FooterLinks", model);
        }

        public ActionResult Details(int id)
        {
            ContentPage model = db.ContentPages.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}