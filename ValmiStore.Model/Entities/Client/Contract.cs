namespace Webmall.Model.Entities.Client
{
    public class Contract
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? MaxSum { get; set; }

        public string PayDelayName { get; set; }

        public int PayDelayDays { get; set; }
    }
}