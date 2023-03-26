using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels
{
    public class PaginatedItemsModel<TEntity> where TEntity : class
    {
        public int LinesPerPage { get; set; }
        public int PageNumber { get; set; }
        public long CountAllRecords { get; set; }
        public IEnumerable<TEntity> Data { get; set; }

        public PaginatedItemsModel(int linesPerPage, int pageNumber, long count, IEnumerable<TEntity> data)
        {
            LinesPerPage = linesPerPage;
            PageNumber = pageNumber;
            CountAllRecords = count;
            Data = data;
        }
    }
}
