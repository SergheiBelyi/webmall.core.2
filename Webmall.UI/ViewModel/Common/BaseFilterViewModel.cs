using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace Webmall.UI.ViewModel.Common
{
    public class BaseFilterViewModel
    {
        public bool AutoSubmit { get; set; } = false;
        public List<FilterSectionViewModel> Sections { get; set; } = new EditableList<FilterSectionViewModel>();
    }
}
