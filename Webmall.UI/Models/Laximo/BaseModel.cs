namespace Webmall.UI.Models.Laximo
{
    public class BaseModel
    {
        public string VehicleId { get; set; }
        public string CatalogId { get; set; }
        public string CategoryId { get; set; }
        public string UnitId { get; set; }
        public string Ssd { get; set; }
        public string Type { get; set; }

        public BaseModel Clone()
        {
            return new BaseModel
            {
                VehicleId = VehicleId,
                CatalogId = CatalogId,
                CategoryId = CategoryId,
                UnitId = UnitId,
                Ssd = Ssd,
                Type= Type
            };
        }
    }
}