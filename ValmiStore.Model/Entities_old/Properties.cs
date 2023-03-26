using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValmiStore.Model.Entities
{
    public class Properties
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public List<string> AllowableValues { get; set; }
    }
}