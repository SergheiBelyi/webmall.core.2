using System.Collections.Generic;

namespace ValmiStore.Model.Entities
{
    public class ProducersList 
    {
        public ProducersList()
        {
            List = new List<Producer>();
        }
        //public decimal MinPrice { get; set; }

        //public decimal MaxPrice { get; set; }

        public List<Producer> List { get; set; }
    }
}