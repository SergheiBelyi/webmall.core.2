using System;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.HomePage
{
    public class FlashNews
    {
        public LString Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public LString Url { get; set; }
        public bool ForGrossOnly { get; set; }
        public bool ForRetailOnly { get; set; }
    }
}
