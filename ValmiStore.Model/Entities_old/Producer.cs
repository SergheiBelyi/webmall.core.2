using Webmall.Model;

namespace ValmiStore.Model.Entities
{
    public class Producer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        //public bool IsOurProducer { get; set; }
        public bool IsOEM { get; set; }
        public string URL => Helper.RemoveBadURLSymbols(Name, true).ToLower();
    }
}