using System.Collections.Generic;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.UI.Core;

namespace Webmall.UI.ViewModel.News
{
    public class NewsListViewModel
    {
        public NewsCategory Category { get; set; }
        public List<BreadCrumbsModel> BreadCrumbs { get; set; } = new List<BreadCrumbsModel>();
        public List<NewsCategory> Categories { get; set; }
        public GridViewModel<NewsArticle> Data { get; set; }
    }
}