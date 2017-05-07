using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IM.Web.Domain;

namespace IM.Web.DependencyResolution.PaymentMethods
{
    public interface IPaymentMethod
    {
        IPaymentMethodSettings Settings { set; }

        ActionResult Process(Order order);
    }
}