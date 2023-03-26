using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Auto modifications list
    /// </summary>
    public class AutoModifList
    {
        public string AutoModelUid { get; set; }
        public List<AutoModificationData> Items { get; set; }
    }

}
