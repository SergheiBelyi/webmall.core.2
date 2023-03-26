using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webmall.Model;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Garage;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core.UserSession;
using Webmall.UI.Models.WareComparision;

namespace Webmall.UI.Core
{
    public static class SessionHelper
    {
        // ReSharper disable ConvertToConstant.Global
        // ReSharper disable InconsistentNaming
        //public static readonly string CURRENTUSERSESSIONKEY = "CURRENT_USER";
        //public static readonly string CURRENT_USER_NEXT_CHECK_KEY = "CURRENT_USER_NEXT_CHECK_KEY";
        public static readonly string COMPARISIONLIST = "COMPARISION_LIST";
        public static readonly string CURRENTVIEW = "CURRENT_VIEW";

        public static readonly string IIS_TIME = "IIS_TIME";
        public static readonly string DB_TIME = "DB_TIME";
        public static readonly string PREV_REQ_TIMES = "PREV_TIME";

        private static readonly string priceFormat = ConfigHelper.PriceFormat;

        private static readonly Client defaultClient;

        // ReSharper restore InconsistentNaming
        // ReSharper restore ConvertToConstant.Global



        //public static bool NeedUserCheck => HttpContext.Current.Session?[CURRENT_USER_NEXT_CHECK_KEY] != null
        //    && ((DateTime)HttpContext.Current.Session?[CURRENT_USER_NEXT_CHECK_KEY]) < DateTime.Now;

        static SessionHelper()
        {
            var clientRepository = DependencyResolver.Current.GetService<IClientRepository>();
            defaultClient = clientRepository.GetFullClientInfo(ConfigHelper.DefaultClientId);
        }

        private static readonly UserSessionStorage ActiveUsers = new UserSessionStorage();

        /// <summary>
        /// Возвращает информацию о текущем пользователе, null - пользователь незалогинен
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                var context = HttpContext.Current;
                if (context.Session == null || context.User?.Identity.IsAuthenticated != true) return null;
                var sessionId = context.Session.SessionID;
                User user = null;
                UserSessionData userSessionData = null;
                if (ActiveUsers.TryGetValue(context.User.Identity.Name, out var userSessions))
                {
                    // Получение пользователя для текущей сессии
                    if (userSessions.TryGetValue(sessionId, out userSessionData) && !userSessionData.NeedUserCheck)
                    {
                        user = userSessionData.User;
                    }
                }

                // ReSharper disable once ConstantConditionalAccessQualifier
                if (user != null && userSessionData?.NeedUserRelogin != true) return user;

