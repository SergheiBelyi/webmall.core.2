using System.IO;
using System.Web.Hosting;

namespace SharedLibrary.EmbededResources
{
    public class EmbededVirtualFile : VirtualFile
    {
        public EmbededVirtualFile(string virtualPath): base(virtualPath)
        {
        }

        public EmbededVirtualFile(string virtualPath, EmbededVirtualResource resource): this(virtualPath)
        {
            Resource = resource;
        }

        public EmbededVirtualResource Resource
        {
            get;
            private set;
        }

        public override Stream Open()
        {
            return Resource.GetStream();
        }
    }
}
