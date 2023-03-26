using System.Collections;
using System.Globalization;
using System.Text;

namespace Webmall.UI.Core.Core
{
    public static class ResourceHelper
    {
        public static StringBuilder GetResourcesString(CultureInfo cultureInfo, System.Resources.ResourceManager manager, string defaultCulture = "ru-RU")
        {
            // var manager = Resources.Client.ResourceManager;
            var resourceSet = manager.GetResourceSet(new CultureInfo(defaultCulture), true, true);
            var result = new StringBuilder();
            result.Append("{");
            foreach (DictionaryEntry resource in resourceSet)
            {
                result.Append($"\"{resource.Key}\": \"{manager.GetString(resource.Key.ToString(), cultureInfo).Replace("\n", "").Replace("\r", "").Replace("\t", "")}\",");
            }
            if (result.Length > 1)
                result.Length--;
            result.Append("}");
            return result;
        }
    }
}
