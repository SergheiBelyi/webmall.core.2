using System.Collections.Generic;

namespace Webmall.UI.Models
{
    public class ReviewModel
    {
        public string Name { get; set; }
        public string ServiceDate { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<string> Addresses { get; set; } = new List<string>();
    }
}