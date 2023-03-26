using System;
using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // ProductPropertyType
    /// <summary>
    /// Типы свойств товаров
    /// </summary>
    public class ProductPropertyType
    {
        /// <summary>
        /// Код типа свойств товаров
        /// </summary>
        public int ProductPropertyTypeId { get; set; } // ProductPropertyTypeId (Primary key)

        /// <summary>
        /// Наименование типа свойств товаров
        /// </summary>
        public string ProductPropertyTypeName { get; set; } // ProductPropertyTypeName (length: 100)

        /// <summary>
        /// Примечание
        /// </summary>
        public string ProductPropertyTypeRemark { get; set; } // ProductPropertyTypeRemark

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
        /// Child ProductPropertyValues where [ProductPropertyValue].[ProductPropertyTypeId] point to this entity (FK_ProductPropertyValue_TypeId)
        /// </summary>
        public virtual ICollection<ProductPropertyValue> ProductPropertyValues { get; set; } // ProductPropertyValue.FK_ProductPropertyValue_TypeId

        public ProductPropertyType()
        {
            ProductPropertyValues = new List<ProductPropertyValue>();
        }
    }
}
