namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Данные модификации для автомобиля
    /// </summary>
    public class AutoModificationShort : AutoModificationBase
    {
        public AutoModel Model { get; set; }
        public AutoMarka Marka { get; set; }
    }
}
