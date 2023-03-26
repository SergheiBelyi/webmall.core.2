using System.Collections.Generic;
using System.Globalization;

namespace Webmall.Model.Entities.Cms.Localization
{
    public class LArray<T> : Dictionary<string, T[]>
    {
        public T[] Current =>
            ContainsKey(CultureInfo.CurrentCulture.Name)
                ? this[CultureInfo.CurrentCulture.Name]
                : ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName]
                    : null;
    }
}
