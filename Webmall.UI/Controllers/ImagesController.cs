using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using log4net;
using log4net.Config;
using StackExchange.Profiling;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;

namespace Webmall.UI.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ImagesController : Controller
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(ImagesController));

        static ImagesController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

       // readonly IImageRepository _repository;

        //public ImagesController()
        //{
        // //   _repository = repository;
        //}

        //static readonly Dictionary<string, DateTime> CmsImagesTimeStamps = new Dictionary<string, DateTime>(100);
        static readonly Dictionary<string, DateTime> WareImagesTimeStamps = new Dictionary<string, DateTime>(100);
        static readonly Dictionary<string, DateTime> ImagesTimeStamps = new Dictionary<string, DateTime>(100);

        public static void ClearTimeStamps()
        {
            //CmsImagesTimeStamps.Clear();
            WareImagesTimeStamps.Clear();
            ImagesTimeStamps.Clear();
        }

        #region CmsImages

        ///// <summary>
        ///// Handler для вывода изображений из Backend (ShowImage.ashx?...)
        ///// </summary>
        ///// <returns></returns>
        //[OutputCache(Duration = 3600*24*7, Location = OutputCacheLocation.Client)]
        //public FileResult CmsImage()
        //{

        //    Stream imageStream = null;
        //    if (Request.QueryString.Count != 0)
        //    {
        //        var instanceId = int.Parse(Request.QueryString["InstanceId"].Split(",")[0]);
        //        var fieldId = int.Parse(Request.QueryString["FieldId"].Split(",")[0]);
        //        var language = int.Parse(Request.QueryString["Language"].Split(",")[0]);
        //        var indexId = int.Parse(Request.QueryString["IndexId"].Split(",")[0]);

        //        if (!string.IsNullOrEmpty(Request.Headers["If-Modified-Since"]))
        //        {
        //            CultureInfo provider = CultureInfo.InvariantCulture;
        //            DateTime localTime, lastMod = DateTime.Now.AddYears(-1);
        //            if (DateTime.TryParseExact(Request.Headers["If-Modified-Since"], "r", provider, DateTimeStyles.None, out localTime)
        //                || DateTime.TryParseExact(Request.Headers["If-Modified-Since"], "r", CultureInfo.CurrentUICulture, DateTimeStyles.None, out localTime)
        //                || (Request != null
        //                    && Request.UserLanguages != null
        //                    && Request.UserLanguages.Length > 0
        //                    &&
        //                    DateTime.TryParseExact(Request.Headers["If-Modified-Since"], "r", CultureInfo.CreateSpecificCulture(Request.UserLanguages[0].ToLowerInvariant().Trim()),
        //                        DateTimeStyles.None, out localTime)))
        //            {
        //                lastMod = DateTime.ParseExact(Request.Headers["If-Modified-Since"], "r", provider).ToLocalTime();
        //            }
        //            else
        //            {
        //                Log.Debug("Странное значение If-Modified-Since: " + Request.Headers["If-Modified-Since"]);
        //            }
        //            string key = Request.QueryString["InstanceId"] + Request.QueryString["FieldId"] + Request.QueryString["Language"] + Request.QueryString["IndexId"];
        //            DateTime dictionaryValue;
        //            if (CmsImagesTimeStamps.TryGetValue(key, out dictionaryValue))
        //            {
        //                if ((DateTime.Now - lastMod).Days <= 30)
        //                {
        //                    Response.StatusCode = 304;
        //                    Response.StatusDescription = "Not Modified";
        //                    return new FileStreamResult(new MemoryStream(), "image/png");
        //                }
        //            }
        //            else
        //            {
        //                CmsImagesTimeStamps.Add(key, DateTime.Now);
        //            }
        //        }
        //        imageStream = CmsData.GetImageStream(instanceId, fieldId, language, indexId);
        //    }
        //    if (imageStream == null || imageStream.Length == 0)
        //        imageStream = System.IO.File.OpenRead (Server.MapPath("~/Content/images/noCmsImage.jpg"));
        //    Response.Cache.SetCacheability(HttpCacheability.Public);
        //    Response.Cache.SetLastModified(DateTime.Now);
        //    //Response.Cache.SetExpires();
        //    return new FileStreamResult(imageStream, "image/png");
        //}

        //public FileResult GetBrandImage(string id)
        //{
        //    var nd = CmsData.FilterbyAutoItems.SingleOrDefault(i => i.Code == id);
        //    if (nd == null) return Question;
        //    return new FileStreamResult(CmsData.GetImageStream(nd.InstanceId, nd.FieldId, Data.Config.ApplicationSettings.Language, 0), "image/png");
        //}

        //public static bool HasBrandImage(string id)
        //{
        //    return CmsData.FilterbyAutoItems.Any(i => i.Code == id);
        //}

        #endregion CmsImages

        /// <summary>
        /// Return image for Marks
        /// </summary>
        /// <param name="id">MarkId</param>
        /// <returns>PNG Image file</returns>
        //[Route("Marka/{id}")]
        [HttpGet]
        //[ProducesResponseType(typeof(FileResult), 200)]
        public async Task<FileResult> MarkaImage(string id)
        {
            return await GetFileStreamResultAsync("auto/marka", id, "no_car_brand");
        }

        /// <summary>
        /// Return image for Marks
        /// </summary>
        /// <param name="id">MarkId</param>
        /// <returns>PNG Image file</returns>
        //[Route("Marka/{id}")]
        [HttpGet]
        //[ProducesResponseType(typeof(FileResult), 200)]
        public async Task<FileResult> BrandImage(string id)
        {
            return await GetFileStreamResultAsync("brand", id, "_no_parts_brand");
        }

        ///// <summary>
        ///// Return image for Models
        ///// </summary>
        ///// <param name="id">MarkId</param>
        ///// <returns>PNG Image file</returns>
        //[Route("Model/{id}")]
        //[HttpGet]
        ////[ProducesResponseType(typeof(FileResult), 200)]
        //public async Task<FileResult> GetModelImage(string id)
        //{
        //    var basePath = "auto/model";
        //    return GetFileStreamResult(basePath, SearchFolderForMark(basePath, id.Replace("-", "_")), "no_car_model_image");
        //}

        public FileResult Question
        {
            get
            {
                var stream = new MemoryStream(System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/question.png")));
                return new FileStreamResult(stream, "image/png");
            }
        }

        public FileResult Empty
        {
            get
            {
                var stream = new MemoryStream(System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/empty.png")));
                return new FileStreamResult(stream, "image/png");
            }
        }

        public FileResult GetWareImage(string wareId)
        {
            if (!string.IsNullOrEmpty(Request.Headers["If-Modified-Since"]))
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                var lastMod = DateTime.ParseExact(Request.Headers["If-Modified-Since"], "r", provider).ToLocalTime();
                if (WareImagesTimeStamps.TryGetValue(wareId, out _))
                {
                    if ((DateTime.Now - lastMod).Days <= 30)
                    {
                        Response.StatusCode = 304;
                        Response.StatusDescription = "Not Modified";
                        return new FileStreamResult(new MemoryStream(), "image/png");
                    }
                }
                WareImagesTimeStamps.Add(wareId, DateTime.Now);
            }
            using (var repository = (IImageRepository)DependencyResolver.Current.GetService(typeof(IImageRepository)))
            {
                var buffer = CheckEmptyImage(repository.GetWareImage(UserPreferences.CurrentCulture, wareId));
                return ImageArrayToFileResult(buffer);
            }
        }

        public FileResult GetImage(string imageId)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("GetImage"))
            {
                if (string.IsNullOrEmpty(imageId)) return null;
                if (!string.IsNullOrEmpty(Request.Headers["If-Modified-Since"]))
                {
                    try
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;

                        var lastMod =
                            (DateTime.TryParseExact(Request.Headers["If-Modified-Since"], "r", provider, DateTimeStyles.None, out var modifTime) ? modifTime : DateTime.Now).ToLocalTime();
                        if (ImagesTimeStamps.TryGetValue(imageId, out _))
                        {
                            if ((DateTime.Now - lastMod).Days <= 30)
                            {
                                Response.StatusCode = 304;
                                Response.StatusDescription = "Not Modified";
                                return new FileStreamResult(new MemoryStream(), "image/png");
                            }
                            ImagesTimeStamps.Remove(imageId);
                        }
                        ImagesTimeStamps.Add(imageId, DateTime.Now);
                    }
                    catch (Exception e)
                    {
                        Log.Error("GetImage Error", e);
                    }
                }
                using (var repository = (IImageRepository) DependencyResolver.Current.GetService(typeof(IImageRepository)))
                {
                    var buffer = CheckEmptyImage(repository.GetImage(UserPreferences.CurrentCulture, imageId));
                    return ImageArrayToFileResult(buffer);
                }
            }
        }

        private byte[] CheckEmptyImage (byte[] buffer)
        {
            return (buffer == null || buffer.LongLength < 150) ? System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/empty.png")) : buffer;
        }

        private FileResult ImageArrayToFileResult (byte[] buffer)
        {
            var result = new FileStreamResult(new MemoryStream(buffer), "image/png") { FileDownloadName = Guid.NewGuid() + ".png" };
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetLastModified(DateTime.Now);
            return result;
        }

        private async Task<FileResult> GetFileStreamResultAsync(string p, string fileName, string defaultFileName = null, string ext = "png")
        {
            var path = Server.MapPath("~/ExtContent");
            fileName = Path.Combine(path, $"{p}/{fileName}.{ext}");
            if (!System.IO.File.Exists(fileName))
            {
                fileName = Path.Combine(path, $"{p}/{defaultFileName ?? $"default-{Path.GetFileNameWithoutExtension(p)}"}.{ext}");
            }
            if (!System.IO.File.Exists(fileName))
            {
                return new FileStreamResult(new MemoryStream(), "application/octet-stream");
            }
            using (FileStream stream = System.IO.File.Open(fileName, FileMode.Open))
            {
                var result = new byte[stream.Length];
                await stream.ReadAsync(result, 0, (int)stream.Length);
                return ImageArrayToFileResult(result);
                //return ImageArrayToFileResult(System.IO.File.ReadAllBytes(fileName));
            }
            //var stream = new MemoryStream(System.IO.File.ReadAllBytes(fileName));
            //var contentType = MimeMapping.GetMimeMapping(fileName);
            //return new FileStreamResult(stream, contentType ?? "application/octet-stream");
        }

    }
}
