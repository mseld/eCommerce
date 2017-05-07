using IM.Web.Areas.Admin.Models;
using IM.Web.Domain;
using IM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Web.Services
{
    public interface IPage
    {
        Comment AddComment(CommentViewModel model);
        Distributor AddDistributor(DistributorViewModel model);
        ContactUs AddContact(ContactUsViewModel model);
    }
}
