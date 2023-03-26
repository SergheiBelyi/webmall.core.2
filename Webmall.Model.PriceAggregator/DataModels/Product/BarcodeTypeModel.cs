using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // BarcodeType
    /// <summary>
    /// Типы штрихкодов
    /// </summary>
    public class BarcodeTypeModel : IAuditable
    {
        /// <summary>
        /// Код типа штрихкода
        /// </summary>
        public int BarcodeTypeId { get; set; } // BarcodeTypeId (Primary key)

        /// <summary>
        /// Название типа штрихкода
        /// </summary>
        public string BarcodeTypeName { get; set; } // BarcodeTypeName (length: 50)

        /// <summary>
        /// Примечание
        /// </summary>
        public string BarcodeTypeRemark { get; set; } // BarcodeTypeRemark

        /// <summary>
        /// Количество символов
        /// </summary>
        public int Characters { get; set; } // Characters

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
        /// Child Barcodes where [Barcode].[BarcodeTypeId] point to this entity (FK_Barcode_BarcodeType)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<BarcodeModel> Barcodes { get; set; } // Barcode.FK_Barcode_BarcodeType

        public BarcodeTypeModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            Barcodes = new List<BarcodeModel>();
        }
    }
}
