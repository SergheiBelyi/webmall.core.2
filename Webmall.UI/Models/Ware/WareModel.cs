using System.Collections.Generic;
using ValmiStore.Model.Entities;
using ValmiStore.Model.Entities.Order;

namespace Webmall.UI.Models.Ware
{
    public class WareModel
    {
        public WareModel()
        {
            Offers = new List<Offer>();
            WareProperties = new List<WareProperty>();
        }

        //public bool IsAutoTrend { get; set; }
        public Model.Entities.Catalog.Ware Ware { get; set; }
        private List<Offer> _offers;
        public List<Offer> Offers {
            get => _offers;
            set
            {
                _offers = value;
                if (Ware != null && _offers != null && _offers.Count > 0)
                {
                    //var baseOffer = _offers.FirstOrDefault(o => o.OfferTypeId == 1) ?? _offers.FirstOrDefault();

                    //Ware.MainValutePrice = baseOffer.MainValutePrice;
                    //Ware.ClientPrice = baseOffer.Price;
                    //Ware.RetailPrice = baseOffer.RetailPrice;
                }
            }
        }
        public WareAvailabilityWrapper WareAvailability { get; set; }
        public List<WareProperty> WareProperties { get; set; }

        public List<WareProperty> AllWareProperties
        {
            get
            {
                var result = new List<WareProperty>(WareProperties);
                // Внимание! Результат в обратном порядке
                //if (Ware.PackWeight > 0)
                //    result.Insert(0, new WareProperty { Name = SharedResources.PackWeight, Value = Ware.PackWeight.ToString(CultureInfo.InvariantCulture) });
                //if (Ware.PackWidth > 0)
                //    result.Insert(0, new WareProperty { Name = SharedResources.PackWidth, Value = Ware.PackWidth.ToString(CultureInfo.InvariantCulture) });
                //if (Ware.PackLen > 0)
                //    result.Insert(0, new WareProperty { Name = SharedResources.PackLength, Value = Ware.PackLen.ToString(CultureInfo.InvariantCulture) });
                //if (Ware.PackQnt > 0)
                //    result.Insert(0, new WareProperty {Name = SharedResources.PackQnt, Value = Ware.PackQnt.ToString(CultureInfo.InvariantCulture)});
                //if (Ware.WareHeight > 0)
                //    result.Insert(0, new WareProperty {Name = SharedResources.WareHeight, Value = Ware.WareHeight.ToString(CultureInfo.InvariantCulture)});
                //if (Ware.WareWidth > 0)
                //    result.Insert(0, new WareProperty { Name = SharedResources.WareWidth, Value = Ware.WareWidth.ToString(CultureInfo.InvariantCulture) });
                //if (Ware.WareLen > 0)
                //    result.Insert(0, new WareProperty { Name = SharedResources.WareLength, Value = Ware.WareLen.ToString(CultureInfo.InvariantCulture) });
                //if (Ware.WareWeight > 0)
                //    result.Insert(0, new WareProperty {Name = SharedResources.WareGrossWeight, Value = Ware.WareWeight.ToString(CultureInfo.InvariantCulture)});
                return result;
            }
        }

        public List<Group> WareGroups { get; set; }

    }
}