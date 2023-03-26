using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.UI.ViewModel.Common;

namespace Webmall.UI.ViewModel.Filter
{
    public class SelectViewModel : FilterSectionViewModel
    {
        public List<SelectListItem> Options = new List<SelectListItem>();
        public bool IsFilterable { get; set; }  = false;
        public string FilterTitle;
        public bool ShowSelectMoreLink { get; set; }
        public int ShowLimit = 5;
    }
}