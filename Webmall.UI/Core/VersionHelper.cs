using System.Reflection;
using ViewRes;

namespace Webmall.UI.Core
{
    public static class VersionHelper
    {
        private static string _version;

        public static string VersionInfo()
        {
            if (_version == null)
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                _version = SharedResources.Version + $": {version.Major}.{version.Minor}.{version.Build}";
            }
            return _version;
        }
    }
}