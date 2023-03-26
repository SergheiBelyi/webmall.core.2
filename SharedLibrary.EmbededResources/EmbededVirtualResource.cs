using System;
using System.IO;
using System.Reflection;
using System.Web.Caching;

namespace SharedLibrary.EmbededResources
{
    public class EmbededVirtualResource
    {
        public EmbededVirtualResource(Assembly assembly, string resourcePath)
        {
            Assembly = assembly;
            AssemblyName = assembly.GetName().Name;
            AssemblyLastModified = new FileInfo(assembly.Location).LastWriteTime;

            ResourcePath = resourcePath;

            var extension = Path.GetExtension(resourcePath) ?? string.Empty;
            {
                var filePath = resourcePath.Substring(0, resourcePath.LastIndexOf(extension, StringComparison.Ordinal)).Replace('.', '\\');
                var fileName = Path.GetFileName(filePath);

                FileName = string.Format("{0}{1}", fileName, extension);
                FilePath = filePath.Substring(0, filePath.LastIndexOf(fileName, StringComparison.Ordinal));
            }

            GetStream = () => assembly.GetManifestResourceStream(resourcePath);
            GetCacheDependency = (utcStart) => new CacheDependency(assembly.Location);
        }

        public Assembly Assembly
        {
            get;
            private set;
        }

        public string AssemblyName
        {
            get;
            private set;
        }

        public DateTime AssemblyLastModified
        {
            get;
            private set;
        }

        public string ResourcePath
        {
            get;
            private set;
        }

        public string FilePath
        {
            get;
            private set;
        }

        public string FileName
        {
            get;
            private set;
        }

        public Func<Stream> GetStream
        {
            get;
            private set;
        }

        public Func<DateTime, CacheDependency> GetCacheDependency
        {
            get;
            private set;
        }
    }
}
