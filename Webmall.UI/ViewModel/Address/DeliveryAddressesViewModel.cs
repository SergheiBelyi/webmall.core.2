using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.UI.Models.Clients;

namespace Webmall.UI.ViewModel.Address
{
    public class DeliveryAddressesViewModel
    {
        public Model.Entities.Client.Client Client { get; set; }

        public DeliveryAddressesModel Addresses { get; set; }

        //public List<DeliveryAddress> Addresses { get; set; }

        public List<SelectListItem> Regions { get; set; }
    }
}