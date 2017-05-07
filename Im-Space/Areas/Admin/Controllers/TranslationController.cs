using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using IM.Web.Areas.Admin.Models;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Services;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class TranslationController : BaseController
    {
        private readonly ICacheService cacheService;

        public TranslationController(DataContext db, ICacheService cacheService) : base(db)
        {
            this.cacheService = cacheService;
        }

        public PartialViewResult LanguageSelector()
        {
            var cache = cacheService.Get("LanguageSelector",
                () =>
                {
                    var langCodes = (from t in db.Translations
                                     where t.Area == TranslationArea.Backend
                                     select t.LanguageCode).Distinct().ToList();

                    var model = new LanguageSelectorViewModel();

                    if (!langCodes.Contains("en"))
                    {
                        model.Languages.Add(new LanguageViewModel { Code = "en", DisplayName = "English" });
                    }
                    foreach (var code in langCodes)
                    {
                        var culture = CultureInfo.GetCultureInfo(code);
                        model.Languages.Add(new LanguageViewModel
                        {
                            Code = code,
                            DisplayName = culture.NativeName
                        });
                    }
                    return model;
                });

            return PartialView(cache);
        }

        public ActionResult SetActive(string code, string backUrl)
        {
            HttpContext.Response.SetCookie(new HttpCookie("lang", code));

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(code);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(code);

            return Redirect(backUrl ?? Url.Action("Index", "Home"));
        }
    }
}