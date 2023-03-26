using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    // GroupType
    /// <summary>
    /// Типы групп товаров
    /// </summary>
    public class GroupTypeModel
    {
        /// <summary>
        /// Код типа группы товаров
        /// </summary>
        public int GroupTypeId { get; set; } // GroupTypeId (Primary key)

        /// <summary>
        /// название типа группы товаров
        /// </summary>
        public string GroupTypeName { get; set; } // GroupTypeName (length: 100)

        /// <summary>
        /// Примечание
        /// </summary>
        public string GroupTypeRemark { get; set; } // GroupTypeRemark

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

        // Reverse navigation

        /// <summary>
        /// Child Groups where [Group].[GroupTypeId] point to this entity (FK_Group_Type)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<GroupModel> Groups { get; set; } // Group.FK_Group_Type

        /// <summary>
        /// Child GroupProductLinks where [GroupProductLink].[GroupTypeId] point to this entity (FK_GroupProductLink_GroupType)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<GroupProductLinkModel> GroupProductLinks { get; set; } // GroupProductLink.FK_GroupProductLink_GroupType

        public GroupTypeModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            Groups = new List<GroupModel>();
            GroupProductLinks = new List<GroupProductLinkModel>();
        }
    }
}
