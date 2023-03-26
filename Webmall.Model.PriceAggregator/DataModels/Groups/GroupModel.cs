using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Webmall.Model.PriceAggregator.DataModels.Product;

namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    // Group
    /// <summary>
    /// Группы товаров
    /// </summary>
    public class GroupModel : IAuditable
    {
        /// <summary>
        /// Код группы товаров
        /// </summary>
        public int GroupId { get; set; } // GroupId (Primary key)

        /// <summary>
        /// Название группы товаров
        /// </summary>
        public string GroupName { get; set; } // GroupName (length: 100)

        /// <summary>
        /// Тип группы товаров
        /// </summary>
        public int GroupTypeId { get; set; } // GroupTypeId

        /// <summary>
        /// Примечание
        /// </summary>
        public string GroupRemark { get; set; } // GroupRemark

        /// <summary>
        /// Родительская группа товаров
        /// </summary>
        public int? GroupParentId { get; set; } // GroupParentId


        /// <summary>
        /// Номер группы на ветке
        /// </summary>
        public int? GroupNumber { get; set; } // GroupNumber

        /// <summary>
        /// Полный номер
        /// </summary>
        public string FullNumber { get; set; } // FullNumber (length: 100)

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
        /// Child Groups where [Group].[GroupParentId] point to this entity (FK_Group_Parent)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<GroupModel> Groups { get; set; } // Group.FK_Group_Parent

        /// <summary>
        /// Child GroupProductLinks where [GroupProductLink].[GroupId] point to this entity (FK_GroupProductLink_Group)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<GroupProductLinkModel> GroupProductLinks { get; set; } // GroupProductLink.FK_GroupProductLink_Group

        /// <summary>
        /// Child Products where [Product].[BaseGroupId] point to this entity (FK_Product_Group)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ProductModel> Products { get; set; } // Product.FK_Product_Group

        // Foreign keys

        /// <summary>
        /// Parent Group pointed by [Group].([GroupParentId]) (FK_Group_Parent)
        /// </summary>
        [JsonIgnore]
        public virtual GroupModel GroupParent { get; set; } // FK_Group_Parent

        /// <summary>
        /// Parent GroupType pointed by [Group].([GroupTypeId]) (FK_Group_Type)
        /// </summary>
        [JsonIgnore]
        public virtual GroupTypeModel GroupType { get; set; } // FK_Group_Type

        public GroupModel()
        {
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            Groups = new List<GroupModel>();
            GroupProductLinks = new List<GroupProductLinkModel>();
            Products = new List<ProductModel>();
        }
    }
}
