using System;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // Barcode
    /// <summary>
    /// Штрихкоды товаров
    /// </summary>
    public class BarcodeModel : IAuditable
    {
        /// <summary>
        /// Идентификатор штрихкода
        /// </summary>
        public int BarcodeId { get; set; } // BarcodeId (Primary key)

        /// <summary>
        /// Товар
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Тип штрихкода
        /// </summary>
        public int BarcodeTypeId { get; set; } // BarcodeTypeId

        /// <summary>
        /// Значение штрихкода
        /// </summary>
        public string BarcodeValue { get; set; } // BarcodeValue (length: 200)

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
        /// Parent BarcodeType pointed by [Barcode].([BarcodeTypeId]) (FK_Barcode_BarcodeType)
        /// </summary>
        public virtual BarcodeTypeModel BarcodeType { get; set; } // FK_Barcode_BarcodeType

        /// <summary>
        /// Parent Product pointed by [Barcode].([ProductId]) (FK_Barcode_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_Barcode_Product

        public BarcodeModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
