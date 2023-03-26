using System.Collections.Generic;
using Newtonsoft.Json;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Models.Catalog
{
    public class FilterModel
    {
        //public string Group { get; set; }
        public string[] SelectedGroups { get; set; } = { };
        public string[] SelectedProducers { get; set; } = { };
        public string[] SelectedProperties { get; set; } = { };
        
        public int? PriceMin { get; set; }
        public int? PriceMax { get; set; }
        
        public int? ModifId { get; set; }

        /// <summary>
        /// Признак показа блока поиск в найденном
        /// </summary>
        public bool ShowSearchFilter { get; set; } = false;

        /// <summary>
        /// Поисковая строка
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Поисковая строка "Искать в найденном"
        /// </summary>
        public string AddQuery { get; set; }

        // ----------------------------------------------- Результирующие поля по итогам выборки
        [JsonIgnore]
        public List<Group> Categories { get; set; } = new List<Group>();

        [JsonIgnore]
        public List<Producer> Brands { get; set; } = new List<Producer>();

        [JsonIgnore]
        public List<GroupProperty> WareProperties { get; set; } = new List<GroupProperty>();

        [JsonIgnore]
        public bool ShowPriceFilter { get; set; }

        public FilterOptions FilterOptions { get; set; }

        public bool AutoSubmit { get; set; }
        public bool ShowAllSections { get; set; }
    }
}
