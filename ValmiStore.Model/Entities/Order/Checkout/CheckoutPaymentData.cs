namespace Webmall.Model.Entities.Order.Checkout
{
    /// <summary>
    /// Параметры оплаты при создании заказа
    /// </summary>
    public class CheckoutPaymentData
    {
        /// <summary>
        /// Тип оплаты (Согласуется с учетной системой)
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Сумма к оплате
        /// </summary>
        public decimal? SumToPay { get; set; }

        /// <summary>
        /// Дополнительная информация (JSON, cогласуется с учетной системой)
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}