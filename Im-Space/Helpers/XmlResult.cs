using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.Web;

namespace IM.Web.Helpers
{
    public class XmlResult<T> : ActionResult 
    {
        public T Data { private get; set; }
        public string Name { private get; set; }
        
        public override void ExecuteResult(ControllerContext context)
        {
            if (string.IsNullOrEmpty(Name))
                Name = "";

            HttpContextBase httpContextBase = context.HttpContext;
            httpContextBase.Response.Buffer = true;
            httpContextBase.Response.Clear();
            
            string fileName = Name + DateTime.Now.ToString("ddmmyyyyhhss") + ".xml";
            httpContextBase.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            httpContextBase.Response.ContentType = "text/xml";
            httpContextBase.Response.ContentEncoding = Encoding.UTF8;
            httpContextBase.Response.Charset = "utf-8";

            using (StringWriter writer = new Utf8StringWriter())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(writer, Data);
                httpContextBase.Response.Write(writer);
            }
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        // Use UTF8 encoding but write no BOM to the wire
        public override Encoding Encoding
        {
            get { return new UTF8Encoding(false); } // in real code I'll cache this encoding.
        }
    }
}