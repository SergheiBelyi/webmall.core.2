using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Informer
{
    public class InformerData : CmsItemEntity
    {
        public LString Name;
        [JsonConverter(typeof(InvariantConverter))]
        public DateTime DateStart;
        [JsonConverter(typeof(InvariantConverter))]
        public DateTime DateEnd;
        public LString Url;
        public LBoolean ForLanguage;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsGrossOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRetailOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] ImageMob;
    }
}
