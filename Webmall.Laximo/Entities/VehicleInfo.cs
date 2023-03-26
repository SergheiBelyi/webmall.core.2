using System.Collections.Generic;
using Laximo.Guayaquil.Data.Entities;
using Webmall.Laximo.Core;

namespace Webmall.Laximo.Entities
{
    public class VehicleInfo
    {
        /// <summary>
        /// VIN код
        /// </summary>
        //public string Vin { get; set; }
        /// <summary>
        /// Идентификатор автомобиля или модели автомобиля в рамках каталога.
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// Производитель автомобиля
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Код модели автомобиля
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Наименование автомобиля, по возможности, на запрошенном языке
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Комплектация автомобиля
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// Тип коробки передач
        /// </summary>
        public string Transmission { get; set; }
        /// <summary>
        /// Количество дверей
        /// </summary>
        public string Doors { get; set; }
        /// <summary>
        /// Код региона производства
        /// </summary>
        public string CreationRegion { get; set; }
        /// <summary>
        /// Код региона поставки
        /// </summary>
        public string DestinationRegion { get; set; }
        /// <summary>
        /// Дата производства автомобиля (ГГГГММ)
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Год производства автомобиля (ГГГГ)
        /// </summary>
        public string Manufactured { get; set; }
        /// <summary>
        /// Код цвета кузова
        /// </summary>
        public string Framecolor { get; set; }
        /// <summary>
        /// Код цвета салона
        /// </summary>
        public string Trimcolor { get; set; }
        /// <summary>
        /// Период выпуска модификации
        /// </summary>
        public string DateFrom { get; set; }
        /// <summary>
        /// Период выпуска модификации
        /// </summary>
        public string DateTo { get; set; }
        /// <summary>
        /// Код кузова
        /// </summary>
        public string Frame { get; set; }
        /// <summary>
        /// Перечисление кодов кузовов модели
        /// </summary>
        public string Frames { get; set; }
        /// <summary>
        /// Диапазон кузовов
        /// </summary>
        public string FrameFrom { get; set; }
        /// <summary>
        /// Диапазон кузовов
        /// </summary>
        public string FrameTo { get; set; }
        /// <summary>
        /// Код двигателя
        /// </summary>
        public string Engine { get; set; }
        /// <summary>
        /// Код двигателя
        /// </summary>
        public string Engine1 { get; set; }
        /// <summary>
        /// Код двигателя
        /// </summary>
        public string Engine2 { get; set; }
        /// <summary>
        /// Диапазон номеров двигателя
        /// </summary>
        public string EngineNo { get; set; }
        /// <summary>
        /// Перечень опций, по возможности, на запрошенном языке
        /// </summary>
        public string Options { get; set; }
        /// <summary>
        /// Года выпуска модели
        /// </summary>
        public string ModelYearFrom { get; set; }
        /// <summary>
        /// Года выпуска модели
        /// </summary>
        public string ModelYearTo { get; set; }
        /// <summary>
        /// Модификация
        /// </summary>
        public string Modification { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        // ReSharper disable once InconsistentNaming
        public string MVS { get; set; }
        public string V { get; set; }
        public string Drive { get; set; }
        public string ProdRange { get; set; }
        public string Market { get; set; }
        public string Country { get; set; }

        private readonly List<string> _fixedAttrs = new List<string>
        {
            "brand", "name", "model",
            //"engine", "transmission", "date", "engineno", "market", "country", "prodrange", "framecolor","trimcolor"
            //,"doors", "creationregion", "destinationregion",
            //"grade", "manufactured","datefrom","dateto","frame","frames","framefrom","frameto",
            //"engine1", "engine2","modelyearfrom","modelyearto","modification","description","MVS","V","drive", 
        };

        public DataAttribute[] ExtAttributes { get; set; }

        /// <summary>
        /// Код каталога, если поиск ведется по VIN без указания каталога
        /// </summary>
        public string CatalogId { get; set; }
        /// <summary>
        /// Данные сервера
        /// </summary>
        public string Ssd { get; set; }

        public VehicleInfo() { }

        public VehicleInfo(global::Laximo.Guayaquil.Data.Entities.VehicleInfo vI)
        {
            VehicleId = vI.vehicleid;
            Brand = vI.Brand;
            Model = vI.getAttribute("model");
            Name = vI.name;
            Grade = vI.getAttribute("grade");
            Transmission = vI.getAttribute("transmission");
            Doors = vI.getAttribute("doors");
            CreationRegion = vI.getAttribute("creationregion");
            DestinationRegion = vI.getAttribute("destinationregion");
            Date = vI.getAttribute("date");
            Manufactured = vI.getAttribute("manufactured");
            Framecolor = vI.getAttribute("framecolor");
            Trimcolor = vI.getAttribute("trimcolor");
            DateFrom = vI.getAttribute("datefrom");
            DateTo = vI.getAttribute("dateto");
            ProdRange = vI.getAttribute("prodrange");
            Frame = vI.getAttribute("frame");
            Frames = vI.getAttribute("frames");
            FrameFrom = vI.getAttribute("framefrom");
            FrameTo = vI.getAttribute("frameto");
            Engine = vI.getAttribute("engine");
            Engine1 = vI.getAttribute("engine1");
            Engine2 = vI.getAttribute("engine2");
            EngineNo = vI.getAttribute("engineNo");
            ModelYearFrom = vI.getAttribute("modelyearfrom");
            ModelYearTo = vI.getAttribute("modelyearto");
            Modification = vI.getAttribute("modification");
            Description = vI.getAttribute("description");
            MVS = vI.getAttribute("MVS");
            V = vI.getAttribute("V");
            Drive = vI.getAttribute("drive");
            Market = vI.getAttribute("market");
            Country = vI.getAttribute("country");
            CatalogId = vI.catalog;
            Ssd = vI.ssd;
            ExtAttributes = PropertyHelper.GetExtProperties(vI.Attributes, _fixedAttrs);
        }

    }
}