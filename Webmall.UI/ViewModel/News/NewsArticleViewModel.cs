using System.Collections.Generic;
using Webmall.Model.Entities.Cms.NewsData;

namespace Webmall.UI.ViewModel.News
{
    public class NewsArticleViewModel
    {
        public NewsCategory Category { get; set; }
        public List<NewsCategory> Categories { get; set; }
        public NewsArticle Article { get; set; }
        public List<BreadCrumbsModel> BreadCrumbs { get; set; } = new List<BreadCrumbsModel>();
    }
}