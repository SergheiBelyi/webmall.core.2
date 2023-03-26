using Newtonsoft.Json;

namespace Webmall.Model.Entities.Client
{
    public class BreefingData
    {
        [JsonProperty(PropertyName = "CartPositionsNum")]
        public int CartPositionsCount { get; set; }

        [JsonProperty(PropertyName = "CarsPositionsCount")]
        public int CarsPositionsCount { get; set; }

        [JsonProperty(PropertyName = "ActiveOrdersNum")]
        public int ActiveOrdersCount { get; set; }
        
        [JsonProperty(PropertyName = "MoneyBalance")]
        public decimal Balance { get; set; }
        
        [JsonProperty(PropertyName = "NoticeNum")]
        public int NotificationsCount { get; set; }

        public bool HaveDebt => !string.IsNullOrEmpty(DebtMessage);
        public string DebtMessage { get; set; }
    }
}