using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using System.Web;

namespace IM.Web.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetLang(string code, string backUrl)
        {
            HttpContext.Response.SetCookie(new HttpCookie("lang", code));

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(code);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(code);            
            
            return Redirect(backUrl ?? Url.Action("Index", "Home"));
        }
    }
}