                //var userRepository = (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));
                var newUser =  LoadUser(context.User.Identity.Name);
                if (newUser != null)
                {
                    if (newUser.IsBlocked || userSessionData?.NeedUserRelogin == true || (user != null && !newUser.Presenters.Exists(i => i.ClientId == user.CurrentClientId)))
                    {
                        if (userSessionData != null)
                            userSessions.Remove(sessionId);
                        System.Web.Security.FormsAuthentication.SignOut();
                        ClearSession();
                    }
                    else
                    {
                        newUser.IP = context.Request.ServerVariables["REMOTE_ADDR"];
                        // Восстанавливаем текущего клиента, чтобы не было скрытых переключений
                        user = newUser;
                        if (userSessionData != null)
                        {
                            userSessionData.User = newUser;
                            newUser.CurrentClientId = userSessionData.User?.CurrentClientId;
                        }
                        else
                        {
                            userSessionData = new UserSessionData { User = user, Session = context.Session };
                            if (userSessions == null)
                            {
                                userSessions = new UserSessions();
                                try
                                {
                                    ActiveUsers.Add(user.Login, userSessions);
                                }
                                catch (ArgumentException) { userSessions = ActiveUsers[user.Login]; }
                            }

                            try
                            {
                                userSessions.Add(sessionId, userSessionData);
                            }
                            catch (ArgumentException) { }
                        }
                    }
                }
                else
                {
                    if (userSessionData != null)
                        userSessions.Remove(sessionId);
                }
                return user;
            }
        }

        public static void InvalidateUser(string login, bool exceptCurrentUser = false)
        {
            if (exceptCurrentUser)
            {
                var sessionId = HttpContext.Current?.Session.SessionID;
                //var currentUSer = CurrentUser;
                if (ActiveUsers.ContainsKey(login))
                {
                    var sessions = ActiveUsers[login];
                    foreach (var key in sessions.Keys.Where(i => i != sessionId))
                        sessions[key].NeedUserRelogin = true;
                    //sessions.Remove(key);
                }
            }
            else
                ActiveUsers.InvalidateUserForAllSessions(login);
        }

        public static void InvalidateCurrentUser(string login)
        {
            var sessionId = HttpContext.Current?.Session.SessionID;
            //var currentUSer = CurrentUser;
            if (ActiveUsers.ContainsKey(login) && sessionId != null)
            {
                var sessions = ActiveUsers[login];
                sessions.Remove(sessionId);
            }
        }

        /// <summary>
        /// Возвращает текущую форму представления каталога
        /// </summary>
        public static int CurrentView
        {
            get
            {
                var context = HttpContext.Current;

                if (context.Session[CURRENTVIEW] == null)
                {
                    // Если оптовик - то таблица, иначе - плитка
                    context.Session[CURRENTVIEW] = IsGross ? 0 : 1;
                }
                return (int)context.Session[CURRENTVIEW];
            }
            set => HttpContext.Current.Session[CURRENTVIEW] = value;
        }

        public static string PrevReqTime
        {
            get => (string)HttpContext.Current?.Session?[PREV_REQ_TIMES];
            set
            {
                if (HttpContext.Current?.Session?[PREV_REQ_TIMES] != null)
                    HttpContext.Current.Session[PREV_REQ_TIMES] = value;
            }
        }

        public static void ClearSession()
        {
            var context = HttpContext.Current;
            Cart = null;
            //context.Session.Remove(CURRENTUSERSESSIONKEY);
            context.Session.Remove(CURRENTVIEW);
        }

        public static string CurrentClientId => CurrentUser?.CurrentClientId ?? defaultClient?.Id ?? ConfigHelper.DefaultClientId;

        public static Client CurrentClient => CurrentUser?.CurrentPresenter?.Client ?? defaultClient;

        public static string CurrentClientCode => CurrentClient?.Code;

        public static string CurrentClientName => CurrentClient?.Name;

        /// <summary>
        /// Текущий клиент - опт
        /// </summary>
        public static bool IsGross => CurrentClient?.IsGross ?? false;

        /// <summary>
        /// Текущий клиент - розница
        /// </summary>
        public static bool IsRetail => !IsGross;

        public static bool AllowCustomOrders => CurrentClient?.AllowCustomOrders ?? false;

        public static bool IsSupplier => CurrentClient?.IsSupplier ?? false;

        public static bool IsCustomer => CurrentClient?.IsCustomer ?? false;
        
        public static bool ShowRetailPrice => CurrentUser?.Configuration.ShowRetailPrice ?? false;

        /// <summary>
        /// Текущий клиент - менеджер оргазнизации (видит все остатки)
        /// </summary>
        public static bool IsOrganizationManager => CurrentClient?.IsOrganizationManager ?? false;

        ///// <summary>
        ///// Текущий клиент - Разрешена розница
        ///// </summary>
        //public static bool IsRetailEnabled => CurrentUser?.CurrentClient?.Client?.RetailEnabled ?? false;

        /// <summary>
        /// Текущий клиент - Разрешена доставка для розницы
        /// </summary>
        public static bool IsRetailDeliveryEnabled => CurrentUser?.CurrentPresenter?.Client?.IsDeliveryEnabled ?? false;

        public static bool IsLimitSession => CurrentUser != null && ConfigHelper.SessionLimitIPs != null && ConfigHelper.SessionLimitIpsList.Contains(HttpContext.Current.Request.UserHostAddress);

        /// <summary>
        /// Текущий клиент - Разрешено делать заказы
        /// </summary>
        public static bool CanMakeOrders => CurrentUser?.CurrentPresenter?.CanMakeOrders ?? false;

        /// <summary>
        /// Текущий клиент - Разрешена запись на СТО
        /// </summary>
        public static bool AllowServiceBooking => !IsGross && ConfigHelper.AllowServiceBooking;

        /// <summary>
        /// Текущий клиент - Сообщение для показа в диалоге
        /// </summary>
        public static string ShowDialogMessage => CurrentUser?.CurrentPresenter?.ShowDialogMessage;
        public static bool CheckShowDialogMessage => CurrentUser?.CurrentPresenter?.CheckShowDialogMessage ?? false;

        public static Valute CurrentValute
        {
            get
            {
                Valute result = null;
                var currentClient = CurrentClient;
                if (currentClient != null && !ConfigHelper.ForceDefaultValute)
                {
                    var valuteId = CurrentClient.CurrentValute;
                    result = CurrentClient.Valutes?.FirstOrDefault(i => i.Id == valuteId) ?? CurrentClient.Valutes?.FirstOrDefault();
                }
                return result ?? DefaultValute;
            }
        }

        public static string PriceFormat(decimal? price)
        {
            return string.Format(priceFormat, price);
        }

        private static Valute _defaultValute;
        public static Valute DefaultValute
        {
            get
            {
                return _defaultValute ?? (_defaultValute = Valutes.FirstOrDefault(
                    i => i.Id == ConfigHelper.DefaultValute)
                       ??
                       new Valute
                       {
                           Id = ConfigHelper.DefaultValute,
                           Rate = 1,
                           Name = ConfigHelper.DefaultValuteName,
                           Code = ConfigHelper.DefaultValuteName
                       });
            }
        }

        private static IEnumerable<Valute> _unregValutes;
        private static DateTime _forceValuteInvalidation = DateTime.Now;
        private static TimeSpan _regularValuteInvalidation = ConfigHelper.ValuteInvalidationTime;
        
        private static IList<CartPosition> _cart;
        
        public static IEnumerable<Valute> Valutes
        {
            get
            {
                if (CurrentClient == null)
                {
                    if (_unregValutes == null)
                    {
                        var referenceRepository = DependencyResolver.Current.GetService<IReferenceRepository>();
                        _unregValutes = referenceRepository.GetValutes(null, UserPreferences.CurrentCulture);
                    }
                    return _unregValutes;
                }
                if (CurrentClient.Valutes == null
                    || CurrentClient.LastValuteUpdate <= _forceValuteInvalidation
                    || (CurrentClient.LastValuteUpdate.TimeOfDay < _regularValuteInvalidation && DateTime.Now.TimeOfDay > _regularValuteInvalidation))
                {
                    var referenceRepository = DependencyResolver.Current.GetService<IReferenceRepository>();
                    CurrentClient.Valutes = referenceRepository.GetValutes(CurrentUser, UserPreferences.CurrentCulture);
                    CurrentClient.LastValuteUpdate = DateTime.Now;
                }
                return CurrentClient.Valutes;
            }
        }

        public static string CurrentWarehouseId => CurrentClient?.CurrentWarehouseId;

        public static List<SelectListItem> AvailableWarehouses => CurrentUser?.CurrentPresenter?.GetAvailableWarehouses(UserPreferences.CurrentCulture);

        public static string CurrentWarehouseName
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(CurrentWarehouseId))
                        return AvailableWarehouses.First(i => i.Value == CurrentWarehouseId).Text;
                    return
                        AvailableWarehouses.OrderBy(i => i.Value).First().Text;
                }
                catch (Exception)
                {
                    return ViewRes.SharedResources.NoData;
                }
            }
        }

        /// <summary>
        /// Список элеметов, отобранных для сравнения
        /// </summary>
        public static ComparisionList ComparisionList
        {
            get
            {
                var context = HttpContext.Current;
                if (context.Session[COMPARISIONLIST] == null)
                    context.Session[COMPARISIONLIST] = new ComparisionList();
                return (ComparisionList)context.Session[COMPARISIONLIST];
            }
        }

        /// <summary>
        /// Позиции корзины
        /// </summary>
        public static IList<CartPosition> Cart
        {
            get
            {
                if (_cart == null && CurrentClientId != null)
                {
                    var cartRepository = DependencyResolver.Current.GetService<ICartRepository>();
                    _cart = cartRepository.GetCart("", CurrentUser);
                }
                return _cart;
            }
            set => _cart = value;
        }


        private static Dictionary<string, List<Car>> _garages = new Dictionary<string, List<Car>>();
        /// <summary>
        /// Позиции корзины
        /// </summary>
        public static List<Car> Garage
        {
            get
            {
                if (CurrentUser == null) return null;

                var clientId = CurrentClientId;
                if (_garages.ContainsKey(clientId))
                    return _garages[clientId];

                var garageRepository = DependencyResolver.Current.GetService<IGarageRepository>();
                var cars = garageRepository.GetCars(clientId);

                _garages.Add(clientId, cars);

                return cars;
            }
        }

        public static void InvalidateGarage()
        {
            if (CurrentUser == null) return;

            var clientId = CurrentClientId;
            if (_garages.ContainsKey(clientId))
                _garages.Remove(clientId);
        }

        //public static string RequestTimeToString()
        //{
        //    const string fmt = "mm\\:ss\\.fff";

        //    var siteTime = DateTime.Now - (DateTime)HttpContext.Current.Items[IIS_TIME];
        //    var dbTime = HttpContext.Current.Items[DB_TIME] != null ? new TimeSpan?((TimeSpan)HttpContext.Current.Items[DB_TIME]) : null;
        //    var time1 = siteTime.ToString(fmt);
        //    var time2 = dbTime != null ? ", DB: " + dbTime.Value.ToString(fmt) : "";
        //    return time1 + time2;
        //}

        public static void InvalidateValutes()
        {
            _unregValutes = null;
            _forceValuteInvalidation = DateTime.Now;
            foreach (var item in ActiveUsers)
            {
                foreach (var session in item.Value)
                {
                    foreach (var presenter in session.Value.User.Presenters)
                    {
                        presenter.Client.Valutes = null;
                    }
                }
            }

        }

        private static User LoadUser(string login)
        {
            var userRepository = (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));
            var user = userRepository.GetUser(login);

            if (user == null)
                return null;

            var clientRepository = (IClientRepository)DependencyResolver.Current.GetService(typeof(IClientRepository));
            user.CurrentPresenter.Client = clientRepository.GetFullClientInfo(user.CurrentPresenter.ClientId);
            if (user.CurrentPresenter.Client == null)
            {
                foreach (var presenter in user.ActivePresenters.ToArray())
                {
                    presenter.Client = clientRepository.GetFullClientInfo(presenter.ClientId);
                    if (presenter.Client != null)
                    {
                        user.CurrentPresenter = presenter;
                        presenter.Client.IsLoaded = true;
                        break;
                    }
                }
            }
            else
            {
                user.CurrentPresenter.Client.IsLoaded = true;
            }

            return user;
        }
    }
}