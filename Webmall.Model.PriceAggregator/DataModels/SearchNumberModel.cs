using System;
using System.Text.Json.Serialization;
using Webmall.Model.PriceAggregator.DataModels;
using Webmall.Model.PriceAggregator.DataModels.Product;

namespace SERP.Product.Api.Domain.Models
{
    //public interface ISearchable
    //{
    //    public string SearchNumber { get; set; }
    //}
    // SearchNumber
    /// <summary>
    /// Поисковые номера
    /// </summary>
    public class SearchNumberModel : IAuditable//, ISearchable
    {
        /// <summary>
        /// Идентификатор поискового номера
        /// </summary>
        public int SearchNumberId { get; set; } // SearchNumberId (Primary key)

        /// <summary>
        /// Код товара
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Значение поискового номера
        /// </summary>
        public string SearchNumber { get; set; } // SearchNumber (length: 100)

        /// <summary>
        /// Тип базового номера
        /// </summary>
        public int BaseNumberTypeId { get; set; } // BaseNumberTypeId

        /// <summary>
        /// Момент создания
        /// </summary>
        public DateTime? CreatedDateTime { get; set; } // CreatedDateTime

        /// <summary>
        /// Кто создал
        /// </summary>
        public string CreatedBy { get; set; } // CreatedBy (length: 150)

        /// <summary>
        /// Момент последнего изменения
        /// </summary>
        public DateTime? UpdatedDateTime { get; set; } // UpdatedDateTime

        /// <summary>
        /// Кто последним изменил
        /// </summary>
        public string UpdatedBy { get; set; } // UpdatedBy (length: 150)

        // Foreign keys

        /// <summary>
        /// Parent BaseNumberType pointed by [SearchNumber].([BaseNumberTypeId]) (FK_SearchNumber_BaseNumberType)
        /// </summary>
        [JsonIgnore]
        public virtual BaseNumberTypeModel BaseNumberType { get; set; } // FK_SearchNumber_BaseNumberType
        
        /// <summary>
        /// Parent Product pointed by [SearchNumber].([ProductId]) (FK_SearchNumber_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_SearchNumber_Product

        public SearchNumberModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
