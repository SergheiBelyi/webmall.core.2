using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using ViewRes;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Entities.User
{
    /// <summary>
    /// Представительство
    /// </summary>
    public class ClientPresenter
    {
        public int Id { get; set; }

        public bool IsKeyRepresentative => (Roles & (long)RepresentativeRole.KeyRepresentative) != 0;

        public bool IsComparisionUser => (Roles & (long)RepresentativeRole.Verification) != 0;

        public bool CanSeeAllOrders => (Roles & (long)RepresentativeRole.AllOrders) != 0;

        public bool CanSeeAllCart => (Roles & (long)RepresentativeRole.AllOrders) != 0 || IsManaged;

        public bool CanSeePrices => (Roles & (long)RepresentativeRole.ViewPrices) != 0 || !ConfigHelper.AllowHidePrices; 

        /// <summary>
        /// Разрешение делать заказ (должна быть установлена роль и не должен быть розничный клиент без разрешения розницы) 
        /// </summary>
        public bool CanMakeOrders => (Roles & (long) RepresentativeRole.Trade) != 0 &&
                                     !((Client?.IsRetail ?? true)/* && !(Client?.RetailEnabled ?? false)*/);

        public string ClientId { get; set; }
        public int UserId { get; set; }
        public bool IsAccepted { get; set; }

        public Client.Client Client { get; set; } = new Client.Client();

        public User User { get; set; }

        public long Roles { get; set; }

        public List<string> RoleCodes
        {
            get
            {
                var list = typeof(RepresentativeRole).GetEnumNames()
                    .Where(r => Roles.IsFlagSet((long)Enum.Parse(typeof(RepresentativeRole), r)))
                    .Select(r => "PrRole_" + r);
                return list.ToList();
            }
        }

        /// <summary>
        /// Признак того, что текущий пользователь является менеджером клиента, а не его представителем
        /// </summary>
        public bool IsManaged { get; set; }

        private Dictionary<string, List<SelectListItem>> AvailableWarehouses { get; } = new Dictionary<string, List<SelectListItem>>();

        public List<SelectListItem> GetAvailableWarehouses(string culture)
        {
            if (!AvailableWarehouses.Keys.Contains(culture))
            {
                var referenceRepository = DependencyResolver.Current.GetService<IReferenceRepository>();
                AvailableWarehouses.Add(culture, referenceRepository.GetWarehouses(Client?.Id, culture)
                    .Select(i => new SelectListItem { Text = i.Value, Value = i.Id.ToString() }).ToList());
            }
            var id = Client?.CurrentWarehouseId;
            foreach (var availableWarehouse in AvailableWarehouses[culture])
            {
                availableWarehouse.Selected = (availableWarehouse.Value == id);
            }
            return AvailableWarehouses[culture];
        }

        ///// <summary>
        ///// Признак факта проверки наличия уведомлений
        ///// true - уведомления проверены, false - требуется проверка
        ///// </summary>
        //public bool MessageChecked { get; set; }


        private bool _isDialogMessageShowed;

        /// <summary>
        /// Сообщение для всплывающего диалога
        /// </summary>
        public string ShowDialogMessage => SharedResources.RetailIsBlockedMessage;

        /// <summary>
        /// Сообщение для всплывающего диалога
        /// </summary>
        public bool CheckShowDialogMessage
        {
            get
            {
                if (Client != null && !_isDialogMessageShowed /*&& Client.IsRetail && !Client.RetailEnabled*/)
                {
                    _isDialogMessageShowed = true;
                    return true;
                }
                return false;
            }
        }

        //private List<MarketingAction> _marketingActions;
        //public List<MarketingAction> MarketingActions
        //{
        //    get
        //    {
        //        if (_marketingActions == null)
        //        {
        //            var marketingActionsRepository = DependencyResolver.Current.GetService<IMarketingActionsRepository>();
        //            _marketingActions = marketingActionsRepository.GetActions(Client.Id, DateTime.Now.AddYears(-1), DateTime.Now);
        //        }
        //        return _marketingActions ?? (_marketingActions = new List<MarketingAction>());
        //    }
        //}

    }
    /// <summary>
    /// Коды ролей предстваительства
    /// </summary>
    public enum RepresentativeRole : long
    {
        KeyRepresentative = 1,
        AllOrders = 2,
        Verification = 4,
        Trade = 8,
        ViewPrices = 16
    }
}
