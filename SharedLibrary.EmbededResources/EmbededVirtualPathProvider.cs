using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace SharedLibrary.EmbededResources
{
    public class EmbededVirtualPathProvider : VirtualPathProvider
    {
        private readonly ICollection<Assembly> _assemblies;
        private readonly IDictionary<string, EmbededVirtualResource> _resources;

        public EmbededVirtualPathProvider()
        {
            _assemblies = new Collection<Assembly>();
            _resources = new Dictionary<string, EmbededVirtualResource>();
        }

        public EmbededVirtualPathProvider(params Assembly[] assemblies): this()
        {
            Array.ForEach(assemblies, AddAssembly);
        }

        public void AddAssembly(Assembly assembly)
        {
            _assemblies.Add(assembly);

            var assemblyName = assembly.GetName().Name;

            foreach (var resourcePath in assembly.GetManifestResourceNames().Where(r => r.StartsWith(assemblyName)))
            {
                var embededResourceKey = resourcePath.ToUpperInvariant();
                var embededResource = new EmbededVirtualResource(assembly, resourcePath);
                _resources.Add(embededResourceKey, embededResource);
            }
        }

        public EmbededVirtualResource GetResourceFromVirtualPath(string virtualPath)
        {
            var embededKey = VirtualPathToResourceKey(virtualPath);
            var embededResourceExist = _resources.ContainsKey(embededKey);
            if (!embededResourceExist)
            {
                embededKey = VirtualPathToResourceKey(virtualPath.Replace('_', '.'));
                embededResourceExist = _resources.ContainsKey(embededKey);
            }

            return embededResourceExist ? _resources[embededKey] : null;
        }

        public IEnumerable<KeyValuePair<string, EmbededVirtualResource>> GetResourcesFromVirtualDir(string virtualDir)
        {
            var embededKey = VirtualPathToResourceKey(virtualDir);

            return _resources.Where(r => r.Key.StartsWith(embededKey));
        }

        #region Overrided Methods
        public override bool FileExists(string virtualPath)
        {
            var result = base.FileExists(virtualPath) || GetResourceFromVirtualPath(virtualPath) != null;
            return result;
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var resource = GetResourceFromVirtualPath(virtualPath);

            if (resource != null)
            {
                return new EmbededVirtualFile(virtualPath, resource);
            }

            return base.GetFile(virtualPath);
        }

        public override bool DirectoryExists(string virtualDir)
        {
            return base.DirectoryExists(virtualDir) || GetResourcesFromVirtualDir(virtualDir).Any();
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            var resources = GetResourcesFromVirtualDir(virtualDir);

            var embededVirtualResources = resources.ToArray();
            if (embededVirtualResources.Any())
            {
                var directory = new EmbededVirtualDirectory(virtualDir);
                var directoryKey = VirtualPathToResourceKey(virtualDir);

                foreach (var resource in embededVirtualResources)
                {
                    var fileVirtualPath = string.Format("{0}/{1}", virtualDir.TrimEnd('/'), resource.Value.FileName);
                    var fileKey = VirtualPathToResourceKey(fileVirtualPath);
                    if (string.CompareOrdinal(fileKey, resource.Key) == 0)
                    {
                        var file = new EmbededVirtualFile(fileVirtualPath, resource.Value);
                        directory.AddFile(file);
                        continue;
                    }

                    var resourcePathKey = ResourcePathToResourceKey(resource.Value.FilePath);
                    var resourceFolders = (directoryKey == string.Empty ? directoryKey : resourcePathKey.Replace(directoryKey, string.Empty))
                        .Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                    var resourceFolder = resourceFolders.FirstOrDefault();
                    if (string.IsNullOrWhiteSpace(resourceFolder))
                    {
                        continue;
                    }

                    var subDirectoryVirtualPath = string.Format("{0}/{1}", virtualDir.TrimEnd('/'), resourceFolder);
                    var subDirectory = new EmbededVirtualDirectory(subDirectoryVirtualPath);
                    directory.AddDirectory(subDirectory);
                }

                return directory;
            }

            return base.GetDirectory(virtualDir);
        }

        public override string GetCacheKey(string virtualPath)
        {
            var resource = GetResourceFromVirtualPath(virtualPath);
            if (resource != null)
            {
                return (virtualPath + resource.AssemblyName + resource.AssemblyLastModified.Ticks).GetHashCode().ToString();
            }
            return base.GetCacheKey(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            var resource = GetResourceFromVirtualPath(virtualPath);
            if (resource != null)
            {
                return resource.GetCacheDependency(utcStart);
            }

            if (base.DirectoryExists(virtualPath) || base.FileExists(virtualPath))
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }

            return null;
        }
        #endregion

        #region Private Method
        private static string VirtualPathToResourceKey(string virtualPath)
        {
            var path = VirtualPathUtility.ToAppRelative(virtualPath).TrimStart('~', '/').TrimEnd('/');
            var index = path.LastIndexOf("/", StringComparison.Ordinal);

            if (index != -1)
            {
                var folder = path.Substring(0, index).Replace("-", "_"); //embedded resources with "-" in their folder names are stored as "_".
                path = folder + path.Substring(index);
            }

            var embededKey = path.Replace('/', '.').ToUpperInvariant();

            return embededKey;
        }

        private static string ResourcePathToResourceKey(string resourcePath)
        {
            var path = resourcePath.Trim('\\');
            var index = path.LastIndexOf("\\", StringComparison.Ordinal);

            if (index != -1)
            {
                var folder = path.Substring(0, index).Replace("-", "_"); //embedded resources with "-" in their folder names are stored as "_".
                path = folder + path.Substring(index);
            }

            var embededKey = path.Replace('\\', '.').ToUpperInvariant();

            return embededKey;
        }
        #endregion
    }
}
