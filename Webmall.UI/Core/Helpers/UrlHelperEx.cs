using System.Web.Mvc;

namespace Webmall.UI.Core.Helpers
{
    public static class UrlHelperEx
    {
        public static string ToLocalizedUrl(this WebViewPage ctx, string url)
        {
            if (url == "#") return null;
            var result = IsLocalLink(url)
                ? ('/' + ctx.Url.Action("Index", "Home")?.Trim('/') + '/').Replace("//", "/") + url?.Trim('/')
                : url;
            return result;
        }


        public static string LikAttrs(this WebViewPage ctx, string url)
        {
            var result = IsLocalLink(url)
                ? ""
                : "rel=\"nofollow\" target=\"blank\"";
            return result;
        }

        private static bool IsLocalLink(string url)
        {
            return url?.StartsWith("/") == true || url?.Contains("://") == false;
        }

    }
}