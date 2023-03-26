using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms
{
    public class HeaderNav
    {
        public LString Name { get; set; }
        public LString Url { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
    }
}
