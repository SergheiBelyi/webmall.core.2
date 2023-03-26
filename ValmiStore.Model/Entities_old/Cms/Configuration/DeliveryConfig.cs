using System;

namespace ValmiStore.Model.Entities.Cms.Configuration
{
    public class DeliveryConfig
    {
        public int MaxAdressesCount { get; set; }
        public string HolydaysString { get; set; }
        public TimeSpan LastDayDeliveryTime { get; set; } = new TimeSpan(12, 0, 0);
    }
}
