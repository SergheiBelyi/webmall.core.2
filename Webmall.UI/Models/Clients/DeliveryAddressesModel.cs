using Newtonsoft.Json;
using System.Collections.Generic;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Delivery;

namespace Webmall.UI.Models.Clients
{
    public class DeliveryAddressesModel
    {
        [JsonProperty("allowEdit")]
        public bool AllowEdit { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
        [JsonProperty("addresses")]
        public List<DeliveryAddress> Addresses { get; set; }
        [JsonIgnore]
        public string EditCallback { get; set; }
        [JsonProperty("maxAddresses")]
        public int MaxAddresses { get; set; }
    }
}