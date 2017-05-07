using System;
using System.Collections.Generic;

namespace IM.Web.Models
{
    public class BreadcrumbViewModel
    {
        public List<Tuple<string, string>> Nodes { get; set; }
    }
}