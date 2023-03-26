using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;

namespace SharedLibrary.EmbededResources
{
    public class EmbededVirtualDirectory : VirtualDirectory
    {
        public EmbededVirtualDirectory(string virtualPath) : base(virtualPath)
        {
            _files = new HashSet<EmbededVirtualFile>();
            _directories = new HashSet<EmbededVirtualDirectory>();
        }

        private readonly ICollection<EmbededVirtualFile> _files;
        public override IEnumerable Files
        {
            get { return _files; }
        }

        public void AddFile(EmbededVirtualFile file)
        {
            if (_files.All(f => !string.Equals(f.VirtualPath, file.VirtualPath, StringComparison.InvariantCultureIgnoreCase)))
            {
                _files.Add(file);
            }
        }

        private readonly ICollection<EmbededVirtualDirectory> _directories;
        public override IEnumerable Directories
        {
            get { return _directories; }
        }

        public void AddDirectory(EmbededVirtualDirectory directory)
        {
            if (_directories.All(d => !string.Equals(d.VirtualPath, directory.VirtualPath, StringComparison.InvariantCultureIgnoreCase)))
            {
                _directories.Add(directory);
            }
        }

        public override IEnumerable Children
        {
            get { return _files.Concat<VirtualFileBase>(_directories); }
        }
    }
}
