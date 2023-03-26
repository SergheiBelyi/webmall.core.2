using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.Order
{
    public class OrderPayment
    {
        public LString Name { get; set; }
        public LString Description { get; set; }
        public LObjectGeneric<List<FileList>> Files { get; set; }
        public LObjectGeneric<List<CheckboxList>> Checkbox { get; set; }

        public string ViewName { get; set; }
        public int Sort { get; set; }
        public string PaymentTypeId { get; set; }
    }
}
