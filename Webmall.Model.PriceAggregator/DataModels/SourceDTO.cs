using System;

namespace SERP.Product.Api.Domain.Models
{
    /// Source
    /// <summary>
    /// Источники данных
    /// </summary>
    public class SourceDTO
    {

        /// <summary>
        /// Код источника данных
        /// </summary>
        public int SourceId { get; set; } // SourceId (Primary key)

        /// <summary>
        /// Название источника данных
        /// </summary>
        public string SourceName { get; set; } // SourceName (length: 100)

        /// <summary>
        /// Примечание
        /// </summary>
        public string SourceRemark { get; set; } // SourceRemark

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
    }
}