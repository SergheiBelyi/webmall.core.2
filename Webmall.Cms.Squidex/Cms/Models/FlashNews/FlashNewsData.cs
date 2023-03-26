using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.FlashNews
{
    public class FlashNewsData
    {
        public LString Name;
        [JsonConverter(typeof(InvariantConverter))]
        public DateTime DateStart;
        [JsonConverter(typeof(InvariantConverter))]
        public DateTime DateEnd;
        public LString Url;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsGrossOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRetailOnly;

    }
}
