using System;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms
{
    public class Informer
    {
        public LString Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public LString Url { get; set; }
        public LBoolean ForLanguage;
        public bool ForGrossOnly { get; set; }
        public bool ForRetailOnly { get; set; }
        public string Image { get; set; }
        public string ImageMob { get; set; }
        public string Id { get; set; }
    }
}
