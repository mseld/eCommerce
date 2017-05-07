using IM.Web.Domain;

namespace IM.Web.Models
{
    public class SearchViewModel
    {
        public int? CategoryId { get; set; }

        public string Keywords { get; set; }
    }

    public class SearchResultsViewModel
    {
        public int? CategoryId { get; set; }

        public string Keywords { get; set; }
    }
}