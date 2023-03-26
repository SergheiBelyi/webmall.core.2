using System;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    public class KitModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int KitId { get; set; }

        /// <summary>
        /// Товар-комплект
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Товар-комплектующий
        /// </summary>
        public int ComponentId { get; set; }

        /// <summary>
        /// ​Кол-во товара-комплектующего в комплекте
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Единица измерений для комплектующего
        /// </summary>
        public int UnitId { get; set; }

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

        /// <summary>
        /// Parent Product pointed by [Kit].([ProductId]) (FK_Kit_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_Kit_Product
    }
}
