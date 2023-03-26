namespace Webmall.Model.PriceAggregator.DataModels
{
    // SearchNumberNormalization
    public class SearchNumberNormalizationModel
    {
        public int ProductId { get; set; } // ProductId (Primary key)
        public string SearchNumber { get; set; } // SearchNumber (length: 4000)
    }
}
