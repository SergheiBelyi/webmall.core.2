using System;
using Webmall.Model.Entities.Auto;

namespace ValmiStore.Model.Entities
{
    /// <summary>
    /// Применимость
    /// </summary>
    public class Applicability
    {
        public Applicability()
        {
        }
        
        public Applicability(AutoModification item)
        {
            Id = item.Id;
            Modification = item.Name;
            DateBegin = item.DateBegin;
            DateEnd = item.DateEnd;
            ccmTech = item.CcmTech;
            PS = item.PS;
            kW = item.KW;
            BodyTypeName = item.BodyTypeName;
        }

        public string Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Modification { get; set; }
        public decimal? ccmTech { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? PS { get; set; }
        public int? kW { get; set; }
        public string BodyTypeName { get; set; }
    }
}