using System.Collections.Generic;
using System.Globalization;

namespace Webmall.Model.Entities.Cms.Localization
{
    public class LString : Dictionary <string, string>
    {
        public LString() { }
        public LString(Dictionary<string, string> data) : base(data) { }

        public string Str => this;

        public override string ToString()
        {
            return ContainsKey(CultureInfo.CurrentCulture.Name)
                ? this[CultureInfo.CurrentCulture.Name]
                : ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] : "";
        }

        public string[] ToTags()
        {
            return ToString().Split(',');
        }

        public static implicit operator LString(string str)
        {
            return new LString { { CultureInfo.CurrentCulture.Name, str } };
        }

        public static implicit operator string(LString str)
        {
            if (str == null)
                return null;
            return str.ContainsKey(CultureInfo.CurrentCulture.Name) 
                ? str[CultureInfo.CurrentCulture.Name]
                : str.ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? str[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] : null;
        }
    }
}
