using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Webmall.Model.Entities.User
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    [Serializable]
    public class User
    {
        //private readonly string _phonePrefix = ConfigHelper.PhonePrefix;
        //private readonly int _maxPhoneLength = ConfigHelper.MaxPhoneLength;

        //private readonly string _fixedPhonePrefix = ConfigHelper.FixedPhonePrefix;
        //private readonly int _maxFixedPhoneLength = ConfigHelper.MaxFixedPhoneLength;
        //private readonly int _minFixedPhoneLength = ConfigHelper.MinFixedPhoneLength;

        public User()
        {
            Configuration.SendOrderResume = ConfigHelper.DefaultOrderResumeSubscription;
        }

        #region MyRegion


        public int Id { get; set; }

        /// <summary>
        /// IP-адрес пользователя
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string IP { get; set; }

        /// <summary>
        /// Код пользователя учетной системы
        /// </summary>
        public string ExternalSystemCode { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Полное имя пользователя (Имя + Фимилия)
        /// </summary>
        public string FullName
        {
            get => $"{LastName} {FirstName}";
            set
            {
                var sp = value.Split(" ");
                FirstName = sp[0];
                LastName = value.Substring(FirstName.Length, value.Length - FirstName.Length);
            }
        }

        /// <summary>
        /// Адрес электронной почты (сейчас совпадает с логином)
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email => Login;

        /// <summary>
        /// Адрес
        /// </summary>
        public Address.Address Address { get; set; } = new Address.Address();

        public DateTime RegistrationDate { get; set; }

        public string PhoneHome { get; set; }
        //private string _phoneHome;
        //public string PhoneHome
        //{
        //    get => _phoneHome != null && _phoneHome.StartsWith(_fixedPhonePrefix) ? _phoneHome.Substring(_fixedPhonePrefix.Length) : _phoneHome;
        //    set
        //    {
        //        if (value == null)
        //        {
        //            _phoneHome = null;
        //            return;
        //        }
        //        _phoneHome = Regex.Replace(value.TrimStart(ConfigHelper.PhonePrefix), "\\D", "");
        //        if (!string.IsNullOrEmpty(_phoneHome) && _phoneHome.Length > _maxFixedPhoneLength) _phoneHome = _phoneHome.Substring(_phoneHome.Length - _maxFixedPhoneLength);
        //        _phoneHome = _fixedPhonePrefix + _phoneHome;
        //    }
        //}

        //public string PhoneHomeFull
        //{
        //    get => _phoneHome;
        //    set => _phoneHome = value;
        //}

        public string PhoneMobile { get; set; }
        //private string _phoneMobile;
        //public string PhoneMobile
        //{
        //    get => _phoneMobile != null && _phoneMobile.StartsWith(_phonePrefix) ? _phoneMobile.Substring(_phonePrefix.Length) : _phoneMobile;
        //    set
        //    {
        //        if (value == null)
        //        {
        //            _phoneMobile = null;
        //            return;
        //        }
        //        _phoneMobile = Regex.Replace(value.TrimStart(ConfigHelper.PhonePrefix), "\\D", "");
        //        if (!string.IsNullOrEmpty(_phoneMobile) && _phoneMobile.Length > _maxPhoneLength) _phoneMobile = _phoneMobile.Substring(_phoneMobile.Length - _maxPhoneLength);
        //        _phoneMobile = _phonePrefix + _phoneMobile;
        //    }
        //}

        //public string PhoneMobileFull
        //{
        //    get => _phoneMobile;
        //    set => _phoneMobile = value;
        //}

        /// <summary>
        /// Текущий язык пользователя
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Объединенный список телефонов
        /// </summary>
        public string Phones
        {
            get
            {
                var str = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(PhoneHome))
                    str = str.Append(PhoneHome);
                if (!string.IsNullOrWhiteSpace(PhoneMobile))
                {
                    if (str.Length > 0)
                        str.Append(", ");
                    str = str.Append(PhoneMobile);
                }

                return str.ToString();
            }
        }

        public string CurrentClientId
        {
            get => CurrentPresenter?.Client?.Id;
            set
            {
                CurrentPresenter = Presenters?.FirstOrDefault(i => i.Client?.Id == value);
                //if (CurrentPresenter != null) CurrentPresenter.MessageChecked = false;
            }
        }

        #endregion

        #region Presenters


        /// <summary>
        /// Список представительств
        /// </summary>
        public List<ClientPresenter> Presenters { get; set; } = new List<ClientPresenter>();

        /// <summary>
        /// Текущее активное представительство
        /// </summary>
        public ClientPresenter CurrentPresenter { get; set; }

        /// <summary>
        /// Список активных представительств
        /// </summary>
        public List<ClientPresenter> ActivePresenters =>
            Presenters.Where(i => i.IsAccepted && i.Client != null).ToList();

        #endregion


        /// <summary>
        /// Уникальный код для подтверждения регистрации
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public long Status { get; set; }

        /// <summary>
        /// Объединение ролей пользователя + ролей клиента + ролей представительст в общий список символических имен
        /// </summary>
        public string[] Categories =>
            (CurrentPresenter != null 
                ? RoleCodes.Union(CurrentPresenter.RoleCodes).Union(CurrentPresenter.Client?.Categories ?? new List<string>())
                : RoleCodes).ToArray();

        /// <summary>
        /// Признак является ли пользователь администратором
        /// </summary>
        public bool IsAdmin => (Roles & (long)UserRoles.Admin) != 0;

        /// <summary>
        /// Роли пользователя (сумма согласно enum UserRoles) - до 64 ролей
        /// </summary>
        public long Roles { get; set; }

        /// <summary>
        /// Хеш пароля
        /// </summary>
        public string PasswordHash { get; set; }

        public bool IsAccepted { get; set; }
        public bool IsBlocked { get; set; }

        public UserConfiguration Configuration { get; set; } = new UserConfiguration();

        /// <summary>
        /// Наличие у пользователя долговой блокировки
        /// </summary>
        public bool HaveDebtBlock { get; set; }

        /// <summary>
        ///  Дата и время последнего входа в систему
        /// </summary>
        public DateTime? LastLogOnDate { get; set; }

        #region Ограничения VIN поиска

        public bool IsVinSearchUnlimited { get; set; }
        public bool IsVinSearchDefaultLimit { get; set; }
        public int VinSearchLimitCounter { get; set; }
        public DateTime? VinSearchLimitDate { get; set; }

        #endregion

        public bool SubscribeForPromotions { get; set; }

        public List<string> RoleCodes
        {
            get
            {
                var list = typeof(UserRoles).GetEnumNames()
                    .Where(r => Roles.IsFlagSet((long)Enum.Parse(typeof(UserRoles), r)))
                    .Select(r => "UserRole_" + r);
                return list.ToList();
            }
        }

        public List<string> UserRolesView
        {
            get
            {
                var list = typeof(UserRoles).GetEnumNames()
                            .Where(r => Roles.IsFlagSet((long)Enum.Parse(typeof(UserRoles), r)))
                            .Select(r => CultureHelper.LocalizeString(typeof(ViewRes.SecurityResources), "Role" + r));
                return list.ToList();
            }
        }

        public IEnumerable<SelectListItem> UserRolesList()
        {
            var enumList = typeof(UserRoles).GetEnumNames().ToList();
            if (!ConfigHelper.AllowLoyalty)
            {
                enumList.Remove(UserRoles.LoyaltyUser.ToString());
            }

            var result = enumList.Select(r => new SelectListItem
            {
                Text = CultureHelper.LocalizeString(typeof(ViewRes.SecurityResources), "Role" + r),
                Value = ((long)Enum.Parse(typeof(UserRoles), r)).ToString(),
                Selected = Roles.IsFlagSet((long)Enum.Parse(typeof(UserRoles), r))
            }
            );

            return result;
        }

        public List<PartInfo> VINRequestPositions = new List<PartInfo>();
    }
}
