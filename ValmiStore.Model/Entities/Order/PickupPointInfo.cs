using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmall.Model.Entities.Order
{
    public class PickupPointInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? MaxWeight { get; set; }
        public string Schedule { get; set; }
        public string Comment { get; set; }
        public bool? CanTakeMoney { get; set; }
    }
}
