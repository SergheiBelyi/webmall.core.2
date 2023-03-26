using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.ViewModel;
using Webmall.UI.ViewModel.News;

namespace Webmall.UI.Controllers
{
    public class NewsController : Controller
    {

        // ReSharper disable once InconsistentNaming
        private const int PAGE_SIZE = 10;
        private readonly ICmsRepository _cmsRepository;

        public NewsController(ICmsRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public ActionResult Index(string category, string id, GridViewOptions options)
        {
            var user = SessionHelper.CurrentUser;
            options.AllowPageSizeSelection = false;
            options.PageSize = PAGE_SIZE;
            ViewBag.NewsType = category;
            var catalog = _cmsRepository.GetCatalogNews(PAGE_SIZE);
            var selectedCategory = catalog.FirstOrDefault(i => i.Slug == category) ?? catalog.FirstOrDefault() ?? new NewsCategory();
            var allNews = selectedCategory.Items ?? new NewsTracker(PAGE_SIZE);// _cmsRepository.GetNews(PAGE_SIZE);
            var tracker = allNews.GetRolesTracker(user?.Categories); 

            if (string.IsNullOrEmpty(id))
            {
                var model = new NewsListViewModel
                {
                    Category = selectedCategory,
                    Categories = catalog,
                    Data = new GridViewModel<NewsArticle>()
                    {
                        List = tracker.GetPage(tracker, options.CurrentPage),
                        TotalPages = (allNews.Count - 1) / options.PageSize + 1,
                        CurrentPage = options.CurrentPage,
                        AllowPageSizeSelection = false,
                        CurrentContent = "News"
                    }
                };
                model.BreadCrumbs.Add(new BreadCrumbsModel { Name = selectedCategory.Name, Url = Url.Action("Index", "News", new { category = selectedCategory.Slug, id = "" }) });

                //var tmp = allNews.FirstOrDefault(i => i.Id == id)?.FullText.ToString();
                //ViewData["NewsText"] = Request.ApplicationPath != null && Request.ApplicationPath.Length > 1 ? tmp?.Replace("/UserFiles/", Request.ApplicationPath + "/UserFiles/") : tmp;

                return View(model);
            }

            var article = tracker.FirstOrDefault(i => i.Id == id || i.Url == id);
            if (article == null)
                return new HttpNotFoundResult();
            var index = tracker.IndexOf(article);
            if (index > 0)
                article.NextId = string.IsNullOrEmpty(tracker[index - 1].Url) ? tracker[index - 1].Id : tracker[index - 1].Url;
            if (index < tracker.Count - 1)
                article.PrevId = string.IsNullOrEmpty(tracker[index + 1].Url) ? tracker[index + 1].Id : tracker[index + 1].Url;

            ViewBag.Title = article.Title;
            ViewBag.Keywords = article.Keywords;
            ViewBag.Description = article.Description;

            var articleModel = new NewsArticleViewModel { Article = article, Category = selectedCategory, Categories = catalog };
            articleModel.BreadCrumbs.Add(new BreadCrumbsModel { Name = selectedCategory.Name, Url = Url.Action("Index", "News", new { category = selectedCategory.Slug, id = "" }) });
            articleModel.BreadCrumbs.Add(new BreadCrumbsModel { Name = article.Header, Url = Url.Action("Index", "News", new { category = selectedCategory.Slug, id = article.Url })});
            return View("Show", articleModel);
        }

        [HttpPost]
        public ActionResult GetHomeInfo(string id)
        {
            var model = _cmsRepository.GetCatalogNews(10);
            var data = model.FirstOrDefault(i => i.Id == id);
            return View(data);
        }
    }
}
