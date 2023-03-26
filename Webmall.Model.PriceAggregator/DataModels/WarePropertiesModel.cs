namespace Webmall.Model.PriceAggregator.DataModels
{
    public class WarePropertiesModel
    {
        public string Id { get; set; }
        public int? PropTypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Importance { get; set; }
    }
}
