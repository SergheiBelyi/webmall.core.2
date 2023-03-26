using System;

namespace Webmall.Model
{
    public class CultureHelper
    {
        public static string LocalizeString(Type resourceType, string key)
        {
            var resProperty = resourceType.GetProperty(key.Replace("-", "_"));
            return resProperty == null ? $"[{key}]" : resProperty.GetValue(resProperty.DeclaringType, null).ToString();
        }
    }
}
