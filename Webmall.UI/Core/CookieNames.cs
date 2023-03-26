namespace Webmall.UI.Core
{
    public static class CookieNames
    {
        public static string Prefix { get; set; } = "webmall";

        public static string SearchType => Prefix + "SearchType";
        public static string AccurateSearch => Prefix + "AccSearch";
    }
}