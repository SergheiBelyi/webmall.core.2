using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.CustomerReviews
{
    public class CustomerReviewsData
    {
        public LString CustomerName;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image;
        public LString Short;
        [JsonConverter(typeof(InvariantConverter))]
        public DateTime Date;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsScroll;
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
        public LString Full;

        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;
    }
}
