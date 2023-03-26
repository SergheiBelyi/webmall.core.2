using System.Collections.Generic;
using System.Linq;
using Webmall.Laximo.Entities;

namespace Webmall.UI.Models.Laximo
{
    public class UnitModel : BaseModel
    {
        public VehicleInfo VehicleInfo { get; set; }

        public UnitInfo UnitInfo { get; set; }

        public List<DetailInfo> Details { get; set; }

        private Dictionary<string, string> _extAttrTitles;
        public Dictionary<string, string> ExtAttrTitles
        {
            get
            {
                return _extAttrTitles ?? (_extAttrTitles = Details.Aggregate(new Dictionary<string, string>(), (s, info) =>
                {
                    foreach (var item in info.ExtAttributes)
                    {
                        if (!s.ContainsKey(item.Key))
                            s.Add(item.Key, item.Name);
                    }

                    return s;
                }));
            }
        }

        public List<string> SelectedDetailСodes { get; set; }
        
        public List<ImageMapRow> ImageMaps { get; set; }
    }
}