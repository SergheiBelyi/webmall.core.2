namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class AutoData
    {
        public int ModifId { get; set; }
        public string ModifName { get; set; }
        public int ModelDetailId { get; set; }
        public string ModelDetailName { get; set; }
        //public string ModelShName { get; set; }
        public int MarkaId { get; set; }
        public string MarkaName { get; set; }

        public string MarkURLName { get; set; }
        public string ModelURLName { get; set; }
        public string ModelDetailURLName { get; set; }
        public string ModifURLName { get; set; }

        public int? ImageId { get; set; }
    }
}
