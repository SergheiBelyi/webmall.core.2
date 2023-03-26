using System.Collections.Generic;
using ValmiStore.Model.Entities;
using Webmall.Model.Entities.Cms.HomePage;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.UI.ViewModel
{
    public class Home
    {
        public string Text { get; set; }
        public List<FlashNews> FlashNews { get; set; }
        public SeoTemplate SeoTemplate { get; set; }
        public List<Group> PopularGroups { get; set; }
    }
}