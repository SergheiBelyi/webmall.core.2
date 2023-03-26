namespace Webmall.Model.Entities.Cms.Localization
{
    public class Language
    {
        //public string Id { get; set; }
        public string Culture { get; set; }
        public string Display { get; set; }
        public bool IsDefault { get; set; }

        //public static string RemoveFromUrl(string url, string langPrefix)
        //{
        //    if (url.StartsWith(langPrefix))
        //        return url.Substring(langPrefix.Length);
        //    return "";
        //}
    }
}
