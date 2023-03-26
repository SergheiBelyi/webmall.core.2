namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Данные модификации для автомобиля
    /// </summary>
    public class AutoModificationFull : AutoModificationData
    {
        public AutoModel Model { get; set; }
        public AutoMarka Marka { get; set; }
        public string BodyTypeName { get; set; }
        public string BrakeTypeName { get; set; }
        public string BrakeSystemName { get; set; }
        public string CatalystTypeName { get; set; }
        public string DriveTypeName { get; set; }
        public string EngineTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public string TransmissionTypeName { get; set; }
        public string VehicleTypeName { get; set; }
    }
}
