using System;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // ProductProperty
    /// <summary>
    /// Свойства товаров
    /// </summary>
    public class ProductProperty
    {
        /// <summary>
        /// Код значения свойства товаров
        /// </summary>
        public int ProductPropertyId { get; set; } // ProductPropertyId (Primary key)

        /// <summary>
        /// Товар
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Значение свойства
        /// </summary>
        public int ProductPropertyValueId { get; set; } // ProductPropertyValueId

        /// <summary>
        /// Примечание
        /// </summary>
        public string ProductPropertyRemark { get; set; } // ProductPropertyRemark

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
        /// Parent ProductPropertyValue pointed by [ProductProperty].([ProductPropertyValueId]) (FK_ProductProperty_Value)
        /// </summary>
        public virtual ProductPropertyValue ProductPropertyValue { get; set; } // FK_ProductProperty_Value


        /// <summary>
        /// Parent Product pointed by [Product].([ProductId]) (FK_ProductProperty_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_ProductProperty_Value
    }
}
