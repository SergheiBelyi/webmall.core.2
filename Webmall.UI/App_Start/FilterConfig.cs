using System.Web.Mvc;
using Webmall.UI.Core.Localization;

namespace Webmall.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute(null), 0);
        }
    }
}
