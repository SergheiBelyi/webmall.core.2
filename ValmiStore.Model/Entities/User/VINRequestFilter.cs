using System;

namespace Webmall.Model.Entities.User
{
    public class VINRequestFilter
    {
        public bool? IsResponded { get; set; }

        public DateTime? RequestStartDate { get; set; }

        public DateTime? RequestEndDate { get; set; }

        public string PartName { get; set; }
    }
}
