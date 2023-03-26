namespace Webmall.UI.Api.Models
{
    public class RemoveOrderPositionsPayload
    {
        public string OrderId { get; set; }
        public string[] PositionIds { get; set; }
        
    }
}