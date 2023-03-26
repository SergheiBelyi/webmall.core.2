using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace Webmall.UI.Core.HtmlHelpers
{
    public static class LazyPanelHelper
    {
        public static HtmlString LazyPanel(this HtmlHelper htmlHelper, HtmlTextWriterTag elementType,
            string url, string callbackFunction, object attributes = null, string onElementId = null)
        {
            var attrs = new RouteValueDictionary(attributes) { { "data-url", url }, { "data-callback", callbackFunction } };
            if (attrs.ContainsKey("class"))
                attrs["class"] = (string)attrs["class"] + " lazyLoading";
            else
                attrs.Add("class", "lazyLoading");
            if (!string.IsNullOrEmpty(onElementId))
            {
                attrs.Add("data-lazyinit", onElementId);
            }

            var writer = new HtmlTextWriter(new StringWriter());
            foreach (var attr in attrs)
                writer.AddAttribute(attr.Key.Replace("_", "-"), attr.Value?.ToString());
            writer.RenderBeginTag(elementType);
            writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }
    }
}