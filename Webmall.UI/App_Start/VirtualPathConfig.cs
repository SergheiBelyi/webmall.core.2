using System.Web.Hosting;
using SharedLibrary.EmbededResources;

namespace Webmall.UI
{
    public class VirtualPathConfig
    {
        public static void RegisterVirtualPaths()
        {
            var assemblies = new []
            {
                typeof(Webmall.UI.RazorGeneratorMvcStart).Assembly,
                // typeof(EPayKKB.RazorGeneratorMvcStart).Assembly,
                //typeof(SharedLibrary.QBE.UI.QBEAreaRegistration).Assembly
            };

            HostingEnvironment.RegisterVirtualPathProvider(new EmbededVirtualPathProvider(assemblies));
        }
    }
}