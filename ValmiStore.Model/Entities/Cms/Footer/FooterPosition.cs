using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.Footer
{
    public class FooterPosition
    {
        public int OrderNumber { get; set; }
        public LString Title { get; set; }
        public LString Url { get; set; }
        public bool ForGrossOnly { get; set; }
        public bool ForRetailOnly { get; set; }
    }
}
