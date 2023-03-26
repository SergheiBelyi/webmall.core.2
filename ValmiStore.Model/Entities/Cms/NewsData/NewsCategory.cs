namespace Webmall.Model.Entities.Cms.NewsData
{
    public class NewsCategory
    {
        public NewsCategory()
        {
            Items = new NewsTracker();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
        public NewsTracker Items { get; set; }

    }
}