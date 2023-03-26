using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ValmiStore.Model.Entities;
using Webmall.Model;
using Webmall.Model.CoreHelpers;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Models;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class ContentManagementController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IReferenceRepository _referenceRepository;
        private readonly ICmsRepository _cmsRepository;
        private static readonly XNamespace Ns = @"http://www.sitemaps.org/schemas/sitemap/0.9";

        public ContentManagementController(ICatalogRepository catalogRepository, IReferenceRepository referenceRepository, ICmsRepository cmsRepository)
        {
            _catalogRepository = catalogRepository;
            _referenceRepository = referenceRepository;
            _cmsRepository = cmsRepository;
        }

        [GrantAccessFor((long)UserRoles.ContentManager)]
        public ActionResult Index(GridViewOptions options)
        {
            var model = new GroupContentInfo { Groups = new GridViewModel<Group>() };
            /*if (options == null)
                options = new GridViewOptions();

            var tmp = _catalogRepository.GetWaregroups(UserPreferences.CurrentCulture);
            foreach (var group in tmp)
            {
                group.OrderName = $"{@group.Order:D4}";
                GenerateGroupNumber(tmp, group, group.ParentId);
            }
            model.Groups = tmp.AsGridView(ControllerContext, options, null);*/
            return View(model);
        }

        // ReSharper disable PossibleMultipleEnumeration
        private static void GenerateGroupNumber(IEnumerable<Group> list, Group group, string parentId)
        {
            if (parentId == null) return;

            var parent = list.FirstOrDefault(i => i.Id == parentId);
            if (parent == null)
                return;
            group.OrderName = $"{parent.Order:D4}" + "\\" + group.OrderName;
            GenerateGroupNumber(list, group, parent.ParentId);
        }
        // ReSharper restore PossibleMultipleEnumeration

        [ValidateInput(false)]
        [GrantAccessFor((long)UserRoles.ContentManager)]
        public JsonResult UpdateGroup(string groupId, Group activeGroup) //string pageHeader, string keywords, string description, string themeText, string url)
        {
            activeGroup.Id = groupId;
            //_catalogRepository.UpdateWaregroup(UserPreferences.CurrentCulture, activeGroup);

            var jResult = new JsonResult
            {
                Data = activeGroup,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
            return jResult;
            //            return new Group {Id = groupId, PageHeader = pageHeader, Keywords = keywords, Description = description, ThemeText = themeText, URL = url};
        }

        [GrantAccessFor((long)UserRoles.ContentManager)]
        public ActionResult SiteMap()
        {
            return View();
        }

        //[HttpPost]
        //[GrantAccessFor((long)UserRoles.ContentManager)]
        //public FileResult SiteMapGenerate()
        //{

        //    var siteIndexXml = new XElement(Ns + "sitemapindex");
        //    var items = _referenceRepository.GetSiteMap();

        //    using (var outputMemStream = new MemoryStream())
        //    {
        //        var zipStream = new ZipOutputStream(outputMemStream);

        //        zipStream.SetLevel(3);

        //        int counter = 0, fileCounter = 1;
        //        string xmlStr;
        //        var xml = new XElement(Ns + "urlset");


        //        foreach (var item in items)
        //        {
        //            xml.Add(GetSiteMapAutoUrl(HttpUtility.UrlEncode(item.Loc), null, "monthly", "0.3"));
        //            ++counter;
        //            if ((counter % 40000) == 0 || counter == items.Count || ((counter % 1000) == 0 && XmlToStr(xml).Length >= 8 * 1024 * 1024))
        //            {
        //                xmlStr = XmlToStr(xml);
        //                string fileName = AddSiteMapToZip(fileCounter, zipStream, xmlStr);

        //                siteIndexXml.Add(new XElement(Ns + "sitemap",
        //                    new XElement(Ns + "loc", fileName),
        //                    new XElement(Ns + "lasmod", XmlConvert.ToString(DateTime.Now, XmlDateTimeSerializationMode.Local))));

        //                fileCounter++;
        //                xml = new XElement(Ns + "urlset");
        //            }
        //        }

        //        counter = 0;
        //        var cmsElements = GetCmsUrlElements().Union(GetFixedUrlElements()).ToList();
        //        foreach (var item in cmsElements)
        //        {
        //            xml.Add(item);
        //            ++counter;
        //            if ((counter % 40000) == 0 || counter == cmsElements.Count || ((counter % 1000) == 0 && XmlToStr(xml).Length >= 8 * 1024 * 1024))
        //            {
        //                xmlStr = XmlToStr(xml);
        //                string fileName = AddSiteMapToZip(fileCounter, zipStream, xmlStr);

        //                siteIndexXml.Add(new XElement(Ns + "sitemap",
        //                    new XElement(Ns + "loc", fileName),
        //                    new XElement(Ns + "lasmod", XmlConvert.ToString(DateTime.Now, XmlDateTimeSerializationMode.Local))));

        //                fileCounter++;
        //                xml = new XElement(Ns + "urlset");
        //            }
        //        }

        //        xmlStr = XmlToStr(siteIndexXml);
        //        var newEntry = new ZipEntry("sitemap_index.xml") { DateTime = DateTime.Now };
        //        var bytes = Encoding.UTF8.GetBytes(xmlStr);

        //        zipStream.PutNextEntry(newEntry);
        //        using (var siteIndexStream = new MemoryStream())
        //        {
        //            // Заливка его в несжатый поток
        //            siteIndexStream.Write(bytes, 0, bytes.Length);
        //            siteIndexStream.Seek(0, SeekOrigin.Begin);
        //            // Запись в архив несжатого потока
        //            StreamUtils.Copy(siteIndexStream, zipStream, new byte[4096]);
        //        }
        //        zipStream.CloseEntry();

        //        zipStream.IsStreamOwner = false; // False stops the Close also Closing the underlying stream.
        //        zipStream.Close(); // Must finish the ZipOutputStream before using outputMemStream.

        //        var fileContent = File(outputMemStream.ToArray(), "application/zip");

        //        var tmpContentDisposition = "filename=sitemap.zip";
        //        Response.AppendHeader("content-disposition", tmpContentDisposition);

        //        return fileContent;
        //    }

        //}

        private static string AddSiteMapToZip(int fileCounter, ZipOutputStream zipStream, string xmlStr)
        {
            const bool compress = false;
            var sitemapFileName = $"sitemap{fileCounter}.xml";
            var newEntry = new ZipEntry(sitemapFileName + (compress ? ".gz" : "")) { DateTime = DateTime.Now };
            zipStream.PutNextEntry(newEntry);

            using (var outputMemStream = new MemoryStream())
            {
                // Получение байт-массива
                var bytes = Encoding.UTF8.GetBytes(xmlStr);

                //if (compress)
                //{
                //    // Определение сжатого потока и запись туда байт массива
                //    var compressionStream = new MemoryStream();
                //    var gzipStream = new GZipStream(compressionStream, CompressionMode.Compress);
                //    gzipStream.Write(bytes, 0, bytes.Length);
                //    compressionStream.Seek(0, SeekOrigin.Begin);
                //    // Запись в архив сжатого потока
                //    StreamUtils.Copy(compressionStream, zipStream, new byte[4096]);
                //    gzipStream.Close();
                //}
                //else
                {
                    // Заливка его в несжатый поток
                    outputMemStream.Write(bytes, 0, bytes.Length);
                    outputMemStream.Seek(0, SeekOrigin.Begin);
                    // Запись в архив несжатого потока
                    StreamUtils.Copy(outputMemStream, zipStream, new byte[4096]);
                }
            }
            zipStream.CloseEntry();
            return sitemapFileName;
        }

        private static string XmlToStr(XElement xml)
        {
            string xmlStr;
            using (var str = new StringWriterWithEncoding(Encoding.UTF8))
            {
                xml.Save(str);
                xmlStr = str.ToString();
                //Log.DebugFormat("RDL Content: {0}", rdlContent);
                //return rdlContent;
            }
            return xmlStr;
        }

        private XElement GetSiteMapAutoUrl(string loc, string lasmod, string changefreq, string priority)
        {
            loc = loc.Replace("*", "%40").Replace("%2f", "/");
            var url = Request.Url;
            Debug.Assert(url != null, "url != null");
            var fullLoc = $"{url.Scheme}://{url.Host}{(url.Port == 80 ? "" : ":" + url.Port)}{Url.Content("~/")}{UserPreferences.CurrentCultureLink}/{Url.Content("Auto")}{loc}";
            return GetSiteMapElement(lasmod, changefreq, priority, fullLoc);
        }

        private static XElement GetSiteMapElement(string lasmod, string changefreq, string priority, string loc)
        {
            return new XElement(Ns + "url",
                new XElement(Ns + "loc", loc),
                string.IsNullOrEmpty(lasmod) ? null : new XElement(Ns + "lasmod", lasmod),
                string.IsNullOrEmpty(changefreq) ? null : new XElement(Ns + "changefreq", changefreq),
                string.IsNullOrEmpty(priority) ? null : new XElement(Ns + "priority", priority));
        }

        private List<XElement> GetCmsUrlElements()
        {
            var url = Request.Url;
            Debug.Assert(url != null, "url != null");

            // NewsList 
            var result = new List<XElement>();

            // Новости
            foreach (var news in _cmsRepository.GetNews())
            {
                AddSiteMapElement(result, url, Url.Action("Show", "News", new { id = string.IsNullOrEmpty(news.Url) ? news.Id.ToString(CultureInfo.InvariantCulture) : news.Url }));
            }

            // Акции
            foreach (var news in _cmsRepository.GetPromos(new string[0]))
            {
                AddSiteMapElement(result, url,
                    Url.Action("Show", "Promotions", new { id = string.IsNullOrEmpty(news.Url) ? news.Id.ToString(CultureInfo.InvariantCulture) : news.Url }));
            }

            // Каталоги производителей
            foreach (var cat in _cmsRepository.GetExternalCatalog())
            {
                AddSiteMapElement(result, url, Url.Action("Index", "OriginalCatalog", new { Id = cat.Slug }));
            }

            //// альтернативные дом. страницы
            //foreach (var page in CmsData.GetAlternativeHomePages().Where(i => !string.IsNullOrEmpty(i.URL)))
            //{
            //    AddSiteMapElement(result, url, Url.Content("~/" + page.URL));
            //}

            // Верхнее меню
            //if (!string.IsNullOrEmpty(ConfigHelper.HelpUrl))
            //{
            //    AddSiteMapElement(result, url, Url.Content(ConfigHelper.HelpUrl));
            //}
            //if (!string.IsNullOrEmpty(ConfigHelper.AboutCompanyUrl))
            //{
            //    AddSiteMapElement(result, url, Url.Content(ConfigHelper.AboutCompanyUrl));
            //}
            //if (!string.IsNullOrEmpty(ConfigHelper.ServiceUrl))
            //{
            //    AddSiteMapElement(result, url, Url.Content(ConfigHelper.ServiceUrl));
            //}
            //if (!string.IsNullOrEmpty(ConfigHelper.ProvidersUrl))
            //{
            //    AddSiteMapElement(result, url, Url.Content(ConfigHelper.ProvidersUrl));
            //}
            //if (!string.IsNullOrEmpty(ConfigHelper.GroupAutoMoldovaUrl))
            //{
            //    AddSiteMapElement(result, url, Url.Content(ConfigHelper.GroupAutoMoldovaUrl));
            //}
            //if (!string.IsNullOrEmpty(ConfigHelper.ContactsUrl))
            //{
            //    AddSiteMapElement(result, url, Url.Content(ConfigHelper.ContactsUrl));
            //}

            // Footer
            //var firstColumn = CmsData.GetMainMenu().FirstOrDefault();
            //if (firstColumn != null)
            //{
            //    foreach (var item in firstColumn.Children.Where(i => i.ForGrossOnly != true))
            //    {
            //        // ReSharper disable once Mvc.ActionNotResolved
            //        // ReSharper disable once Mvc.ControllerNotResolved
            //        var pageUrl = item.URL.Contains(Page.Extension) ? Url.Action("Index", "RouteHandler", new { alias = item.URL }, null) : Url.Content("~/" + item.URL);
            //        AddSiteMapElement(result, url, pageUrl);
            //    }
            //}

            // Groups
            //var currentParentLink = UserPreferences.CurrentCultureLink + "/Catalog/";
            //AddGroupToSiteMap(_catalogRepository.GetWaregroups(UserPreferences.CurrentCulture), currentParentLink, result, url);
            return result.Distinct(new SiteMapComparer()).ToList();
        }


        private void AddGroupToSiteMap(IEnumerable<Group> groups, string parentLink, List<XElement> result, Uri url)
        {
            foreach (var group in groups)
            {
                AddSiteMapElement(result, url, Url.Content("~/" + parentLink + group.Url), "weekly", "0.5");
                if (group.SubGroup != null)
                    AddGroupToSiteMap(group.SubGroup, parentLink, result, url);
            }
        }

        private void AddSiteMapElement(List<XElement> result, Uri url, string relativeUrl, string changeFreq = null, string priority = "0.3")
        {
            var fullLoc = $"{url.Scheme}://{url.Host}{(url.Port == 80 ? "" : ":" + url.Port)}{relativeUrl}";
            result.Add(GetSiteMapElement(DateTime.Now.ToString("yyyy-MM-dd"), changeFreq, priority, fullLoc));
        }

        private List<XElement> GetFixedUrlElements()
        {
            var url = Request.Url;
            Debug.Assert(url != null, "url != null");
            // NewsList 
            var result = new List<XElement>();
            AddSiteMapElement(result, url, Url.Content("~"), "weekly");
            if (ConfigHelper.AllowServiceBooking)
                AddSiteMapElement(result, url, Url.Action("Index", "ServiceBooking"), "weekly");
            return result;
        }
    }
}
