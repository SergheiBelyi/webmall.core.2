using System;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // ProductName
    /// <summary>
    /// Наименования товаров
    /// </summary>
    public class ProductNameModel
    {
        /// <summary>
        /// Идентификатор наименования товара
        /// </summary>
        public int ProductNameId { get; set; } // ProductNameId (Primary key)

        /// <summary>
        /// Код товара
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Код языка
        /// </summary>
        public int LanguageId { get; set; } // LanguageId

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string ProductName { get; set; } // ProductName (length: 250)

        /// <summary>
        /// Описание товара
        /// </summary>
        public string ProductDescription { get; set; } // ProductDescription

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
        /// Parent Product pointed by [ProductName].([ProductId]) (FK_ProductName_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_ProductName_Product

        public ProductNameModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
