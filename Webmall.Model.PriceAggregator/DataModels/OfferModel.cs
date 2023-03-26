using System;

namespace Webmall.Model.PriceAggregator.DataModels
{
    public class OfferModel
    {
        public bool IsOrganization { get; set; }

        /// <summary>
        /// Код поставщика
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Uid поставщика
        /// </summary>
        public string SupplierUid { get; set; }

        /// <summary>
        /// Код прайслиста
        /// </summary>
        public int? PricelistId { get; set; }

        /// <summary>
        /// Uid прайслиста
        /// </summary>
        public string PricelistUid { get; set; }

        /// <summary>
        /// Код склада поставщика
        /// </summary>
        public int? SupplierWarehouseId { get; set; }

        /// <summary>
        /// Uid склада поставщика
        /// </summary>
        public string SupplierWarehouseUid { get; set; }

        /// <summary>
        /// Наименование склада поставщика
        /// </summary>
        public string SupplierWarehouseName { get; set; }

        /// <summary>
        /// Кратность продажи
        /// </summary>
        public int SaleMultiplier { get; set; }

        /// <summary>
        /// Минимальное количество ????
        /// </summary>
        public string MinQnt { get; set; }

        /// <summary>
        /// Максимально доступное количество
        /// </summary>
        public decimal? AvailableQnt { get; set; }

        /// <summary>
        /// Строковое представление количества из прайс-листа
        /// </summary>
        public string AvailableQntStr { get; set; }

        /// <summary>
        /// Цена клиента по которой продает клиент
        /// </summary>
        public decimal? ClientSalePrice { get; set; }

        /// <summary>
        /// Цена для клиента
        /// </summary>
        public decimal? ClientPrice { get; set; }

        /// <summary>
        /// Региональная рекомендованная цена
        /// </summary>
        public decimal? RegPrice { get; set; }

        /// <summary>
        /// Рекомендованная цена
        /// </summary>
        public decimal? BasePrice { get; set; }

        /// <summary>
        /// Рекомендованная розничная цена
        /// </summary>
        public decimal? RetailPrice { get; set; }

        /// <summary>
        /// Цена поставщика
        /// </summary>
        public decimal SupplierPrice { get; set; }

        /// <summary>
        /// Срок поставки
        /// </summary>
        public decimal DeliveryDays => (int)(DeliveryDate.Date - DateTime.Now.Date).TotalDays;

        /// <summary>
        /// Дата поставки
        /// </summary>
        public DateTime DeliveryDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Вероятность поставки
        /// </summary>
        public decimal? DeliveryRating { get; set; }

        /// <summary>
        /// Количество дней на возврат
        /// </summary>
        public int? ReturnDays { get; set; }

        /// <summary>
        /// Наименование валюты
        /// </summary>
        public string PricelistCurrency { get; set; }

        /// <summary>
        /// Цена из прайслиста в валюте прайса
        /// </summary>
        public decimal PricelistPrice { get; set; }

        /// <summary>
        /// Дата/время обработки прайса
        /// </summary>
        public DateTime PricelistDate { get; set; }
        public string BaseProfileUid { get; set; }
        public string BaseWaregroupUid { get; set; }
        public string RegProfileUid { get; set; }
        public string RegWaregroupUid { get; set; }
        public string ClientProfileUid { get; set; }
        public string ClientWaregroupUid { get; set; }

        /// <summary>
        /// Наименование номенклатуры поставщика
        /// </summary>
        public string SupplierWareId { get; set; }

        /// <summary>
        /// Наименование номенклатуры поставщика
        /// </summary>
        public string SupplierWareName { get; set; }

        /// <summary>
        /// Артикул поставщика (с префиксами суффиксами в ненормализованном виде)
        /// </summary>
        public string SupplierWareNumber { get; set; }

        /// <summary>
        /// Название бренда Поставщика (не нормализованное)
        /// </summary>
        public string SupplierBrandName { get; set; }

        // <summary>
        // Наименование единицы измерения Поставщика
        // </summary>
        //public string SupplierMUName { get; set; }

        public bool MyWarehouse { get; set; }
        public bool BestPrice { get; set; }
        public bool BestQnt { get; set; }
        public bool BestDelivery { get; set; }
        public bool BestReturn { get; set; }

        public bool IsReplacement { get; set; } = false;

        private string _offerId;
        public string OfferId
        {
            get => _offerId ?? (_offerId = $"{SupplierWareNumber}{SupplierBrandName}{SupplierUid}{SupplierWarehouseUid}{PricelistUid}{ClientPrice}").ToLower().HashSha1();
            set => _offerId = value;

            //get => string.Join("_", SupplierId, DeliveryDate.Ticks.ToString(), (ClientPrice ?? 0).ToString().Replace(",", "."));
            //set
            //{
            //    if (value == null)
            //        return;
            //    var spl = value.Split('_');
            //    if (spl.Length < 3) return;
            //    if (int.TryParse(spl[0], out var id))
            //        SupplierId = id;
            //    if (long.TryParse(spl[1], out var tiks))
            //        DeliveryDate = new DateTime(tiks);
            //    if (decimal.TryParse(spl[2], out var price))
            //        ClientPrice = price;
            //}
        }

    }
}
