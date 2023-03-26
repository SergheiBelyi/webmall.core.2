using System;

namespace Webmall.Model.Entities.Auto
{
    public class Applicability
    {
        public string Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Modification { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int KW { get; set; }
        public int PS { get; set; }
        public int CcmTech { get; set; }
        public string BodyTypeName { get; set; }
    }
}
