using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace IM.Web.DependencyResolution
{
    public static class ContainerPerRequestExtensions
    {
        public static IContainer GetContainer(this HttpContextBase context)
        {
            return IoC.StructureMapResolver.CurrentNestedContainer
                   ?? IoC.StructureMapResolver.Container;
        }
    }
}