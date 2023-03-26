using System;
using System.IO;
using System.Web.Mvc;
using Webmall.Model;
using Webmall.UI.Service.Interfaces;

namespace Webmall.UI.Service.Implementations
{
    public class LocalFilesImageUrlGenerator : IImageUrlGenerator
    {
        private const string ContentPath = "~/ExtContent";

        public string ProducerImage(UrlHelper urlHelper, string producerName)
        {
            var relPath = "brand";
            var filename = GetFileName(urlHelper, relPath, producerName, "no_parts_brand");
            return urlHelper.Content($"{ContentPath}/{relPath}/{filename}");
        }

        public string MarkaImage(UrlHelper urlHelper, string markaName)
        {
            var relPath = "autoImages/marka";
            var filename = GetFileName(urlHelper, relPath, markaName, "no_car_brand");
            return urlHelper.Content($"{ContentPath}/{relPath}/{filename}");
        }

        public string ModelImage(UrlHelper urlHelper, string markaName, string modelName)
        {
            var relPath = "autoImages/model";
            var modelFileName = $"{markaName}/{markaName}_{modelName}";
            var filename = GetFileName(urlHelper, relPath, modelFileName, "no_car_model_image");
            return urlHelper.Content($"{ContentPath}/{relPath}/{(filename.Contains(modelName) ? $"{markaName}/{filename}" : filename)}");
        }

        public string WareImage(UrlHelper urlHelper, string imageId)
        {
            return $"{ConfigHelper.PriceAggrearorImg.TrimEnd('/')}/{imageId}";
        }
        
        private static string GetFileName(UrlHelper urlHelper, string p, string fileName, string defaultFileName = null,
            string ext = "png")
        {
            try
            {
                fileName = fileName?.Trim() ?? "";
                var path = urlHelper.RequestContext.HttpContext.Server.MapPath(ContentPath);
                fileName = Path.Combine(path, $"{p}/{fileName}.{ext}");
                if (File.Exists(fileName))
                    return Path.GetFileName(fileName);
                fileName = Path.Combine(path,
                    $"{p}/{defaultFileName ?? $"default-{Path.GetFileNameWithoutExtension(p)}"}.{ext}");
                return File.Exists(fileName) ? Path.GetFileName(fileName) : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}