using System;

namespace IM.Web.Services
{
    public interface IUploadService
    {
        Guid? FindPrimaryId(string id);
    }
}