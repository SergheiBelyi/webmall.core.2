using System.Collections.Generic;
using Webmall.Model.Entities.Catalog;
using Webmall.UI.Core;
using Webmall.UI.ViewModel.Common;

namespace Webmall.UI.ViewModel.Brands
{
    public class BrandListViewModel
    {
        //public List<Producer> CurrentLevel { get; set; }
        public List<BreadCrumbsModel> BreadCrumbs { get; set; }
        public BrandFilterOptions FilterOptions { get; set; }
        public BaseFilterViewModel FilterModel { get; set; }
        public GridViewModel<Producer> Data { get; set; }
    }
}