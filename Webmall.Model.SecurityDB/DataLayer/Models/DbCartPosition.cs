using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webmall.Model.Database.DataLayer.Models
{
    [Table("vsCart")]
    public class DbCartPosition
    {
        /// <summary>
        /// Идентификатор позиции корзины
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, добавившего товар в корзину
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор клиента, для которого заказан товар
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Идентификатор оффера
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Дата добавления товара в корзину
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        public string ProducerId { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string ProducerName { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public string WareId { get; set; }

        /// <summary>
        /// Артикул товара
        /// </summary>
        public string WareNum { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string WareName { get; set; }

        /// <summary>
        /// Комментарий к позиции корзины
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Доступное к заказу количество
        /// </summary>
        [Column("AvailableQnt")]
        public decimal? AvailableQnt { get; set; }

        /// <summary>
        /// Доступное к заказу количество (в формате строки для показа)
        /// </summary>
        public string AvailableQntStr { get; set; }

        /// <summary>
        /// Срок доставки в днях
        /// </summary>
        public int? DeliveryDays { get; set; }

        /// <summary>
        /// Дата время доставки
        /// </summary>
        public DateTime? DeliveryTerm { get; set; }

        /// <summary>
        /// Рейтинг вероятности доставки (в процентах)
        /// </summary>
        [Column("DeliveryRating")]
        public decimal? DeliveryRating { get; set; }

        /// <summary>
        /// Срок возврата в днях, 0 - возврат запрещен, null - нет ограничения
        /// </summary>
        public int? ReturnDays { get; set; }

        /// <summary>
        /// Код поставщика товара
        /// </summary>
        public string SupplierUid { get; set; }

        /// <summary>
        /// Наименование поставщика товара
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Наименование товара от поставщика
        /// </summary>
        public string SupplierWareName { get; set; }

        /// <summary>
        /// Код товара от поставщика (для заказа)
        /// </summary>
        public string SupplierWareNum { get; set; }

        /// <summary>
        /// Наименование производителя от поставщика (для заказа)
        /// </summary>
        public string SupplierBrandName { get; set; }

        /// <summary>
        /// Цена клиента
        /// </summary>
        [Column("ClientPrice", TypeName = "money")]
        public decimal? ClientPrice { get; set; }

        /// <summary>
        /// Розничная цена
        /// </summary>
        [Column("RetailPrice", TypeName = "money")]
        public decimal? RetailPrice { get; set; }

        /// <summary>
        /// Заказанное количество товара
        /// </summary>
        [Column("WareQnt")]
        public decimal? WareQnt { get; set; }

        /// <summary>
        /// Кратность продажи
        /// </summary>
        public int SaleQnt { get; set; }

        /// <summary>
        /// Код склада отгрузки
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Наименование склада отгрузки
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// Наличие товара на складе отгрузки
        /// </summary>
        [Column("WarehouseQnt")]
        public decimal? WarehouseQnt { get; set; }

        /// <summary>
        /// Признак акционного товара
        /// </summary>
        public bool IsAction { get; set; }

        /// <summary>
        /// Признак распродажи
        /// </summary>
        public bool IsSale { get; set; }

        ///// <summary>
        ///// цена распродажи
        ///// </summary>
        //public decimal? SalePrice { get; set; }

        ///// <summary>
        ///// Вес
        ///// </summary>
        //public decimal WareWeight { get; set; }

        //public bool IsSelected { get; set; }
        //public bool HasFlushed { get; set; }
        //[JsonIgnore]
        //public string OfferId { get; set; }
        //public int? OfferTypeId { get; set; }

        //public string NoReturnMessage { get; set; }

    }
}