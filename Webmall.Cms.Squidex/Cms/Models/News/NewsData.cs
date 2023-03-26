using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.News
{
    public class NewsData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Category;
        [JsonConverter(typeof(InvariantConverter))]
        public DateTime Date;
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
        public LString Header;
        public LString Short;
        public LString Full;
        [JsonConverter(typeof(InvariantConverter))]
        public int Sort;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsForMailing;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsGrossOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRetailOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image;
        
        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;
    }
}
