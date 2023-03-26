namespace Webmall.UI.Api.Models
{
    public class UpdateOrderPayload
    {
        public string OrderId { get; set; }
        //public PositionDto[] PositionsQuantity  { get; set; }
        public PaymentDto Payment  { get; set; }
        public DeliveryDto Delivery { get; set; }

        public string Comment { get; set; }
    }
}