using System;
using System.Collections.Generic;
using SERP.Product.Api.Domain.Models;
using Webmall.Model.PriceAggregator.DataModels.Brand;
using Webmall.Model.PriceAggregator.DataModels.Groups;

namespace Webmall.Model.PriceAggregator.DataModels.Product
{
    // Product
    /// <summary>
    /// Товары
    /// </summary>
    public class ProductModel : IAuditable
    {
        /// <summary>
        /// Код товара
        /// </summary>
        public int ProductId { get; set; } // ProductId (Primary key)

        /// <summary>
        /// Каталожный номер
        /// </summary>
        public string ProductCode { get; set; } // ProductCode (length: 50)

        /// <summary>
        /// Бренд
        /// </summary>
        public int BrandId { get; set; } // BrandId

        /// <summary>
        /// Основное наименование
        /// </summary>
        public string ProductBaseName { get; set; } // ProductBaseName (length: 100)

        /// <summary>
        /// Примечание
        /// </summary>
        public string ProductRemark { get; set; } // ProductRemark

        /// <summary>
        /// Основная единица измерения
        /// </summary>
        public int UnitId { get; set; } // UnitId

        /// <summary>
        /// Снят с производства
        /// </summary>
        public bool IsOutProduction { get; set; } // IsOutProduction

        /// <summary>
        /// Кратность потребления в основной единице измерения
        /// </summary>
        public int Multiplicity { get; set; } // Multiplicity

        /// <summary>
        /// Источник данных
        /// </summary>
        public int? SourceId { get; set; } // SourceId

        /// <summary>
        /// Дата ввода
        /// </summary>
        public DateTime? InputDate { get; set; } // InputDate

        /// <summary>
        /// Идентификатор товара в партнерской системе
        /// </summary>
        public int? PartnerSystemProductId { get; set; } // PartnerSystemProductId

        /// <summary>
        /// Базовая группа товаров
        /// </summary>
        public int? BaseGroupId { get; set; } // BaseGroupId

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
        /// Child Barcodes where [Barcode].[ProductId] point to this entity (FK_Barcode_Product)
        /// </summary>
        public virtual ICollection<BarcodeModel> Barcodes { get; set; } // Barcode.FK_Barcode_Product

        /// <summary>
        /// Child GroupProductLinks where [GroupProductLink].[ProductId] point to this entity (FK_GroupProductLink_Product)
        /// </summary>
        public virtual ICollection<GroupProductLinkModel> GroupProductLinks { get; set; } // GroupProductLink.FK_GroupProductLink_Product

        /// <summary>
        /// Child Packs where [Pack].[ProductId] point to this entity (FK_Pack_Product)
        /// </summary>
        public virtual ICollection<PackModel> Packs { get; set; } // Pack.FK_Pack_Product

        /// <summary>
        /// Child Kits where [Kit].[ProductId] point to this entity (FK_Kit_Product)
        /// </summary>
        public virtual ICollection<KitModel> Kits { get; set; } // Kit.FK_Kit_Product

        /// <summary>
        /// Child ProductNames where [ProductName].[ProductId] point to this entity (FK_ProductName_Product)
        /// </summary>
        public virtual ICollection<ProductNameModel> ProductNames { get; set; } // ProductName.FK_ProductName_Product

        /// <summary>
        /// Child Replacements where [Replacement].[ReplaceableProductId] point to this entity (FK_Replacement_Replaceable)
        /// </summary>
        public virtual ICollection<ReplacementModel> Replacements_ReplaceableProductId { get; set; } // Replacement.FK_Replacement_Replaceable

        /// <summary>
        /// Child Replacements where [Replacement].[ReplacingProductId] point to this entity (FK_Replacement_Replacing)
        /// </summary>
        public virtual ICollection<ReplacementModel> Replacements_ReplacingProductId { get; set; } // Replacement.FK_Replacement_Replacing

        /// <summary>
        /// Child SearchNumbers where [SearchNumber].[ProductId] point to this entity (FK_SearchNumber_Product)
        /// </summary>
        public virtual ICollection<SearchNumberModel> SearchNumbers { get; set; } // SearchNumber.FK_SearchNumber_Product

        /// <summary>
        /// Child Barcodes where [ProductProperty].[ProductId] point to this entity (FK_ProductProperty_Product)
        /// </summary>
        public virtual ICollection<ProductProperty> ProductProperties { get; set; } // ProductProperty.FK_ProductProperty_Product

        // Foreign keys
        /// <summary>
        /// Parent Brand pointed by [Product].([BrandId]) (FK_Product_Brand)
        /// </summary>
        public virtual BrandModel Brand { get; set; } // FK_Product_Brand

        /// <summary>
        /// Parent Group pointed by [Product].([BaseGroupId]) (FK_Product_Group)
        /// </summary>
        public virtual GroupModel Group { get; set; } // FK_Product_Group

        public ProductModel()
        {
            IsOutProduction = false;
            Multiplicity = 1;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            GroupProductLinks = new List<GroupProductLinkModel>();
            Packs = new List<PackModel>();
            ProductNames = new List<ProductNameModel>();
            Replacements_ReplaceableProductId = new List<ReplacementModel>();
            Replacements_ReplacingProductId = new List<ReplacementModel>();
            SearchNumbers = new List<SearchNumberModel>();
            Barcodes = new List<BarcodeModel>();
            Kits = new List<KitModel>();
        }
    }
}