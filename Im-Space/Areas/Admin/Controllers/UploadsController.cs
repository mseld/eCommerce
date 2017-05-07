using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Helpers;

namespace IM.Web.Areas.Admin.Controllers
{
    public class UploadsController : BaseController
    {
        public UploadsController(DataContext db)
            : base(db)
        {
        }

        // GET: Admin/Uploads
        public ActionResult Index()
        {
            var model = db.Uploads.Where(p => p.Type == UploadType.Documents).ToList();
            return View(model);
        }

        [AccessAuthorize(OperatorRoles.CONTENT + OperatorRoles.WRITE)]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [AccessAuthorize(OperatorRoles.CONTENT + OperatorRoles.WRITE)]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
                return View().WithWarning("Please, Choose file frist");
            try
            {
                string root = Server.MapPath("~/Storage");
                var upload = new Upload
                {                    
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    Extension = Path.GetExtension(file.FileName),
                    Type = UploadType.Documents
                };

                db.Uploads.Add(upload);
                db.SaveChanges();
                file.SaveAs(Path.Combine(root, upload.Id.ToString()));
                return RedirectToAction("Index").WithSuccess("The file has been uploaded successfully".TA());
            }
            catch (Exception)
            {
                return View().WithError("Sorry, Something went wrong");
            }
        }

        [AccessAuthorize(OperatorRoles.CONTENT + OperatorRoles.DELETE)]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var model = db.Uploads.Find(id);
                db.Uploads.Remove(model);
                db.SaveChanges();

                return RedirectToAction("Index")
                    .WithSuccess("The selected file have been deleted".TA());
            }
            catch (Exception)
            {
                return View("Index").WithError("Sorry, Something went wrong");
            }
        }
    }
}