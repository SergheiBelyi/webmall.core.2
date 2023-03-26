using System;
using System.Globalization;
using ViewRes;

namespace Webmall.UI.Core
{
    public static class PresentationHelper
    {
        private const int MaxVisibleQnt = 10;

        /// <summary>
        /// Преобразовывает дату поставки в срок поставки
        /// </summary>
        /// <param name="deliveryTerm"></param>
        /// <returns></returns>
        public static string DeliveryTermPresentator(this DateTime? deliveryTerm)
        {
            var now = DateTime.Now;
            if (deliveryTerm == null)
                return "";
            if (deliveryTerm <= now) 
                return SharedResources.OnStock;
            var days = deliveryTerm.Value.ToShortDateString();
            if (deliveryTerm.Value.Date <= now.Date)
            {
                days = ""; //SharedResources.Today;
            }
            var time = deliveryTerm.Value.TimeOfDay.Hours != 0 ? deliveryTerm.Value.ToShortTimeString() : "";
            return $"{days} {time}";
        }

        public static string QuantityPresenter(this decimal? quantity, bool alwaysShowQuantity = false)
        {
            if (quantity.HasValue)
            {
                if (alwaysShowQuantity && quantity > 0) return quantity.Value.ToString(CultureInfo.InvariantCulture);
                if (quantity > MaxVisibleQnt)
                    return $"> {MaxVisibleQnt}";
                if (quantity == -1)
                    return "0"; //ViewRes.SharedResources.No;
                if (quantity == 0)
                    return "-";
                return ((int)quantity).ToString();
            }
            return SharedResources.Ordering;
        }
    }
}
