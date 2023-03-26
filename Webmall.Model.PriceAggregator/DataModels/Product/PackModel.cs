using System;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // Pack
    /// <summary>
    /// Упаковки товаров
    /// </summary>
    public class PackModel : IAuditable
    {
        /// <summary>
        /// Код упаковки
        /// </summary>
        public int PackId { get; set; } // PackId (Primary key)

        /// <summary>
        /// Товар
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Единица измерений
        /// </summary>
        public int UnitId { get; set; } // UnitId

        /// <summary>
        /// Кол-во основных единиц
        /// </summary>
        public int Rate { get; set; } // Rate

        /// <summary>
        /// Длина, мм
        /// </summary>
        public int? PackLen { get; set; } // PackLen

        /// <summary>
        /// Ширина, мм
        /// </summary>
        public int? PackWidth { get; set; } // PackWidth

        /// <summary>
        /// Высота, мм
        /// </summary>
        public int? PackHeight { get; set; } // PackHeight

        /// <summary>
        /// Вес, г
        /// </summary>
        public int? PackWeight { get; set; } // PackWeight

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
        /// Parent Product pointed by [Pack].([ProductId]) (FK_Pack_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_Pack_Product

        public PackModel()
        {
            Rate = 1;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
