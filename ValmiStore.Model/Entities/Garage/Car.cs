namespace Webmall.Model.Entities.Garage
{
    public class Car
    {
        public string ClientId { get; set; }
        public string Id { get; set; }
        public string Vin { get; set; }
        public int? Year { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Modification { get; set; }
        public string MarkaId { get; set; }
        public string ModelId { get; set; }
        public string ModificationId { get; set; }
        public string Comment { get; set; }
        public string Contacts { get; set; }
        public bool IsSelected { get; set; }
    }
}
