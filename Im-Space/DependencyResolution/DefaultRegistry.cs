using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace IM.Web.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}