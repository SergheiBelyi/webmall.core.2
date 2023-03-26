namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class FullAutoData
    {
        public AutoMarka Mark = null;
        public AutoModel Model = null;
        public AutoModelDetail ModelDetail = null;
        public AutoModificationData Modif = null;
        public string FullName => $"{Mark?.Name} {Model?.Name} {ModelDetail?.Name} {Modif.Name}";
    }
}
