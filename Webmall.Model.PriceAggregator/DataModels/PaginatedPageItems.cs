namespace Webmall.Model.PriceAggregator.DataModels
{
    public class PaginatedPageItems
    {
        public int LinesPerPage { get; set; }
        public int PageNumber { get; set; }
        public int CountAllRecords { get; set; }
    }
}