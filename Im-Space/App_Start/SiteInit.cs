using System.Web.Configuration;
using IM.Web.Areas.Admin.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Tasks;
using IM.Web.Services;

namespace IM.Web
{
    public class SiteInit : IRunAtStartup
    {
        private readonly ISettingService settingService;

        public SiteInit(DataContext db, ISettingService settingService)
        {
            this.settingService = settingService;
        }

        public void Execute()
        {
            if (settingService.Get<bool>(SettingField.IsInitialized)) return;

            if (!string.IsNullOrEmpty(WebConfigurationManager.AppSettings["DefaultStoreName"]))
                settingService.Set(SettingField.StoreName, WebConfigurationManager.AppSettings["DefaultStoreName"]);

            if (WebConfigurationManager.AppSettings["DefaultCulture"].StartsWith("ar"))
            {
                settingService.Set(SettingField.CurrencyCode, "SAR");
                settingService.Set(SettingField.CurrencySuffix, " SAR.");
            }

            settingService.Set(SettingField.IsInitialized, true);
        }
    }
}