using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using Webmall.UI.Service.Interfaces;

namespace Webmall.UI.Core.HtmlHelpers
{
    public static class ImageUrlHelper
    {
        private static readonly MemoryCache Cache = new MemoryCache("images");
        private static readonly IImageUrlGenerator Generator;

        static ImageUrlHelper()
        {
            Generator = DependencyResolver.Current.GetService<IImageUrlGenerator>();
        }

        public static string ProducerImage(this UrlHelper urlHelper, string producerName)
        {
            var key = "brand:" + producerName;
            if (Cache.Contains(key))
                return (string)Cache[key];
            var url = Generator.ProducerImage(urlHelper, producerName.Replace(" ", "_"));
            Cache.Add(key, url, DateTimeOffset.Now.AddHours(6));
            return url;
        }

        public static string MarkaImage(this UrlHelper urlHelper, string markaName)
        {
            var key = "marka:" + markaName;
            if (Cache.Contains(key))
                return (string) Cache[key];

            var url = Generator.MarkaImage(urlHelper, markaName);
            Cache.Add(key, url, DateTimeOffset.Now.AddHours(6));
            return url;
        }

        public static string WareImage(this UrlHelper urlHelper, string imageId)
        {
            return Generator.WareImage(urlHelper, imageId);
        }

        public static string ModelImage(this UrlHelper urlHelper, string markaName, string modelName)
        {
            if (markaName == null || modelName == null)
                return null;
            modelName = modelName.Split(' ')[0];
            var key = "marka:" + markaName+ ",model:" + modelName;
            if (Cache.Contains(key))
                return (string)Cache[key];

            var url = Generator.ModelImage(urlHelper, markaName, modelName);
            Cache.Add(key, url, DateTimeOffset.Now.AddHours(6));
            return url;
        }
    }
}