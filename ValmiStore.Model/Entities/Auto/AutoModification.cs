using System;

namespace Webmall.Model.Entities.Auto
{
    public class AutoModification
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AutoMarka Mark { get; set; }
        public AutoModel Model { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string ModifRem { get; set; }
        public int? KW { get; set; }
        public int? PS { get; set; }
        public int? CcmTech { get; set; }
        public int? Zyl { get; set; }
        public int? Tueren { get; set; }
        public int? TankInhalt { get; set; }
        public int? Spannung { get; set; }
        public bool ABS { get; set; }
        public bool? ASR { get; set; }
        public string EngineType { get; set; }
        public string EngineCode { get; set; }
        public string VehType { get; set; }
        public string DriveType { get; set; }
        public string BrakeType { get; set; }
        public string BrakeSysType { get; set; }
        public string FuelType { get; set; }
        public string FuelTypeId { get; set; }
        public string CatalystType { get; set; }
        public string TransType { get; set; }
        public string BodyTypeName { get; set; }
        public string AxleForm { get; set; }

    }
}
