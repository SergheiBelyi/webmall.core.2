using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Auto models list
    /// </summary>
    public class AutoModelList
    {
        public string AutoMarkaUid { get; set; }
        public List<AutoModel> Items { get; set; }
    }

}
