using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ValmiStore.Model.Entities;
using Webmall.UI.Core;

namespace Webmall.UI.Models.Ware
{
    public class WaresCatalogModel
    {
        /// <summary>
        /// Список найденных товаров
        /// </summary>
        public GridViewModel<ValmiStore.Model.Entities.Ware> Wares { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int? TotalAmountWares => Wares.TotalRows;

        public string GroupId { get; set; }
        public List<Group> Groups { get; set; }

        public Group CurrentGroup => Groups?.LastOrDefault();

        public bool? ShowAllWares { get; set; }
        public int? ModifId { get; set; }
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }
        public bool NeedReturnURL { get; set; }
        public bool IsAction { get; set; }
        public bool IsSearchResult { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public string ModifName { get; set; }

        /// <summary>
        /// Признак работы через подбор по авто
        /// </summary>
        public bool IsSelectionByAuto { get; set; } = false;

        /// <summary>
        /// Признак работы через подбор по авто
        /// </summary>
        public bool IsAutoFilter { get; set; }

        /// <summary>
        /// Список вариантов сортировки товаров
        /// </summary>
        public SelectListItem[] SortList { get; set; }

        public int ViewMode { get; set; }

        /// <summary>
        /// Признак разрешения оформления "под заказ"
        /// </summary>
        public bool AllowCustomOrders { get; set; }

        /// <summary>
        /// Признак разрешения добавления в корзину на общем уровне
        /// </summary>
        public bool CanAddToCart { get; set; }

        /// <summary>
        /// Признак разрешения показа розничной цены
        /// </summary>
        public bool ShowRetailPrice { get; set; }

        /// <summary>
        /// Признак выдачи предварительного выбора из списка производителей
        /// </summary>
        public bool BrandPreliminarySelection { get; set; } = true;
    }
}