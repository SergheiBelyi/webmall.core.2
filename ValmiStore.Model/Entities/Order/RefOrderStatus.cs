namespace Webmall.Model.Entities.Order
{
    public class RefOrderStatus
    {
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsFinal { get; set; }
        public int Color { get; set; }
        public string WebColor => $"#{Color:X6}";
        public string Icon { get; set; }
    }
}
