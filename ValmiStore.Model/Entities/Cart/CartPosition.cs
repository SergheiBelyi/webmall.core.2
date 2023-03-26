using System;

namespace Webmall.Model.Entities.Cart
{
    public class CartPosition
    {
        /// <summary>
        /// URL карточки товара
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Идентификатор позиции товара
        /// </summary>
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
        public decimal AvailableQnt { get; set; }

        /// <summary>
        /// Доступное к заказу количество (в формате строки для показа)
        /// </summary>
        public string AvailableQntStr { get; set; }

        /// <summary>
        /// Срок доставки в днях
        /// </summary>
        public int DeliveryDays { get; set; }

        /// <summary>
        /// Дата время доставки
        /// </summary>
        public DateTime? DeliveryTerm { get; set; }

        /// <summary>
        /// Рейтинг вероятности доставки (в процентах)
        /// </summary>
        public int DeliveryRating { get; set; }

        /// <summary>
        /// Срок возврата в днях, null - нет ограничения
        /// </summary>
        public int ReturnDays { get; set; }

        /// <summary>
        /// Разрешение возврата товара
        /// </summary>
        public bool IsReturnAllowed { get; set; }

        /// <summary>
        /// Кратность продажи
        /// </summary>
        public int SaleQnt { get; set; }

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
        public decimal ClientPrice { get; set; }

        /// <summary>
        /// Розничная цена
        /// </summary>
        public decimal? RetailPrice { get; set; }

        /// <summary>
        /// Заказанное количество товара
        /// </summary>
        public decimal WareQnt { get; set; }

        /// <summary>
        /// Код склада отгрузки
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Наименвоание склада отгрузки
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// Наличие товара на складе отгрузки
        /// </summary>
        public decimal? WarehouseQnt { get; set; }

        public string DeliveryTermAsString => (!DeliveryTerm.HasValue) ? null :
            (DeliveryTerm.Value.Date == DeliveryTerm.Value) ? DeliveryTerm.Value.ToShortDateString() :
                DeliveryTerm.ToString();

        public string DeliveryPresentation => Helper.DeliveryTermPresentator(DeliveryTerm);

        public decimal? Sum => ClientPrice * WareQnt;

        /// <summary>
        /// Признак акционного товара
        /// </summary>
        public bool IsAction { get; set; }

        /// <summary>
        /// признак распродажи
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