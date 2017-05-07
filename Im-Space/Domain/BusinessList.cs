using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Domain
{
    public class BusinessList
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
        public string TextLocalized { get; set; }
        public string ListType { get; set; }
    }
}