using System.Web.Mvc;

namespace Webmall.UI.Core.HtmlHelpers
{
    public static class WareUrlHelper
    {
        public static string Ware (this UrlHelper urlHelper, Model.Entities.Catalog.Ware ware)
        {
            return urlHelper.Action("WareCard", "Catalog")?.Replace("WareCard", "") + $"{ware.ProducerName}/{ware.WareNumber}";
        }

        public static string Ware(this UrlHelper urlHelper, Model.Entities.Catalog.WareListItem ware)
        {
            return urlHelper.Action("WareCard", "Catalog")?.Replace("WareCard", "") + $"{ware.ProducerName}/{ware.WareNumber}";
        }
    }
}