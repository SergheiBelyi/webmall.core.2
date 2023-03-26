using System.Collections.Generic;

namespace ValmiStore.Model.Entities.MarketingActions
{
    public class CumulativeAction : MarketingAction
    {
        public decimal AccumulatedAmount { get; set; }
        public List<ActionPresent> Presents { get; set; }
    }

}