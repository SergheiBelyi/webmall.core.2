using System.Collections.Generic;
using System.Globalization;

namespace Webmall.Model.Entities.Cms.Localization
{
    public class LObjectGeneric<T> : Dictionary <string, T>
    {
        public LObjectGeneric() { }
        public LObjectGeneric(Dictionary<string, T> data) : base(data) { }

        public T ObjectGeneric => this;

        public T ToLObjectGeneric()
        {
            return ContainsKey(CultureInfo.CurrentCulture.Name)
                ? this[CultureInfo.CurrentCulture.Name]
                : ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] : default(T);
        }

        public static implicit operator LObjectGeneric<T>(T value)
        {
            return new LObjectGeneric<T> { { CultureInfo.CurrentCulture.Name, value } };
        }

        public static implicit operator T(LObjectGeneric<T> str)
        {
            return str.ContainsKey(CultureInfo.CurrentCulture.Name)
                ? str[CultureInfo.CurrentCulture.Name]
                : str.ContainsKey(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    ? str[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] : default(T);
        }
    }
}
