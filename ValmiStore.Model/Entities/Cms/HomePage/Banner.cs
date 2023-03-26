using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.HomePage
{
    public class Banner
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }

        public LString Url { get; set; }
        public int Height { get; set; }
        public int OnPage { get; set; }

        public int InstanceId { get; set; }
        public int FieldId { get; set; }

        public bool ForGrossOnly { get; set; }

        public bool ForRetailOnly { get; set; }
        public bool ForOrderSummury { get; set; }

        public LBoolean ForLanguage;
    }
}
