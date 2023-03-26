using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Order;

namespace Webmall.Cms.Squidex.Cms.Models.Order
{
    public class PaymentData
    {
        public LString Name { get; set; }
        public LString Description { get; set; }
        public Dictionary<string, List<FileList>> FileList { get; set; }
        public Dictionary<string, List<CheckboxList>> CheckboxList { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string ViewName { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public int Sort { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string PaymentTypeId { get; set; }
    }
}
