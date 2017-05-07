using System;
using System.Linq;
using System.Transactions;
using AutoMapper;
using IM.Web.Areas.Admin.Models;
using IM.Web.DAL;
using IM.Web.Domain;    
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;

namespace IM.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext db;
        private readonly ICacheService cacheService;

        public ProductService(DataContext db, ICacheService cacheService)
        {
            this.db = db;
            this.cacheService = cacheService;
        }

        public List<FeaturedProduct> GetFeatured(string locale = "en")
        {
            try
            {
                var client = new RestClient("http://212.12.165.137:7203/ajlan/promo/gadgets/homeFeaturedProducts_json.jsp?locale=" + locale + "&format=json");                
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = RemoveLineEndings(response.Content);
                    content = Regex.Replace(content, @"\s+", " ").Trim();
                    FeaturedProducts prod = JsonConvert.DeserializeObject<FeaturedProducts>(content);
                    return prod.featuredProducts;
                }
            }
            catch (Exception)
            {
                //TODO: Log Exception
            }
            return new List<FeaturedProduct>();
        }

        public string RemoveLineEndings(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }
    }
}