using System;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // Replacement
    /// <summary>
    /// Замены товаров
    /// </summary>
    public class ReplacementModel
    {
        /// <summary>
        /// Иденктификатор замены
        /// </summary>
        public int ReplacementId { get; set; } // ReplacementId (Primary key)

        /// <summary>
        /// Заменяемый товар
        /// </summary>
        public int ReplaceableProductId { get; set; } // ReplaceableProductId

        /// <summary>
        /// Заменяющий товар
        /// </summary>
        public int ReplacingProductId { get; set; } // ReplacingProductId

        /// <summary>
        /// Источник данных
        /// </summary>
        public int? SourceId { get; set; } // SourceId

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
        /// Parent Product pointed by [Replacement].([ReplaceableProductId]) (FK_Replacement_Replaceable)
        /// </summary>
        public virtual ProductModel ReplaceableProduct { get; set; } // FK_Replacement_Replaceable

        /// <summary>
        /// Parent Product pointed by [Replacement].([ReplacingProductId]) (FK_Replacement_Replacing)
        /// </summary>
        public virtual ProductModel ReplacingProduct { get; set; } // FK_Replacement_Replacing

        public ReplacementModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
