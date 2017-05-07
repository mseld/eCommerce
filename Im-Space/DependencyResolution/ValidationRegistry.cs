using System;
using System.Linq;
using System.Reflection;
using IM.Web.Helpers;
using FluentValidation;
using LinqKit;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace IM.Web.DependencyResolution
{
    public class ValidationRegistry : Registry
    {
        public ValidationRegistry()
        {
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetCallingAssembly())
                .ForEach(result =>
                         {
                             if (! Attribute.IsDefined(result.ValidatorType, typeof (DontAutoWireupAttribute)))
                             {
                                 {
                                     For(result.InterfaceType)
                                         .LifecycleIs(new UniquePerRequestLifecycle())
                                         .Use(result.ValidatorType);
                                 }
                             }
                         });
        }
    }
}