using System;

namespace Webmall.Model.PriceAggregator.DataModels
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDateTime { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDateTime { get; set; }
    }
}
