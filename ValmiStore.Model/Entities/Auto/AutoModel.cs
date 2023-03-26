using System;

namespace Webmall.Model.Entities.Auto
{
    public class AutoModel
    {
        private string _shortName;
        public string Id { get; set; }
        public string MarkaId { get; set; }
        public string Name { get; set; }

        public string ShortName
        {
            get => _shortName ?? Name?.Split(' ')[0];
            set => _shortName = value;
        }

        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string UrlName { get; set; }
    }
}
