

// ReSharper disable InconsistentNaming

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Данные модификации для автомобиля
    /// </summary>
    public class AutoModificationData : AutoModificationBase
    {
        /// <summary>
        /// Комментарий
        /// </summary>        
        public string Description { get; set; }

        public int? TDCode { get; set; }

        /// <summary>
        /// Мощность, кВт
        /// </summary>
        public int? kW { get; set; }

        /// <summary>
        /// Максимальная мощность, кВт
        /// </summary>
        public int? kWMax { get; set; }

        /// <summary>
        /// Максимальная мощность, л.с.
        /// </summary>
        public int? PSMax { get; set; }

        /// <summary>
        /// Объем, куб.см (Германия)
        /// </summary>
        public int? ccmSteuer { get; set; }

        /// <summary>
        /// Объем, л * 100 (99V99)
        /// </summary>
        public int? Liters { get; set; }

        /// <summary>
        /// Число цилиндров
        /// </summary>
        public int? Cilinders { get; set; }

        /// <summary>
        /// Число клапанов
        /// </summary>
        public int? Valves { get; set; }

        /// <summary>
        /// Объем бака
        /// </summary>
        public int? TankCapacity { get; set; }

        /// <summary>
        /// Напряжение, В
        /// </summary>
        public int? Voltage { get; set; }

        /// <summary>
        /// 0 = no, 1 = ja, 2 = optional, 9 = unknown
        /// </summary>
        public int? ABS { get; set; }

        /// <summary>
        /// 0 = no, 1 = ja, 2 = optional, 9 = unknown
        /// </summary>
        public int? ASR { get; set; }

        /// <summary>
        /// Тип двигателя, Engine type (KT 080)
        /// </summary>
        public int? EngineTypeId { get; set; }

        /// <summary>
        /// Тип авто, Vehicle type (KT 081)
        /// </summary>
        public int? VehicleTypeId { get; set; }

        /// <summary>
        /// Привод колес, Drive type (KT 082)
        /// </summary>
        public int? DriveTypeId { get; set; }

        /// <summary>
        /// Тип привода тормозной системы. Brake type (KT 083)
        /// </summary>
        public int? BrakeTypeId { get; set; }

        /// <summary>
        /// Тип тормозного механизма Brake system (KT 084)
        /// </summary>
        public int? BrakeSystemId { get; set; }

        ///// <summary>
        ///// Charger type (KT 087) - нет
        ///// </summary>
        //public int? ChargerType { get; set; }

        /// <summary>
        /// Топливо, Fuel type (KT 088)
        /// </summary>
        public int? FuelTypeId { get; set; }

        /// <summary>
        /// Catalyst type (KT 089)
        /// </summary>
        public int? CatalystTypeId { get; set; }

        /// <summary>
        /// Тип трансмиссии Transmission type (KT 085)
        /// </summary>
        public int? TransmissionTypeId { get; set; }

        /// <summary>
        /// Body construction type (KT 086)
        /// </summary>
        public int? BodyTypeId { get; set; }

        /// <summary>
        /// Колесная формула
        /// </summary>
        public string WheelFormula { get; set; }
    }
}
