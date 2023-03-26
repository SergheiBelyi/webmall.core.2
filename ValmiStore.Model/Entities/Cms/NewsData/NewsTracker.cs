using System.Collections.Generic;
using System.Linq;

namespace Webmall.Model.Entities.Cms.NewsData
{
    public class NewsTracker : List<NewsArticle>
    {
        private readonly int _pageSize = 10;

        public NewsTracker() { }

        public NewsTracker(IEnumerable<NewsArticle> news, int? pageSize = null)
        {
            AddRange(news);
            if (pageSize.HasValue)
                _pageSize = pageSize.Value;
        }

        public NewsTracker(int pageSize)
        {
            _pageSize = pageSize;
        }

        NewsTracker _grossNews = null;

        public NewsTracker GrossTracker => _grossNews ?? (_grossNews = new NewsTracker(this.Where(i => i.ForRetailOnly == false).OrderByDescending(i => i.Sort).ThenByDescending(i => i.Date)));

        NewsTracker _retailNews = null;
        public NewsTracker RetailTracker => _retailNews ?? (_retailNews = new NewsTracker(this.Where(i => i.ForGrossOnly == false).OrderByDescending(i => i.Sort).ThenByDescending(i => i.Date)));

        public NewsTracker GetRolesTracker(string[] roles) => new NewsTracker(this.Where(i => i.Roles == null || roles == null || i.Roles.Any(r => roles.Contains(r.Code))).OrderByDescending(i => i.Sort).ThenByDescending(i => i.Date));


        public void Refresh()
        {
            _grossNews = _retailNews = null;
        }

        public List<T> GetPage<T>(IEnumerable<T> list, int? aPage)
        {
            int page = aPage ?? 1;
            if (page < 1)
                page = 1;
            return list.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
        }
    }
}
