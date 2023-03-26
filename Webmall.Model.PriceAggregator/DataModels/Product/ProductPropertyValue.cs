using System;
using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // ProductPropertyValue
    /// <summary>
    /// Значения свойств товаров
    /// </summary>
    public class ProductPropertyValue
    {
        /// <summary>
        /// Код значения свойства товаров
        /// </summary>
        public int ProductPropertyValueId { get; set; } // ProductPropertyValueId (Primary key)

        /// <summary>
        /// Тип свойства товаров
        /// </summary>
        public int ProductPropertyTypeId { get; set; } // ProductPropertyTypeId

        /// <summary>
        /// Значение свойства
        /// </summary>
        public string PropertyValue { get; set; } // PropertyValue (length: 100)

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

        // Reverse navigation

        /// <summary>
        /// Child ProductProperties where [ProductProperty].[ProductPropertyValueId] point to this entity (FK_ProductProperty_Value)
        /// </summary>
        public virtual ICollection<ProductProperty> ProductProperties { get; set; } // ProductProperty.FK_ProductProperty_Value

        // Foreign keys

        /// <summary>
        /// Parent ProductPropertyType pointed by [ProductPropertyValue].([ProductPropertyTypeId]) (FK_ProductPropertyValue_TypeId)
        /// </summary>
        public virtual ProductPropertyType ProductPropertyType { get; set; } // FK_ProductPropertyValue_TypeId

        public ProductPropertyValue()
        {
            ProductProperties = new List<ProductProperty>();
        }
    }
}
