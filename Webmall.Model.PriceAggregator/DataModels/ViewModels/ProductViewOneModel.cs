using System;

namespace SERP.Product.Api.Domain.Models.ViewModels
{
    //ProductViewOneModel
    /// <summary>
    /// Подробнее о товаре
    /// </summary>
    public class ProductViewOneModel
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
        public int? BrandId { get; set; } // BrandId

        /// <summary>
        /// Имя Бренда
        /// </summary>
        public string BrandName { get; set; } // BrandName

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
        /// Короткое название единицы измерения
        /// Основная единица измерения
        /// </summary>
        public string UnitShortName { get; set; } // UnitShortName

        /// <summary>
        /// Базовая группа товаров
        /// </summary>
        public int BaseGroupId { get; set; } // BaseGroupId

        /// <summary>
        /// Группа товаров
        /// </summary>
        public string GroupName { get; set; } // FK_Product_Group

        /// <summary>
        /// Снят с производства
        /// </summary>
        public bool? IsOutProduction { get; set; } // IsOutProduction

        /// <summary>
        /// Кратность потребления в основной единице измерения
        /// </summary>
        public int? Multiplicity { get; set; } // Multiplicity

        /// <summary>
        /// Источник данных
        /// </summary>
        public int? SourceId { get; set; } // SourceId

        /// <summary>
        /// Источник данных
        /// </summary>
        public string SourceName { get; set; } // SourceName

        /// <summary>
        /// Дата ввода
        /// </summary>
        public DateTime? InputDate { get; set; } // InputDate
    }
}
