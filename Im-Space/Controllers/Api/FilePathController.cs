using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using IM.Web.DAL;

namespace IM.Web.Controllers.Api
{
    public class FilePathController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            string path;
            if (id == Guid.Empty.ToString())
            {
                path = HttpContext.Current.Server.MapPath("~/Content/img/no-img-gallery.png");
            }
            else
            {
                string root = HttpContext.Current.Server.MapPath("~/Storage");
                path = Path.Combine(root, id);
                
            }

            var fileObj = DataContext.Current.Uploads.Find(Guid.Parse(id));

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue(fileObj.ContentType);
            return result;
        }
    }
}
