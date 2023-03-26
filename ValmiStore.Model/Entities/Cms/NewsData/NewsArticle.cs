using System;
using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.PersonalMenu;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms.NewsData
{
    public class NewsArticle : SeoBase
    {
        public string Id { get; set; }
        public LString Header { get; set; }
        public LString ShortText { get; set; }
        public LString FullText { get; set; }
        public int Sort { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }

        public string NextId { get; set; }
        public string PrevId { get; set; }

        public DateTime Date { get; set; }
        public bool SendForSubscribers { get; set; }

        public bool ForGrossOnly { get; set; }
        public bool ForRetailOnly { get; set; }
        public List<UserRolesCustom> Roles { get; set; }
    }
}