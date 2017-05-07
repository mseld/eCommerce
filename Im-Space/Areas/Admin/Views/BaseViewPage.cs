using System.Linq;
using System.Web.Mvc;
using IM.Web.Services;

namespace IM.Web.Areas.Admin.Views
{
    public class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        private readonly ISettingService _settingService;

        public ISettingService Settings
        {
            get { return _settingService; }
        }

        public BaseViewPage()
        {
            _settingService = DependencyResolver.Current.GetService<ISettingService>();
        }

        public BaseViewPage(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public override void Execute()
        {
            // Do nothing
        }

        public bool IsAny(params string[] controllers)
        {
            return controllers.Any(c => Is(c));
        }

        public bool Is(string controller, string action = null)
        {
            if (ViewContext.RouteData.Values["Controller"].ToString().ToLower() == controller.ToLower()
                && (action == null ||
                 ViewContext.RouteData.Values["Action"].ToString().ToLower() == action.ToLower()))
                return true;
            return false;
        }
    }
}