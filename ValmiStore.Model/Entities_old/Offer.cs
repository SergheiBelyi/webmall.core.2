using System;
using Webmall.Model;

namespace ValmiStore.Model.Entities
{
    [Serializable]
    public class Offer
    {
        /// <summary>
        /// Заказанное количество
        /// </summary>
        public int OrderedQuantity { get; set; }

        /// <summary>
        /// Код поставщика
        /// </summary>
        public string SupplierId { get; set; }

        /// <summary>
        /// Наименование поставщика
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Наименование склада
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// Признак предложения с партнерского склада
        /// </summary>
        public bool IsPartnerWarehouse { get; set; }

        public decimal? MinQuantity { get; set; }
        public decimal? MaxQuantity { get; set; }
        public decimal? ShippingStockQnt { get; set; }

        /// <summary>
        /// Цена до применения персональной скидки
        /// </summary>
        public decimal? BasePrice { get; set; }

        /// <summary>
        /// Персональная скидка
        /// </summary>
        public int DiscountPercentage { get; set; }

        public decimal? MainValutePrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? RetailPrice { get; set; }
        public DateTime? DeliveryTerm { get; set; }
        public string DeliveryPresentation => (MaxQuantity > 0 || OfferTypeId > 1) ? Helper.DeliveryTermPresentator(DeliveryTerm) : "";
        public bool IsSale { get; set; }
        public bool IsBlocked { get; set; }
        public int? OfferTypeId { get; set; }

        public OfferStatuses Status(bool allowCustomOrders)
        {
            if (IsBlocked)
                return OfferStatuses.Inventory;
            if (DeliveryTerm.HasValue && ((MaxQuantity > 0 || allowCustomOrders)))
                return OfferStatuses.CanAddToCart;
            return OfferStatuses.Unavailable;
        }

        public string Id
        {
            get => Helper.ListToString(new object[] { SupplierId, DeliveryTerm?.Ticks.ToString() ?? string.Empty, MainValutePrice.ToString().Replace(',', '-').Replace('.', '~'), WarehouseId }, "_").Replace("@", "~~");
            set
            {
                var spl = value.Replace("~~", "@").Split('_');
                if (spl.Length < 4) return;
                // int id;
               // if (int.TryParse(spl[0], out id))
                SupplierId = spl[0];
                if (long.TryParse(spl[1], out var tiks))
                    DeliveryTerm = new DateTime(tiks);
                if (decimal.TryParse(spl[2].Replace('-', ',').Replace('~', '.'), out var price))
                    MainValutePrice = price;
                WarehouseId = spl[3];
            }
        }

        /// <summary>
        /// Кол-во для демонстрации клиенту
        /// </summary>
        public string InStockQty { get; set; }

        // Количество товара по предложению в корзине
        public int InCart { get; set; }
    }
}

namespace ValmiStore.Model.Entities
{
    public enum OfferStatuses
    {
        CanAddToCart,
        Inventory,
        Unavailable
    }
}