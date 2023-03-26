using System.Linq;
using System.Web.Mvc;
using ViewRes;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;

namespace Webmall.UI.Controllers
{
    public class PromotionsController : Controller
    {

        // ReSharper disable once InconsistentNaming
        private const int PAGE_SIZE = 10;
        private readonly ICmsRepository _cmsRepository;

        public PromotionsController(ICmsRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public ActionResult Index(string id, GridViewOptions options)
        {
            options.AllowPageSizeSelection = false;
            options.PageSize = PAGE_SIZE;
            ViewBag.NewsType = SharedResources.Promotions;
            var marketingActions = new string[0];
            var allNews = _cmsRepository.GetPromos(marketingActions, PAGE_SIZE);
            var tracker = SessionHelper.IsGross
                ? allNews.GrossTracker
                : allNews.RetailTracker;

            if (string.IsNullOrEmpty(id))
            {
                var model = new GridViewModel<NewsArticle>
                {
                    List = tracker.GetPage(tracker, options.CurrentPage),
                    TotalPages = allNews.Count / options.PageSize + 1,
                    CurrentPage = options.CurrentPage,
                    AllowPageSizeSelection = false,
                };

                return View(model);
            }

            var item = tracker.FirstOrDefault(i => i.Id == id || i.Url == id);
            if (item == null)
                return new HttpNotFoundResult();
            var index = tracker.IndexOf(item);
            if (index > 0)
                item.NextId = string.IsNullOrEmpty(tracker[index - 1].Url) ? tracker[index - 1].Id : tracker[index - 1].Url;
            if (index < tracker.Count - 1)
                item.PrevId = string.IsNullOrEmpty(tracker[index + 1].Url) ? tracker[index + 1].Id : tracker[index + 1].Url;

            ViewBag.Title = item.Title;
            ViewBag.Keywords = item.Keywords;
            ViewBag.Description = item.Description;

            return View("Show", item);
        }

    }
}
