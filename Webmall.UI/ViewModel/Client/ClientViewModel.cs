using System.Collections.Generic;
using Webmall.Model.Entities.User;

namespace Webmall.UI.ViewModel.Client
{
    public class ClientViewModel
    {

        //public IEnumerable<SelectListItem> Warehouses;
        public ClientPresenter CurrentClientPresenter { get; set; }

        public Model.Entities.Client.Client Client { get; set; }

        //public ClientPresenter[] AllPresenters;
        //public SelectListItem [] Streets;
        //public SelectListItem [] Cities;
        //public DeliveryAddress Address;

        public List<ClientPresenter> AllClientPresenters { get; set; }

        public bool HaveClient => Client != null;
    }
}