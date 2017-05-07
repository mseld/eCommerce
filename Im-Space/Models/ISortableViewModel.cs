using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public interface ISortableViewModel
    {
        string OrderColumn { get; set; }
        bool OrderAsc { get; set; }
    }
}