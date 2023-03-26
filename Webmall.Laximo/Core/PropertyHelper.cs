using System.Collections.Generic;
using System.Linq;
using Laximo.Guayaquil.Data.Entities;

namespace Webmall.Laximo.Core
{
    public static class PropertyHelper
    {
        public static DataAttribute[] GetExtProperties(DataAttribute[] allAttributes, List<string> fixedAttrs)
        {
            if (allAttributes == null)
                return new DataAttribute[0];
            return allAttributes.Where(i => !fixedAttrs.Contains(i.Key.ToLower())).ToArray();
        }

        public static string GetValue(this DataAttribute[] attrs, string key)
        {
            return attrs.Where(i => i.Key == key).Select(i => i.Value).FirstOrDefault();
        }

        public static string GetName(this DataAttribute[] attrs, string key)
        {
            return attrs.Where(i => i.Key == key).Select(i => i.Name).FirstOrDefault();
        }
    }
}