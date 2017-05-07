using System;

namespace IM.Web.Services
{
    public interface IVisitorService
    {
        Guid TrackVisitor(Guid? id, string userId, string ipAddress);
    }
}