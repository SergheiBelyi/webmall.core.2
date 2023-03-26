using System.Web.Mvc;
using Webmall.Model.Entities.Catalog;
using Webmall.UI.Core;

namespace Webmall.UI.Models.Catalog
{
    public class CatalogWaresModel
    {
        public GridViewModel<WareListItem> Wares { get; set; }

        public int? TotalAmountWares => Wares.TotalRows;

        /// <summary>
        /// Список вариантов сортировки товаров
        /// </summary>
        public SelectListItem[] SortList { get; set; }

        public int ViewMode { get; set; }

    }
}