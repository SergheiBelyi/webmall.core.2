using System.Collections.Generic;
using System.Text.Json.Serialization;
using Webmall.Model.PriceAggregator.DataModels.Product;

namespace SERP.Product.Api.Domain.Models
{
    public class UnitModelDTO
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitShortName { get; set; }
        public string UnitRemark { get; set; }
        [JsonIgnore]
        public ICollection<ProductModel> ProductModel { get; set; }
    }
}
