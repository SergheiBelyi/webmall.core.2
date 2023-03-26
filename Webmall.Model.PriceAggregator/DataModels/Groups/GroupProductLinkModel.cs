using System;
using System.Text.Json.Serialization;
using Webmall.Model.PriceAggregator.DataModels.Product;

namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    // GroupProductLink
    /// <summary>
    /// Связи товаров и групп
    /// </summary>
    public class GroupProductLinkModel
    {
        /// <summary>
        /// Идентификатор связи
        /// </summary>
        public int GroupProductLinkId { get; set; } // GroupProductLinkId (Primary key)

        /// <summary>
        /// Группа товаров
        /// </summary>
        public int GroupId { get; set; } // GroupId

        /// <summary>
        /// Товар
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Тип группы товаров
        /// </summary>
        public int GroupTypeId { get; set; } // GroupTypeId

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
        /// Parent Group pointed by [GroupProductLink].([GroupId]) (FK_GroupProductLink_Group)
        /// </summary>
        [JsonIgnore]
        public virtual GroupModel Group { get; set; } // FK_GroupProductLink_Group

        /// <summary>
        /// Parent GroupType pointed by [GroupProductLink].([GroupTypeId]) (FK_GroupProductLink_GroupType)
        /// </summary>
        [JsonIgnore]
        public virtual GroupTypeModel GroupType { get; set; } // FK_GroupProductLink_GroupType

        /// <summary>
        /// Parent Product pointed by [GroupProductLink].([ProductId]) (FK_GroupProductLink_Product)
        /// </summary>
        [JsonIgnore]
        public virtual ProductModel Product { get; set; } // FK_GroupProductLink_Product

        public GroupProductLinkModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
