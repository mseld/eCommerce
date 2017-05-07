using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using IM.Web.DAL;
using IM.Web.Domain;
using IM.Web.Helpers;
using LinqKit;

namespace IM.Web.Services
{
    //public class ProductFinder : IProductFinder
    //{
    //    private readonly DataContext db;

    //    public ProductFinder(DataContext db)
    //    {
    //        this.db = db;
    //    }

    //    public IQueryable<Product> FindAll()
    //    {
    //        return db.Products;
    //    }

    //    public Product Find(int id)
    //    {
    //        return db.Products.Find(id);
    //    }
    //}
}