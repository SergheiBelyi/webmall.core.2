using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Webmall.Model.PriceAggregator.DataModels.Product;

namespace Webmall.Model.PriceAggregator.DataModels.Brand
{
    public class BrandModel : IAuditable
    {
        /// <summary>
        /// Код бренда
        /// </summary>
        public int BrandId { get; set; } // BrandId (Primary key)

        /// <summary>
        /// Название бренда
        /// </summary>
        public string BrandName { get; set; } // BrandName (length: 100)

        /// <summary>
        /// Сокращенное название бренда
        /// </summary>
        public string BrandShortName { get; set; } // BrandShortName (length: 10)

        /// <summary>
        /// Примечание
        /// </summary>
        public string BrandRemark { get; set; } // BrandRemark

        /// <summary>
        /// Родительский бренд
        /// </summary>
        public int? BrandParentId { get; set; } // BrandParentId

        /// <summary>
        /// Наш бренд
        /// </summary>
        public bool IsOur { get; set; } // IsOur

        /// <summary>
        /// Признак активности
        /// </summary>
        public bool IsActive { get; set; } // IsActive

        /// <summary>
        /// Оригинальный бренд
        /// </summary>
        public bool IsOriginal { get; set; } // IsOriginal

        /// <summary>
        /// Страна происхождения
        /// </summary>
        public int? CountryId { get; set; } // CountryId

        /// <summary>
        /// Источник данных
        /// </summary>
        public int? SourceId { get; set; } // SourceId

        /// <summary>
        /// Дата ввода
        /// </summary>
        public DateTime InputDate { get; set; } // InputDate

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
        /// Идентификатор бренда в партнерской системе
        /// </summary>
        public int? PartnerSystemBrandId { get; set; } // PartnerSystemBrandId

        // Reverse navigation

        /// <summary>
        /// Child Brands where [Brand].[BrandParentId] point to this entity (FK_Brand_Brand)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<BrandModel> Brands { get; set; } // Brand.FK_Brand_Brand

        /// <summary>
        /// Child BrandLogoes where [BrandLogo].[BrandId] point to this entity (FK_BrandLogo_Brand)
        /// </summary>
        public virtual ICollection<BrandLogoModel> BrandLogos { get; set; } // BrandLogo.FK_BrandLogo_Brand

        /// <summary>
        /// Child Products where [Product].[BrandId] point to this entity (FK_Product_Brand)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ProductModel> Products { get; set; } // Product.FK_Product_Brand

        [JsonIgnore]
        public virtual CarMarkaModel CarMarka { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent Brand pointed by [Brand].([BrandParentId]) (FK_Brand_Brand)
        /// </summary>
        public virtual BrandModel BrandParent { get; set; } // FK_Brand_Brand

        public BrandModel()
        {
            IsOur = true;
            IsActive = true;
            IsOriginal = false;
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            Brands = new List<BrandModel>();
            BrandLogos = new List<BrandLogoModel>();
            Products = new List<ProductModel>();
        }
    }
}
