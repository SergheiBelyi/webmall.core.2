namespace Webmall.UI.Api.Models
{
    public class UpdateOrderPositionPayload
    {
        public string OrderId { get; set; }
        public string PositionId { get; set; }
        public int Quantity { get; set; }
        
    }
}