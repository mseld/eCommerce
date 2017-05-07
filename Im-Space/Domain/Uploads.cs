using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IM.Web.Domain
{
    public class Upload
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }

        [DefaultValue(UploadType.Attachments)]
        public UploadType Type { get; set; }

        [DefaultValue(1)]
        public int SortOrder { get; set; }        

    }

    public enum UploadType
    {        
        TemplateImage = 1,
        Image = 2,
        Attachments = 3,
        Documents = 4
    }
}