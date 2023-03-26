using System.Collections.Generic;

namespace ValmiStore.Model.Entities.MarketingActions
{
    public class LoyaltyProgram : MarketingAction
    {
        public string AccumulatedAmount { get; set; }
        public List<ActionPresent> Presents { get; set; }
    }
}
