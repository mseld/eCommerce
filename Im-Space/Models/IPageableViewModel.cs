using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public interface IPageableViewModel
    {
        int Page { get; set; }

        int PageSize { get; set; }

        int TotalPages { get; set; }

        int TotalItems { get; set; }
    }
}