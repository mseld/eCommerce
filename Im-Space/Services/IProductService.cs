using IM.Web.Areas.Admin.Models;
using IM.Web.Domain;
using System.Collections.Generic;

namespace IM.Web.Services
{
    public interface IProductService
    {
        List<FeaturedProduct> GetFeatured(string locale = "en");
    }
}