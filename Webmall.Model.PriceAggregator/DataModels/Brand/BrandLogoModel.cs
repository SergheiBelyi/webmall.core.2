using System;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Brand
{
    // BrandLogo
    /// <summary>
    /// Логотипы брендов
    /// </summary>
    public class BrandLogoModel : IAuditable
    {
        /// <summary>
        /// Код логотипа бренда
        /// </summary>
        public int BrandLogoId { get; set; } // BrandLogoId (Primary key)

        /// <summary>
        /// Код бренда
        /// </summary>
        public int BrandId { get; set; } // BrandId

        /// <summary>
        /// Полное имя файла с логотипом
        /// </summary>
        public string FullFileName { get; set; } // FullFileName (length: 300)

        /// <summary>
        /// Сокращенное имя файла с логотипом
        /// </summary>
        public string ShortFileName { get; set; } // ShortFileName (length: 300)

        /// <summary>
        /// Признак активности
        /// </summary>
        public bool IsActive { get; set; } // IsActive

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
        /// Parent Brand pointed by [BrandLogo].([BrandId]) (FK_BrandLogo_Brand)
        /// </summary>
        [JsonIgnore]
        public virtual BrandModel Brand { get; set; } // FK_BrandLogo_Brand

        public BrandLogoModel()
        {
            IsActive = true;
        }
    }
}