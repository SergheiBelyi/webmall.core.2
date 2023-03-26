using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ValmiStore.Model.Entities;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.ViewModel;

namespace Webmall.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly ICmsRepository _cmsRepository;
        static readonly Random RandomGenerator = new Random();

        //private readonly ILaximoRepository _laximoRepository;

        public HomeController(ICatalogRepository catalogRepository, ICmsRepository cmsRepository)
        {
            _catalogRepository = catalogRepository;
            _cmsRepository = cmsRepository;
        }

        private Home PrepareHomeModel()
        {
            var model = new Home
            {
                SeoTemplate = _cmsRepository.GetSeoTemplate("home"),
                FlashNews = _cmsRepository.GetFlashNewsMain()
                //PopularGroups = _catalogRepository.GetPopularWaregroups(UserPreferences.CurrentCulture)
            };

            ViewBag.HeaderTitle = ViewData["PageTitle"] = model.SeoTemplate.Title.ToString();
            ViewBag.Description = ViewData["Description"] = model.SeoTemplate.Description.ToString();
            ViewBag.Keywords = ViewData["Keywords"] = model.SeoTemplate.Keywords.ToString();

            //ViewBag.BlockPayUpTo = "До блокировки 1 день - оплатить до 12:00 02.10.2021 test alex";
            return model;
        }

        public ActionResult Index(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                url = url.Replace("-and-", "&").Replace("-eq-", "=").Replace("-qst-", "?");
                return Redirect(url);
            }
            var model = PrepareHomeModel();
            return View("Index",model); 
        }

        public ActionResult RenderLazyNews()
        {
            return View("LazyNewsSection");
        }

        public ActionResult RenderNews (string type)
        {
            var catalogNews = _cmsRepository.GetCatalogNews(10);

            var model = catalogNews.FirstOrDefault(i => i.Slug == type) ?? catalogNews.FirstOrDefault();
            return View("NewsSection", model);
        }

        //public ActionResult RenderPromos()
        //{
        //    var catalogNews = _cmsRepository.GetCatalogNews(10);

        //    var model = catalogNews.FirstOrDefault(i => i.Slug == "promo") ?? catalogNews.FirstOrDefault();
        //    return View("NewsSection", model);
        //}

        public ActionResult RenderBanners()
        {
            var isGross = SessionHelper.IsGross;
            var model = _cmsRepository.GetBanners()
                .Where(i=>i.ForLanguage == true && isGross && !i.ForRetailOnly || !isGross && !i.ForGrossOnly).ToList();
            var rnd = RandomGenerator.Next(model.Count);
            model = model.Skip(rnd).Union(model.Take(rnd)).ToList();
            return View("Banners", model);
        }

        [HttpPost]
        public JsonResult GetCitys()
        {
            var shops = _cmsRepository.GetShops("motex-item").OrderBy(i => i.Sort);
            var citys = new List<Citys>();
            foreach(var shop in shops)
            {
                var item = new Citys
                {
                    Name = shop.Name,
                    ShortName = shop.ShortName,
                    Lat = shop.Location.latitude,
                    Lot = shop.Location.longitude,
                    Id = shop.Id
                };
                citys.Add(item);
            }

            return new JsonResult { Data = new { citys }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}