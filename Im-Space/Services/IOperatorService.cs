using System.Collections.Generic;
using System.Linq;
using IM.Web.Areas.Admin.Models;
using IM.Web.Domain;

namespace IM.Web.Services
{
    public interface IOperatorService
    {
        IQueryable<User> FindAll();
        User Find(string id);
        User AddOrUpdate(OperatorViewModel model);
        List<string> GetRoles(string userId);
        void Delete(string id);
    }
}