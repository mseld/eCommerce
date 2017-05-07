using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM.Web.Domain
{
    public class FeaturedProducts
    {
        public List<FeaturedProduct> featuredProducts { get; set; }
    }
    public class FeaturedProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string price { get; set; }
        public string productImage { get; set; }

        public string ProductImage
        {
            get
            {
                return "http://212.12.165.137:7203" + productImage;
            }
        }
    }
}