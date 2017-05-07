using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IM.Web.DAL;
using IM.Web.Domain;
using Glimpse.Core.Extensions;

namespace IM.Web.Services
{
    public class UploadService : IUploadService
    {
        private readonly DataContext db;
        private readonly ICacheService cacheService;

        public UploadService(DataContext db, ICacheService cacheService)
        {
            this.db = db;
            this.cacheService = cacheService;
        }

        public Guid? FindPrimaryId(string id)
        {
            return null;
            //return id is Guid ? (Guid?)id : null;
        }
    }
}