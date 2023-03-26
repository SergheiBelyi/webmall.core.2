using System.Collections.Generic;

namespace Webmall.UI.Models.TV
{
// ReSharper disable once InconsistentNaming
    public class TVModel
    {
        public List<VideoInfo> PlayList { get; set; }

        public int WarehouseId = 1;
        public WeatherCities City = WeatherCities.Chisinau;
        public string RunningLineText { get; set; }
    }
}