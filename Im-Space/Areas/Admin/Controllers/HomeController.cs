using System.Linq;
using System.Web.Mvc;
using IM.Web.Areas.Admin.Models;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Helpers;
using IM.Web.Services;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : BaseController
    {
        private readonly ISettingService settingService;

        public HomeController(DataContext db, ISettingService settingService)
            : base(db)
        {
            this.settingService = settingService;
        }

        public ActionResult Index()
        {
            if (!User.HasAccess(OperatorRoles.REPORTS))
            {
                return RedirectToAction("OperatorWelcome");
            }

            if (settingService.Get<bool>(SettingField.ShowWelcomePage))
            {
                if (!settingService.Get<bool>(SettingField.ShowCategoryTutorial)
                    && !settingService.Get<bool>(SettingField.ShowProductTutorial)
                    && !settingService.Get<bool>(SettingField.ShowOptionTutorial)
                    && !settingService.Get<bool>(SettingField.ShowTaxRateTutorial)
                    && !settingService.Get<bool>(SettingField.ShowShippingRateTutorial))
                {
                    settingService.Set(SettingField.ShowWelcomePage, false);
                }
                else
                {
                    return RedirectToAction("Welcome");
                }
            }

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Remove()
        {
            settingService.Set(SettingField.ShowWelcomePage, false);
            settingService.Set(SettingField.ShowCategoryTutorial, false);
            settingService.Set(SettingField.ShowProductTutorial, false);
            settingService.Set(SettingField.ShowOptionTutorial, false);
            settingService.Set(SettingField.ShowTaxRateTutorial, false);
            settingService.Set(SettingField.ShowShippingRateTutorial, false);

            return RedirectToAction("Index");
        }

        public ActionResult OperatorWelcome()
        {
            return View();
        }
    }
}