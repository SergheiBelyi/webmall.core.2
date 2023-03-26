using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SERP.Product.Api.Domain.Models;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // BaseNumberType
    /// <summary>
    /// Типы базовых номеров
    /// </summary>
    public class BaseNumberTypeModel : IAuditable
    {
        /// <summary>
        /// Код типа базового номера
        /// </summary>
        public int BaseNumberTypeId { get; set; } // BaseNumberTypeId (Primary key)

        /// <summary>
        /// Название типа базового номера
        /// </summary>
        public string BaseNumberTypeName { get; set; } // BaseNumberTypeName (length: 100)

        /// <summary>
        /// Примечание
        /// </summary>
        public string BaseNumberTypeRemark { get; set; } // BaseNumberTypeRemark

        /// <summary>
        /// Пользовательский
        /// </summary>
        public bool IsCustom { get; set; } // IsCustom

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
        /// Child SearchNumbers where [SearchNumber].[BaseNumberTypeId] point to this entity (FK_SearchNumber_BaseNumberType)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<SearchNumberModel> SearchNumbers { get; set; } // SearchNumber.FK_SearchNumber_BaseNumberType

        public BaseNumberTypeModel()
        {
            IsCustom = false;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            SearchNumbers = new List<SearchNumberModel>();
        }
    }
}
