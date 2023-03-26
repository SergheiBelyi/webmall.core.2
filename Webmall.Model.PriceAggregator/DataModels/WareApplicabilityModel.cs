
using System;

namespace Webmall.Model.PriceAggregator.DataModels
{
    public class WareApplicabilityModel
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Modification { get; set; }
        public int MarkOrder { get; set; }
        public int ModelOrder { get; set; }
        public int CcmTech { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int Ps { get; set; }
        public int KW { get; set; }
        public string BodyTypeName { get; set; }
    }
}
