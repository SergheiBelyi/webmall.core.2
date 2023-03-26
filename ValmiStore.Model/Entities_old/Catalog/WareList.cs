using System.Collections.Generic;
using System.Web.Mvc;

namespace ValmiStore.Model.Entities.Catalog
{
    public class WareList : List<Ware>
    {
        /// <summary>
        /// Общее количество найденных товаров
        /// </summary>
        public int TotalFound;

        /// <summary>
        /// Список найденных брэндов
        /// </summary>
        public List<SelectListItem> BrandList = new List<SelectListItem>();

        /// <summary>
        /// Список найденных групп
        /// </summary>
        public List<SelectListItem> GroupList = new List<SelectListItem>();
    }
}