using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using IM.Web.Domain;

namespace IM.Web.Helpers
{
    public static class OperatorRoles
    {
        public const string INVENTORY = "INVENTORY";
        public const string ORDERS = "ORDERS";
        public const string SHIPMENTS = "SHIPMENTS";
        public const string CUSTOMERS = "CUSTOMERS";
        public const string SETTINGS = "SETTINGS";
        public const string TEMPLATES = "TEMPLATES";
        public const string CONTENT = "CONTENT";
        public const string OPERATORS = "OPERATORS";
        public const string DATABASE = "DATABASE";
        public const string REPORTS = "REPORTS";

        public const string WRITE = "_WRITE";

        public const string DELETE = "_DELETE";

        public static bool HasAccess(this IPrincipal user, string role)
        {
            return user.IsInRole(User.ADMIN_ROLE) || user.IsInRole(role);
        }
    }
}