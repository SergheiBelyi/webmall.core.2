using System.Collections.Generic;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Garage;

namespace Webmall.UI.ViewModel.Garage
{
    public class GarageViewModel
    {
        public Model.Entities.Client.Client Client { get; set; }

        public List<Car> Cars { get; set; }
        public List<AutoMarka> AutoMarks { get; set; }
    }
}