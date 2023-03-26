using System.Collections.Generic;
using System.Globalization;

namespace Webmall.Model.Entities.Cms.Localization
{
    public class LBoolean : Dictionary <string, bool>
    {
        public LBoolean() { }
        public LBoolean(Dictionary<string, bool> data) : base(data) { }

        public bool? Boolean => this;

        public bool? ToBoolean()
        {
            return ContainsKey(CultureInfo.CurrentCulture.Name)
                ? this[CultureInfo.CurrentCulture.Name]
                : ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] : (bool?)null;
        }
        public static implicit operator LBoolean(bool value)
        {
            return new LBoolean { { CultureInfo.CurrentCulture.Name, value } };
        }

        public static implicit operator bool?(LBoolean value)
        {
            return value.ContainsKey(CultureInfo.CurrentCulture.Name) 
                ? value[CultureInfo.CurrentCulture.Name]
                : value.ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? value[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] : (bool?) null;
        }
    }
}
