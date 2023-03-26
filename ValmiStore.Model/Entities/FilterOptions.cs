using Webmall.Model.Entities.Catalog.Filters;

namespace Webmall.Model.Entities
{
    public class FilterOptions
    {
        public string Search { get; set; }
        public int SearchCriteria { get; set; }
        public string WareGroupId { get; set; }

        public Visibility[] Visibility { get; set; } = new Visibility[0];

        public Actions[] Actions { get; set; } = new Actions[0];

        public string[] Producers { get; set; }
        public string[] Properties { get; set; }
        public string MarkaId { get; set; }
        public string ModelId { get; set; }
        public string ModifId { get; set; }
        public int? PriceMax { get; set; }
        public int? PriceMin { get; set; }
        public int? MinReturnTerm { get; set; }
        public string[] Warehouses { get; set; }
        public int? MinDeliveryRating { get; set; }
        public int? MinQnt { get; set; }
        public int? MaxDeliveryTerm { get; set; }
        public int? SalePriceMax { get; set; }
        public int? SalePriceMin { get; set; }
        public bool OnlyWithPhoto { get; set; }
        
        public string AddQuery { get; set; }
    }
}
