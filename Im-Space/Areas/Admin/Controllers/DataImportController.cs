using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using CsvHelper;
using IM.Web.Areas.Admin.Models;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Helpers;
using IM.Web.Services;
using Ionic.Zip;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UploadController = IM.Web.Controllers.Api.UploadController;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class DataImportController : BaseController
    {        
        public DataImportController(DataContext db)
            : base(db)
        {            
        }

        // GET: Admin/DataImport
        [AccessAuthorize(OperatorRoles.DATABASE + OperatorRoles.WRITE)]
        public ActionResult Index()
        {
            return View();
        }

      
        [AccessAuthorize(OperatorRoles.DATABASE + OperatorRoles.WRITE)]
        public ActionResult TranslationsCsv()
        {
            return View();
        }

        [HttpPost]
        [AccessAuthorize(OperatorRoles.DATABASE + OperatorRoles.WRITE)]
        public ActionResult TranslationsCsv(HttpPostedFileBase file)
        {
            if (file.ContentLength <= 0) return View();

            var area = file.FileName.Contains("TranslationsAdmin") ? TranslationArea.Backend : TranslationArea.Frontend;

            var csv = new CsvReader(new StreamReader(file.InputStream));
            ImportTranslationsCsv(db, csv, area);

            return View();
        }


        [AccessAuthorize(OperatorRoles.DATABASE + OperatorRoles.WRITE)]
        public ActionResult MainMenuXml()
        {
            return View();
        }

        [HttpPost]
        [AccessAuthorize(OperatorRoles.DATABASE + OperatorRoles.WRITE)]
        public ActionResult MainMenuXml(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0) return View();

            if (file.ContentLength > 0)
            {
                MainMenu mainMenu = XmlHelper.Load<MainMenu>(file.InputStream);

                if (mainMenu != null && mainMenu.Count > 0)
                {
                    foreach (var menu in mainMenu)
                    {
                        AddOrUpdate(menu);
                    }
                    
                }
            }
            return View().WithSuccess("Data has been save successfully".TA());
        }

        private void AddOrUpdate(Menu menu)
        {
            var _menu = db.Menu.Find(menu.Id);

            if (_menu != null)
            {
                _menu.Text = menu.Text;
                _menu.TextLocalized = menu.TextLocalized;
                _menu.ParentId = menu.ParentId;
                _menu.Order = menu.Order;
                _menu.Href = menu.Href;
            }
            else
            {
                db.Menu.Add(menu);
            }

            db.SaveChanges();

            if (menu.Items != null && menu.Items.Count > 0)
            {
                foreach (var submenu in menu.Items)
                {
                    AddOrUpdate(submenu);
                }
            }
        }

        public static void ImportTranslationsCsv(DataContext db, CsvReader csv, TranslationArea area)
        {
            while (csv.Read())
            {
                var code = csv.GetField<string>(0);
                var key = csv.GetField<string>(1);
                var value = csv.GetField<string>(2);

                // ToList is called on purpose for case sensitive search
                var translation =
                    db.Translations.ToList().FirstOrDefault(
                        t => t.LanguageCode == code && t.Key == key && t.Area == area);

                if (translation == null)
                {
                    translation = new Translation
                                  {
                                      LanguageCode = code,
                                      Key = key,
                                      Value = value,
                                      Area = area
                                  };
                    db.Translations.Add(translation);
                }
                else
                {
                    translation.Value = value;
                }
            }

            db.SaveChanges();

            TranslationHelper.ClearCache();
        }
    }
}