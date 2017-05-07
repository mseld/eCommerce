using System.Linq;
using IM.Web.DAL;
using IM.Web.Helpers;

namespace IM.Web.Controllers
{
    public class RegionController : BaseController
    {
        // POST: Region/List
        public RegionController(DataContext db) : base(db)
        {
        }

        public StandardJsonResult List(string countryCode)
        {
            var result = db.Regions.Where(r => r.CountryCode == countryCode)
                .Select(r => new {r.Id, r.Code, r.CountryCode, r.Name})
                .ToList();
            return JsonSuccess(result);
        }
    }
}