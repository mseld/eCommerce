using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CsvHelper;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Helpers;
using IM.Web.Services;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class DataExportController : BaseController
    {
        private readonly IWorkProcessService workProcessService;

        public DataExportController(DataContext db, IWorkProcessService workProcessService)
            : base(db)
        {
            db.Configuration.ProxyCreationEnabled = false;
            this.workProcessService = workProcessService;
        }

        // GET: Admin/DataExport
        [AccessAuthorize(OperatorRoles.DATABASE)]
        public ActionResult Index()
        {
            return View();
        }

        [AccessAuthorize(OperatorRoles.DATABASE)]
        public ActionResult MainMenuXml()
        {
            //var menuList = db.Menu.AsNoTracking().ToList();
            MainMenu mainMenu = new MainMenu();
            var menuList = db.Menu.ToList();
            mainMenu.AddRange(menuList.Where(mu => !mu.ParentId.HasValue));

            return new XmlResult<MainMenu>
            {
                Name = "MainMenu_",
                Data = mainMenu
            };
        }
       
        [AccessAuthorize(OperatorRoles.DATABASE)]
        public FileStreamResult TranslationsCsv(bool admin = false)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            var csv = new CsvWriter(sw);

            var translations = (from t in db.Translations
                where t.Area == (admin ? TranslationArea.Backend : TranslationArea.Frontend)
                select new
                       {
                           t.LanguageCode,
                           t.Key,
                           t.Value
                       }).ToList();

            csv.WriteHeader(translations.First().GetType());
            foreach (var trans in translations)
            {
                csv.WriteRecord(trans);
            }

            sw.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            var result = new FileStreamResult(ms, "application/octet-stream");
            result.FileDownloadName = "Translations_" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".csv";
            return result;
        }
    }
}