using System.Collections.Generic;
using Newtonsoft.Json;

namespace Webmall.Model.Entities_old
{
    public class FilterOptions
    {
        public string Group { get; set; }
        public string[] Groups { get; set; } = { };
        public string[] Producers { get; set; } = { };
        [JsonIgnore]
        public string[] Properties { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int? ModifId { get; set; }

        /// <summary>
        /// Только товар в наличии на складе
        /// </summary>
        public bool? OnlyOnStock { get; set; }

        /// <summary>
        /// Только процененный товар (цена отличная от 0)
        /// </summary>
        public bool? OnlyWithPrice { get; set; }

        /// <summary>
        /// Признак показа акционного товара
        /// </summary>
        public bool? OnlySpecials { get; set; }

        /// <summary>
        /// Признак показа распродажи
        /// </summary>
        public bool? OnlySales { get; set; }

        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Фильтр по категориям акционных товаров (Группы Case)
        /// </summary>
        public string ACId { get; set; }

        /// <summary>
        /// Поисковая строка
        /// </summary>
        public string SearchString { get; set; }

        /// <summary>
        /// Тип поиска
        /// </summary>
        public int? SearchType { get; set; }

        // ----------------------------------------------- Результирующие поля по итогам выборки
        [JsonIgnore]
        public List<ValmiStore.Model.Entities.Group> Categories { get; set; } = new List<ValmiStore.Model.Entities.Group>();

        [JsonIgnore]
        public List<ValmiStore.Model.Entities.Producer> Brands { get; set; } = new List<ValmiStore.Model.Entities.Producer>();

        [JsonIgnore]
        public List<ValmiStore.Model.Entities.WareProperty> WareProperties { get; set; } = new List<ValmiStore.Model.Entities.WareProperty>();

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        [JsonIgnore]
        public bool ShowPriceFilter => false; // MaxPrice < int.MaxValue && MaxPrice > 0;
    }
}
