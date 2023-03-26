
namespace Webmall.Model.PriceAggregator.DataModels
{
    public class ProducerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Order { get; set; }
        public bool OurProducer { get; set; }
        public bool IsOEM { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}
