namespace Webmall.Model.Entities.Order
{
    /// <summary>
    /// Информация об оплате
    /// </summary>
    public class PaymentInfo
    {
        /// <summary>
        /// Признак необходимости оплаты
        /// </summary>
        public bool NeedToPay { get; set; }

        /// <summary>
        /// Признак оплаченного заказа
        /// </summary>
        public bool IsPayed { get; set; }

        /// <summary>
        /// Код валюты заказа (EUR, MDL, BYN, …)
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Оплаченная сумма
        /// </summary>
        public decimal PayedSum { get; set; }
    }
}