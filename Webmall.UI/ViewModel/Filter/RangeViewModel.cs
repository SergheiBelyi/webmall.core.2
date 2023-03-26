using Webmall.UI.ViewModel.Common;

namespace Webmall.UI.ViewModel.Filter
{
    public class RangeViewModel : FilterSectionViewModel
    {
        public string NameMin;
        public int? Min;
        public int? MinSelected;
        public string NameMax;
        public int? Max;
        public int? MaxSelected;
        public int Step = 10;
    }
}