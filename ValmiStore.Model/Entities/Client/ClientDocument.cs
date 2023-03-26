using Webmall.Model.Entities.References;

namespace Webmall.Model.Entities.Client
{
    public class ClientDocument : SimpleReferenceItem
    {
        public string Series { get; set; }
        public string Number { get; set; }
        // ReSharper disable once InconsistentNaming
        public string FIO { get; set; }
        public string DocTypeName { get; set; }
    }
}