using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using ValmiStore.Model.Entities.Configuration;
using ValmiStore.Model.Entities.Configuration.Features;
using Webmall.Model.Repositories.Abstract;
// ReSharper disable PossibleNullReferenceException

namespace Webmall.Model
{
    public static class ConfigHelper
    {
        private static IConfigRepository _configRepository;
        private static ICmsRepository _cmsRepository;

        public static void Init (IDependencyResolver resolver)
        {
            _configRepository = (IConfigRepository)resolver.GetService(typeof(IConfigRepository));
            _cmsRepository = (ICmsRepository)resolver.GetService(typeof(ICmsRepository));
        }

        public static EmailConfig EmailConfig => _configRepository?.GetEmailConfig();

        public static Features FeaturesConfig => _configRepository?.GetFeatures();

        #region Common

        private static bool GetBooleanSetting(string name, bool defaultValue)
        {
            return defaultValue
                ? String.Compare(ConfigurationManager.AppSettings[name.Replace("get_", "")], "false",
                    StringComparison.OrdinalIgnoreCase) != 0
                : String.Compare(ConfigurationManager.AppSettings[name.Replace("get_", "")], "true",
                    StringComparison.OrdinalIgnoreCase) == 0;
        }

        private static int GetIntegerSetting(string name, int defaultValue)
        {
            return int.Parse(ConfigurationManager.AppSettings[name.Replace("get_", "")] ?? defaultValue.ToString(CultureInfo.InvariantCulture));
        }

        private static DateTime GetDateSetting(string name, string defaultValue)
        {
            return DateTime.Parse(ConfigurationManager.AppSettings[name.Replace("get_", "")] ?? defaultValue, new DateTimeFormatInfo {ShortDatePattern = "dd.MM.yyyy"});
        }

        private static TimeSpan GetTimeSetting(string name, string defaultValue)
        {
            return TimeSpan.Parse(ConfigurationManager.AppSettings[name.Replace("get_", "")] ?? defaultValue, new DateTimeFormatInfo { LongTimePattern = "HH:mm:ss" });
        }

        #endregion

        #region Boolean props

        /// <summary>
        /// Требуется ли SSL (true - да / false - нет)
        /// </summary>
        //public static bool EmailServerSSLEnable => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);
        public static bool EmailServerSSLEnable => EmailConfig.IsSslEnabled;

        /// <summary>
        /// Очищает HttpRuntime.Cache для каждого запроса (полезно при отладке с 1С)
        /// </summary>
        public static bool CacheOff => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает поддержку программы лояльности
        /// </summary>
        public static bool AllowLoyalty => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает сравнение товаров
        /// </summary>
        public static bool AllowWaresCompare => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает включение пункта "Запись на обслуживание" в личном кабинете, заказах и меню
        /// </summary>
        public static bool AllowServiceBooking => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Устанавливает открытие в новом окне для пункта "Запись на обслуживание"
        /// </summary>
        public static bool ServiceBookingTargetNew => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает добавление в корзину только товара на складе, иначе можно добавлять и при товарах "под заказ"
        /// </summary>
        public static bool AllowSendToCartOnlyFromStock => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает включение пункта "События" в личном кабинете
        /// </summary>
        public static bool AllowEventsMenu => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает профилирование приложения
        /// </summary>
        public static bool AllowProfiler => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает показ тривиальных записей 
        /// </summary>
        public static bool ProfilerShowTrivial => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает включение пункта "Акции" в личном кабинете
        /// </summary>
        public static bool AllowActionsMenu => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает самостоятельную регистрацию пользователей в магазине
        /// </summary>
        public static bool AllowAutoRegistration => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Разрешает функциональность Laximo
        /// </summary>
        public static bool AllowLaximo => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает сохранение ViewMode в сессии или Cookie
        /// </summary>
        public static bool AllowSaveViewMode => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Запрещает функциональность Laximo для розницы
        /// </summary>
        public static bool DenyLaximoRetail => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Установить использование IFrame в оригинальных каталогах
        /// </summary>
        public static bool OriginalCatalogUseIframe => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Установить разрешение показа только товаров в наличии
        /// </summary>
        public static bool AllowWareOnlyInPresenceSelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Разрешить регистрацию юридических лиц
        /// </summary>
        public static bool AllowJuridicalRegistration => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешить регистрацию только латинскими буквами
        /// </summary>
        public static bool UserNameLatinOnly => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения приема платежей VISA
        /// </summary>
        public static bool AllowVisa => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения приема платежей LiqPay
        /// </summary>
        public static bool AllowLiqPay => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения оформления доставки
        /// </summary>
        public static bool AllowDelivery => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения приема налички на складе
        /// </summary>
        public static bool AllowWarehouseCashControl => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения показа пункта меню "Акции"
        /// </summary>
        public static bool AllowPromotionsMenu => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения показа кнопки "Показать непроцененные товары"
        /// </summary>
        public static bool OnlyOnStockSelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения разрешения показа в каталоге непроцененных товаров
        /// </summary>
        public static bool OnlyWithPriceSelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак разрешения показа кнопки "Показать непроцененные товары"
        /// </summary>
        public static bool UseShippingDate => GetBooleanSetting("useShippingDate", false);

        /// <summary>
        /// Признак разрешения показа кнопки "Показать непроцененные товары"
        /// </summary>
        public static bool UseNeedTaxInvoice => GetBooleanSetting("useNeedTaxInvoice", false);

        /// <summary>
        /// Показывать логотип TecDoc в подборе по авто (view Selection)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static bool ShowTDLogo => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Разрешает печать акта приема-передачи
        /// </summary>
        public static bool AllowTransmissionAct => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешает предварительный выбор из списка производителей в результатах поиска
        /// </summary>
        public static bool AllowBrandPreliminarySelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Включает использование "классической" панели авторизации
        /// </summary>
        public static bool UseClassicAutorizePannel => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Признак показа второго лого
        /// </summary>
        public static bool ShowSecondLogo => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Всегда добавлять предложение текущего склада
        /// </summary>
        public static bool AlwaysCurrentWarehouseOffer => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Принудительное использование валюты по-умолчанию
        /// </summary>
        public static bool ForceDefaultValute => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Включение/отключение отображения названия группы в качестве заголовка на странице группы
        /// </summary>
        public static bool ShowGroupTitle => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Включение/отключение выбора размера страницы каталога
        /// </summary>
        public static bool AllowPageSizeSelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Включение/отключение проверки Captcha
        /// </summary>
        public static bool SkipCaptchaCheck => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешение подписки на акции при регистрации
        /// </summary>
        public static bool AllowActionsSubscription => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Разрешение редиректа в карточку при одиночном товаре
        /// </summary>
        public static bool AllowSingleWareRedirect => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Разрешение делиться стаьями в социальных сетях
        /// </summary>
        public static bool AllowSocialShare => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Разрешение выполнять подбор авто по Laximo
        /// </summary>
        public static bool AllowLaximoAutoSelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);       
        
        /// <summary>
        /// Разрешение показа списка категорий в сайдбаре
        /// </summary>
        public static bool ShowCategoryNavigationMenu => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);     
        
        /// <summary>
        /// Разрешает автоматический выбор автомобиля при подборе
        /// </summary>
        public static bool AllowAutoAutoSelection => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);  
        
        /// <summary>
        /// Значение подписки на получение уведомлений о заказе на Email по умолчанию
        /// </summary>
        public static bool DefaultOrderResumeSubscription => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, true);

        /// <summary>
        /// Разрешения использования механизма сокрытия цен
        /// </summary>
        public static bool AllowHidePrices => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        /// <summary>
        /// Значение флага "запомнить меня (RememberMe) при входе в систему по-умолчанию"
        /// </summary>
        public static bool IsDefaultRememberMe => GetBooleanSetting(MethodBase.GetCurrentMethod().Name, false);

        #endregion

        #region String Props

        /// <summary>
        /// Email адрес менеджера по обработке предварительной записи
        /// </summary>
        public static string DefaultClientId => ConfigurationManager.AppSettings["DefaultClientId"];


        #region Outgoing_emails_settings

        /// <summary>
        /// Адрес от имени которого отправлять сообщения
        /// </summary>
        public static string MailFromAddress => ConfigurationManager.AppSettings["mailFromAddress"];

        /// <summary>
        /// Имя, от которого отправялть сообщения
        /// </summary>
        public static string MailFromName => ConfigurationManager.AppSettings["mailFromName"];

        /// <summary>
        /// Сервер исходящей почты
        /// </summary>
        public static string EmailServerAddress => ConfigurationManager.AppSettings["EmailServerAddress"] ?? "";

        /// <summary>
        /// Email адресс почтового ящика
        /// </summary>
        public static string EmailUserName => ConfigurationManager.AppSettings["EmailUserName"] ?? "";

        /// <summary>
        /// Пароль почтового ящика
        /// </summary>
        public static string EmailPassword => ConfigurationManager.AppSettings["EmailPassword"] ?? "";

        #endregion

        /// <summary>
        /// Email адрес менеджера по обработке предварительной записи
        /// </summary>
        public static string BookingRequestManager => ConfigurationManager.AppSettings["BookingRequestManager"] ?? "";


        /// <summary>
        /// Список адресов получателей сообщений об ошибках
        /// </summary>
        public static string MistakeMessageReceivers => ConfigurationManager.AppSettings["MistakeMessageReceivers"] ?? "";


        /// <summary>
        /// Список адресов получателей сообщений о регистрациях юр. лица
        /// </summary>
        public static string JuridicalRegistrationReceivers => ConfigurationManager.AppSettings["JuridicalRegistrationReceivers"] ?? "";

        /// <summary>
        /// Список адресов получателей сообщений о регистрациях физ. лица
        /// </summary>
        public static string PhisicalRegistrationReceivers => ConfigurationManager.AppSettings["PhisicalRegistrationReceivers"] ?? "";

        #region Jobs

        /// <summary>
        /// Периодичность рассылки сообщений об изменениях в учебном центре
        /// </summary>
        public static string SubscribeProcessSchedule => ConfigurationManager.AppSettings["SubscribeProcessSchedule"] ?? "0 0 0/1 * * ?";

        /// <summary>
        /// Периодичность запуска процесса определения победителей
        /// </summary>
        public static string GetActionWinnerProcessSchedule => ConfigurationManager.AppSettings["GetActionWinnerProcessSchedule"] ?? "0 0 0/1 * * ?";

        /// <summary>
        /// Периодичность запуска процесса определения победителей
        /// </summary>
        public static string CloseBankDaySchedule => ConfigurationManager.AppSettings["CloseBankDaySchedule"] ?? "0 55 23 1/1 * ? *";

        #endregion

        /// <summary>
        /// Список адресов получателей сообщений о записи в учебный центр
        /// </summary>
        public static string LearningCenterReceivers => ConfigurationManager.AppSettings["LearningCenterReceivers"] ?? "";

        /// <summary>
        /// URL-адрес корня сайта (http://webmall.md)
        /// </summary>
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

        /// <summary>
        /// Редирект для ServiceBooking
        /// </summary>
        public static string ServiceBookingRedirect => ConfigurationManager.AppSettings["ServiceBookingRedirect"] ?? "";

        /// <summary>
        /// Культура по-умолчанию
        /// </summary>
        public static string DefaultCulture => ConfigurationManager.AppSettings["defaultCulture"] ?? "ru-RU";

        /// <summary>
        /// Валюта по-умолчанию (идентификатор)
        /// </summary>
        public static string DefaultValute => ConfigurationManager.AppSettings["DefaultValute"] ?? "Lei";

        /// <summary>
        /// Валюта по-умолчанию (наименование)
        /// </summary>
        public static string DefaultValuteName => ConfigurationManager.AppSettings["DefaultValuteName"] ?? "лей";


        /// <summary>
        /// Префикс телефона
        /// </summary>
        public static string PhonePrefix => ConfigurationManager.AppSettings["phonePrefix"] ?? "+373";

        /// <summary>
        /// Префикс стационарного телефона
        /// </summary>
        public static string FixedPhonePrefix => ConfigurationManager.AppSettings["FixedPhonePrefix"] ?? PhonePrefix ?? "+373";

        public static string PriceListImpersonation => ConfigurationManager.AppSettings["PriceListImpersonation"];

        #region Наименования печатных форм на Reporting Services

        /// <summary>
        /// Наименование отчета для накладной на Reporting Services
        /// </summary>
        public static string InvoiceReportName => ConfigurationManager.AppSettings["InvoiceReportName"];

        /// <summary>
        /// Наименование отчета для акта приема-передачи на Reporting Services
        /// </summary>
        public static string TransmissionActReportName => ConfigurationManager.AppSettings["TransmissionActReportName"];

        /// <summary>
        /// Наименование отчета для неудспроса на Reporting Services
        /// </summary>
        public static string PentupDemandReportName => ConfigurationManager.AppSettings["PentupDemandReportName"] ?? "";

        /// <summary>
        /// Наименование отчета для акта сверки на Reporting Services
        /// </summary>
        public static string ComparisionActReportName => ConfigurationManager.AppSettings["ComparisionActReportName"] ?? "";

        /// <summary>
        /// Наименование отчета для билета на мероприятие на Reporting Services
        /// </summary>
        public static string EventTicketReportName => ConfigurationManager.AppSettings["EventTicketReportName"] ?? "";

        /// <summary>
        /// Наименование отчета для списка номеров приглашений на мероприятие на Reporting Services
        /// </summary>
        public static string InvitationNumbersReportName => ConfigurationManager.AppSettings["InvitationNumbersReportName"] ?? "";

        /// <summary>
        /// Наименование отчета для результатов посещаемости мероприятия на Reporting Services
        /// </summary>
        public static string EventVisitsReportName => ConfigurationManager.AppSettings["EventVisitsReportName"] ?? "";

        #endregion

        #region Параметры Reporting Services

        /// <summary>
        /// URL сервера Reporting Services
        /// </summary>
        public static string ReportServer => ConfigurationManager.AppSettings["ReportServer"];

        /// <summary>
        /// Login пользователя для подключения
        /// </summary>
        public static string RSUser => ConfigurationManager.AppSettings["RSUser"];

        /// <summary>
        /// Пароль пользователя для подключения
        /// </summary>
        public static string RSPassword => ConfigurationManager.AppSettings["RSPassword"];

        /// <summary>
        /// Домен пользователя для подключения
        /// </summary>
        public static string RSDomain => ConfigurationManager.AppSettings["RSDomain"];

        #endregion

        /// <summary>
        /// Строка копирайта для показа в подвале страницы
        /// </summary>
        public static string Copyright => ConfigurationManager.AppSettings["Copyright"];

        /// <summary>
        /// Строка адреса для показа в подвале страницы
        /// </summary>
        public static string Address => ConfigurationManager.AppSettings["Address"];

        /// <summary>
        /// Код аккаунта Google analytics
        /// </summary>
        public static string GoogleAnalyticsAccount => ConfigurationManager.AppSettings["GoogleAnalyticsAccount"];

        /// <summary>
        /// Код аккаунта Google tag manager
        /// </summary>
        public static string GoogleTagManagerAccount => ConfigurationManager.AppSettings["GoogleTagManagerAccount"];

        /// <summary>
        /// Код Google Conversion
        /// </summary>
        public static string GoogleConversionId => ConfigurationManager.AppSettings["GoogleConversionId"];

        /// <summary>
        /// Код аккаунта Yandex Metrika
        /// </summary>
        public static string YandexMetrikaAccount => ConfigurationManager.AppSettings["YandexMetrikaAccount"];

        /// <summary>
        /// Путь сохранения журналов доступа к сайту
        /// </summary>
        public static string AccessLogPath => ConfigurationManager.AppSettings["AccessLogPath"] ?? "c:\\temp\\";

        /// <summary>
        /// Электронный адрес рассылки журналов доступа
        /// </summary>
        public static string AccessManagerEmail => ConfigurationManager.AppSettings["AccessManagerEmail"];

        /// <summary>
        /// Email для контактов
        /// </summary>
        public static string ContactEmail => ConfigurationManager.AppSettings["ContactEmail"];

        /// <summary>
        /// Контактный телефон в заголовке
        /// </summary>
        public static string TitleHelpPhone => ConfigurationManager.AppSettings["TitleHelpPhone"] ?? ConfigurationManager.AppSettings["ContactGrossPhone"];

        /// <summary>
        /// 1й контактный телефон в "подвале" страницы
        /// </summary>
        public static string ContactPhone1 => ConfigurationManager.AppSettings["ContactPhone1"] ?? "";

        /// <summary>
        /// Контактный телефон для розничных клиентов
        /// </summary>
        public static string ContactRetailPhone => ConfigurationManager.AppSettings["ContactRetailPhone"];

        /// <summary>
        /// Наименование компании для показа в меню и т.п.
        /// </summary>
        public static string CompanyName => ConfigurationManager.AppSettings["CompanyName"] ?? "CompanyName";

        /// <summary>
        /// Наименование cookie для хранения выбранного языка сайта
        /// </summary>
        public static string CultureCookieName => ConfigurationManager.AppSettings["CultureCookieName"] ?? "Webmall_CultureCookie";

        #region Ссылки главного меню

        ///// <summary>
        ///// Ссылка на страницу "О компании"
        ///// </summary>
        //public static string AboutCompanyUrl => ConfigurationManager.AppSettings["AboutCompanyUrl"] ?? "~/About.aspx";

        ///// <summary>
        ///// Ссылка на страницу "Как купить"
        ///// </summary>
        //public static string HelpUrl => ConfigurationManager.AppSettings["HelpUrl"] ?? "~/Help.aspx";

        ///// <summary>
        ///// Ссылка на страницу "AUTO MALL Service"
        ///// </summary>
        //public static string ServiceUrl => ConfigurationManager.AppSettings["ServiceUrl"] ?? "~/Service.aspx";

        ///// <summary>
        ///// Ссылка на страницу "Поставщики"
        ///// </summary>
        //public static string ProvidersUrl => ConfigurationManager.AppSettings["ProvidersUrl"] ?? "~/Providers.aspx";

        ///// <summary>
        ///// Ссылка на страницу "Дистрибьюторы"
        ///// </summary>
        //public static string DistributorsUrl => ConfigurationManager.AppSettings["DistributorsUrl"] ?? "~/nashidistributer.aspx";

        ///// <summary>
        ///// Ссылка на страницу "GROUPAUTO"
        ///// </summary>
        //public static string GroupAutoMoldovaUrl => ConfigurationManager.AppSettings["GroupAutoMoldovaUrl"] ?? "~/GroupAutoMoldova.aspx";

        ///// <summary>
        ///// Ссылка на страницу "Контакты"
        ///// </summary>
        //public static string ContactsUrl => ConfigurationManager.AppSettings["ContactsUrl"] ?? "~/Contacts.aspx";

        /// <summary>
        /// Ссылка на страницу условий оплаты
        /// </summary>
        public static string PaymentTermsUrl => ConfigurationManager.AppSettings["paymentTermsUrl"] ?? "~/paymentTerms.aspx";

        /// <summary>
        /// Ссылка на страницу условий доставки
        /// </summary>
        public static string ShippingTermsUrl => ConfigurationManager.AppSettings["shippingTermsUrl"] ?? "~/shippingTerms.aspx";

        #endregion

        /// <summary>
        /// Почтовый адрес системного администратора
        /// </summary>
        public static string SysAdminEmail => ConfigurationManager.AppSettings["SysAdminEmail"] ?? "root@webmall.md";

        #region JIVOSITE
        /// <summary>
        /// Идентификатор для JIVOSITE (при отсутствии виджет не выводится)
        /// </summary>
        public static string JivositeId => ConfigurationManager.AppSettings["JivositeId"];

        public static string GetCustomJivositeId(bool isGross, string lang)
        {
            const string baseKey = "JivositeId";
            var key = baseKey + "-" + (lang ?? "").ToLower();
            var result = ((((isGross) ? ConfigurationManager.AppSettings[key+"-gross"] : null) 
                            ?? ConfigurationManager.AppSettings[key]) 
                            ?? ((isGross) ? ConfigurationManager.AppSettings[baseKey] : null)) 
                            ?? JivositeId;
            return result;
        }

        /// <summary>
        /// Код группы Запчасти для ТО (8953)
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static string TOWareGroupId => ConfigurationManager.AppSettings["TOWareGroupId"];

        /// <summary>
        /// Код группы популярных товаров (8952)
        /// </summary>
        public static string PopularWareGroupId => ConfigurationManager.AppSettings["PopularWareGroupId"];

        #endregion

        /// <summary>
        /// Единый контактный телефон (используется на странице ошибок и для страницы заказа)
        /// </summary>
        public static string ContactPhoneUnique => ConfigurationManager.AppSettings["ContactPhoneUnique"];

        /// <summary>
        /// Адрес отправки копии сообщения об успешном оформлении заказа
        /// </summary>
        public static string SummaryCopy => ConfigurationManager.AppSettings["SummaryCopy"];

        /// <summary>
        /// ФИО менеджера для показа на сообщениях об оплате / успешном оформлении заказа
        /// </summary>
        public static string SummaryManager => ConfigurationManager.AppSettings["SummaryManager"];

        /// <summary>
        /// Телефон менеджера для показа на сообщениях об оплате / успешном оформлении заказа
        /// </summary>
        public static string SummaryManagerPhone => ConfigurationManager.AppSettings["SummaryManagerPhone"];

        /// <summary>
        /// Список виджетов услуг для показа 
        /// 1 - Подбор по VIN
        /// 2 - Подбор по Марке
        /// 3 - Подбор по ШИН
        /// 4 - On-line запись на СТО
        /// 5 - Каталоги производителей
        /// </summary>
        public static string ShowServicesVidgets => ConfigurationManager.AppSettings["ShowServicesVidgets"] ?? "1,2,3,4";

        /// <summary>
        /// Список виджетов услуг для показа оптовикам
        /// </summary>
        public static string ShowGrossServicesVidgets => ConfigurationManager.AppSettings["ShowGrossServicesVidgets"] ?? "1,2,3,5";

        #region CAPTCHA

        public static string CaptchaSiteKey => ConfigurationManager.AppSettings["CaptchaSiteKey"] ?? "";

        public static string CaptchaSecretKey => ConfigurationManager.AppSettings["CaptchaSecretKey"] ?? "";

        #endregion

        #region Подбор шин

        /// <summary>
        /// Id/URL группы, соответствующий шинам
        /// </summary>
        public static string TiresGroup => ConfigurationManager.AppSettings["TiresGroup"] ?? "tires";

        /// <summary>
        /// Название параметра для легковых шин
        /// </summary>
        public static string TiresTypeAutotourism => ConfigurationManager.AppSettings["TiresTypeAutotourism"] ?? "Легковые шины";

        /// <summary>
        /// Название параметра для грузовых шин
        /// </summary>
        public static string TiresTypeCarco => ConfigurationManager.AppSettings["TiresTypeCarco"] ?? "Грузовые шины";

        /// <summary>
        /// Название параметра для легкогрузовых шин
        /// </summary>
        public static string TiresTypeMix => ConfigurationManager.AppSettings["TiresTypeMix"] ?? "Легкогрузовые шины ( C )";

        /// <summary>
        /// Название параметра для летних шин
        /// </summary>
        public static string TiresSeasonSummer => ConfigurationManager.AppSettings["TiresSeasonSummer"] ?? "Летние шины";

        /// <summary>
        /// Название параметра для зимних шин
        /// </summary>
        public static string TiresSeasonWinter => ConfigurationManager.AppSettings["TiresSeasonWinter"] ?? "Зимние шины";

        #endregion

        #region Соц сети

        /// <summary>
        /// URL страницы facebook
        /// </summary>
        public static string FacebookPixelId => ConfigurationManager.AppSettings["FacebookPixelId"];

        /// <summary>
        /// URL страницы facebook
        /// </summary>
        public static string SocialNetFacebookUrl => ConfigurationManager.AppSettings["SocialNetFacebookUrl"];

        /// <summary>
        /// URL страницы Twitter
        /// </summary>
        public static string SocialNetTwitterUrl => ConfigurationManager.AppSettings["SocialNetTwitterUrl"];

        /// <summary>
        /// URL страницы Twitter
        /// </summary>
        public static string SocialNetOdnoklassnikiUrl => ConfigurationManager.AppSettings["SocialNetOdnoklassnikiUrl"];

        /// <summary>
        /// URL страницы Twitter
        /// </summary>
        public static string SocialNetVKontakteUrl => ConfigurationManager.AppSettings["SocialNetVKontakteUrl"];

        /// <summary>
        /// URL страницы Twitter
        /// </summary>
        public static string SocialNetGooglePlusUrl => ConfigurationManager.AppSettings["SocialNetGooglePlusUrl"];

        /// <summary>
        /// URL страницы Youtube
        /// </summary>
        public static string SocialNetYoutubeUrl => ConfigurationManager.AppSettings["SocialNetYoutubeUrl"];

        /// <summary>
        /// URL страницы Instagram
        /// </summary>
        public static string SocialNetInstagramUrl => ConfigurationManager.AppSettings["SocialNetInstagramUrl"];

        #endregion

        #region Гео-локация

        // ReSharper disable InconsistentNaming
        private static readonly string _geoRegion = ConfigurationManager.AppSettings["GeoRegion"];
        private static readonly string _geoPlacename = ConfigurationManager.AppSettings["GeoPlacename"];
        private static readonly string _geoPosition = ConfigurationManager.AppSettings["GeoPosition"];
        private static readonly string _geoICBM = (ConfigurationManager.AppSettings["GeoPosition"] ?? "").Replace(";", ", ");
// ReSharper restore InconsistentNaming

        /// <summary>
        /// Наименование страницы описания гарантии для опта (xxx.aspx)
        /// </summary>
        public static string GeoRegion => _geoRegion;

        /// <summary>
        /// Наименование страницы описания гарантии для опта (xxx.aspx)
        /// </summary>
        public static string GeoPlacename => _geoPlacename;

        /// <summary>
        /// Наименование страницы описания гарантии для опта (xxx.aspx)
        /// </summary>
        public static string GeoPosition => _geoPosition;

        /// <summary>
        /// Наименование страницы описания гарантии для опта (xxx.aspx)
        /// </summary>
// ReSharper disable once InconsistentNaming
        public static string GeoICBM => _geoICBM;

        #endregion

        /// <summary>
        /// IP адреса для которых действует ограничение по сессии
        /// </summary>
        public static string SessionLimitIPs => ConfigurationManager.AppSettings["SessionLimitIPs"];

        public static string LaximoClientsRestrict => ConfigurationManager.AppSettings["LaximoClientsRestrict"];

        /// <summary>
        /// Id групп для которых должен быть использован фильтр по авто для опта
        /// </summary>
        public static string GroupsWAutoFilterGross => ConfigurationManager.AppSettings["GroupsWAutoFilterGross"];

        /// <summary>
        /// Id групп для которых должен быть использован фильтр по авто для розницы
        /// </summary>
        public static string GroupsWAutoFilterRetail => ConfigurationManager.AppSettings["GroupsWAutoFilterRetail"];

        /// <summary>
        /// Идентификатор региона "по-умолчанию"
        /// </summary>
        public static string DefaultRegionId => ConfigurationManager.AppSettings["DefaultRegionId"];

        /// <summary>
        /// Формат отбражения цены
        /// </summary>
        public static string PriceFormat => ConfigurationManager.AppSettings["PriceFormat"] ?? "{0:n2}";

        /// <summary>
        /// Код страны
        /// </summary>
        public static string CountryCode => ConfigurationManager.AppSettings["CountryCode"];

        /// <summary>
        /// Ссылка на дефолтную картинку
        /// </summary>
        public static string DefaultImg => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "3ec1540f-9022-43e6-83de-53e72e8e3d9b/nocmsimage.jpg";

        /// <summary>
        /// Ссылка картинки с прайсагрегатора
        /// </summary>
        public static string PriceAggrearorImg => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "http://148.251.180.109:9004/Images/Ware/";

        /// <summary>
        /// Путь к файлу, содержащему пример импорта в корзину
        /// </summary>
        public static string CartImportFileExamplePath => ConfigurationManager.AppSettings["CartImportFileExamplePath"] ?? "~\\ExtContent\\files\\price_post_1.xlsx";


        #region Squidex

        /// <summary>
        /// Ссылка на Сервер
        /// </summary>
        public static string SquidexUrl => ConfigurationManager.AppSettings["SquidexUrl"] ?? "http://88.99.96.122:8009/";

        /// <summary>
        /// Имя приложения
        /// </summary>
        public static string SquidexAppName => ConfigurationManager.AppSettings["SquidexAppName"] ?? "motex";

        /// <summary>
        /// Клиент ид приложения схемы
        /// </summary>
        public static string SquidexSchemaClientId => ConfigurationManager.AppSettings["SquidexSchemaClientId"] ?? "motex:default";

        /// <summary>
        /// Пароль клиента приложения схемы
        /// </summary>
        public static string SquidexSchemaClientSecret => ConfigurationManager.AppSettings["SquidexSchemaClientSecret"] ?? "tvn8b2eu0xaeazydtr10gvdxx6hrim1eqoej23gcrlyx";

        /// <summary>
        /// Клиент ид приложения приложения
        /// </summary>
        public static string SquidexAppClientId => ConfigurationManager.AppSettings["SquidexAppClientId"] ?? "63087477e9709861980d3a61";

        /// <summary>
        /// Пароль клиента приложения
        /// </summary>
        public static string SquidexAppClientSecret => ConfigurationManager.AppSettings["SquidexAppClientSecret"] ?? "yajtnvhmr3lxrxmayzcnksw2quxvoot1nkh3g1rcxe0x";

        #endregion

        #endregion

        #region Int props

        /// <summary>
        /// Время таймаута тикета для FormAuthentication (в часах)
        /// </summary>
        public static int AuthTicketExpiration => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 24);

        /// <summary>
        ///Порт исходящей почты (SMTP)
        /// </summary>
        public static int EmailSMTPSPort => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 587);

        /// <summary>
        /// Устанавливает лимит превышения для сброса в лог (секундах)
        /// </summary>
        public static int ProfilerLogTimeLimit => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 0);

        /// <summary>
        /// Максимальная длина поля "телефон"
        /// </summary>
        public static int MaxPhoneLength => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 8);

        /// <summary>
        /// Минимальная длина поля "телефон"
        /// </summary>
        public static int MinPhoneLength => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, MaxPhoneLength);

        /// <summary>
        /// Максимальная длина поля "стационарный телефон"
        /// </summary>
        public static int MaxFixedPhoneLength => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 15);

        /// <summary>
        /// Минимальная длина поля "стационарный телефон"
        /// </summary>
        public static int MinFixedPhoneLength => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 0);

        /// <summary>
        /// Длина поля "Фискальный код"
        /// </summary>
        public static int FiscalCodeLength => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 12);

        /// <summary>
        /// Срок действительности кэша (в часах)
        /// </summary>
        public static int CacheExpirationTime => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 1);

        /// <summary>
        /// Часы начала работы сервиса
        /// </summary>
        public static int ServiceBookingStartTime => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 9);

        /// <summary>
        /// Часы конца работы сервиса
        /// </summary>
        public static int ServiceBookingEndTime => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 18);

        #region Подбор шин
        /// <summary>
        /// Код параметрической группы типов шин
        /// </summary>
        public static int TiresTypeParameterId => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 1587);

        /// <summary>
        /// Код параметрической группы сезонности шин
        /// </summary>
        public static int TiresSeasonParameterId => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 1586);

        /// <summary>
        /// Код параметрической группы ширины шин
        /// </summary>
        public static int TiresWidthParameterId => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 1290);

        /// <summary>
        /// Код параметрической группы высоты шин
        /// </summary>
        public static int TiresHeightParameterId => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 126);

        /// <summary>
        /// Код параметрической группы размера диска
        /// </summary>
        public static int TiresDiameterParameterId => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 653);

        #endregion

        #region Статистика доступа

        /// <summary>
        /// Ограничение по кол-ву запросов в минуту
        /// </summary>
        public static int RequestsPerMinuteLimit => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 25);

        #endregion

        /// <summary>
        /// Время ограничения сессии (секунды)
        /// </summary>
        public static int SessionLimitTime => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 0);

        /// <summary>
        /// Ограничение поиска по VIN для авторизованных пользователей
        /// </summary>
        public static int VinSearchLimitRegistered => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 10);

        /// <summary>
        /// Ограничение поиска по VIN для неавторизованных пользователей
        /// </summary>
        public static int VinSearchLimit => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 5);

        /// <summary>
        /// Период инвалидации пользователя (в минутах)
        /// 0 - сутки
        /// </summary>
        public static int UserInvalidationPeriod => GetIntegerSetting(MethodBase.GetCurrentMethod().Name, 0);

        #endregion

        #region Date props

        /// <summary>
        /// Минимально возможная дата для акта сверки
        /// </summary>
        public static DateTime MinComparisionActDate => GetDateSetting(MethodBase.GetCurrentMethod().Name, "01.01.2000");

        public static TimeSpan ValuteInvalidationTime => GetTimeSetting(MethodBase.GetCurrentMethod().Name, "00:00:00");

        #endregion

        #region Lists

        private static List<string> _laximoClientsRestrictList;
        public static List<string> LaximoClientsRestrictList
        {
            get { 
                if (_laximoClientsRestrictList == null)
                    return _laximoClientsRestrictList = (LaximoClientsRestrict ?? "")
                        .Split(",").Select(i => i.Trim()).Where(i=>!string.IsNullOrWhiteSpace(i)).ToList();
                return _laximoClientsRestrictList;
            }
        }

        private static List<string> _sessionLimitIpsList;
        public static List<string> SessionLimitIpsList
        {
            get
            {
                if (_sessionLimitIpsList == null)
                    return _sessionLimitIpsList = (SessionLimitIPs ?? "")
                        .Split(',', ';', '|').Select(i => i.Trim()).Where(i => !string.IsNullOrWhiteSpace(i)).ToList();
                return _sessionLimitIpsList;
            }
        }

        private static List<string> _groupsWAutoFilterListGross;
        public static List<string> GroupsWAutoFilterListGross
        {
            get
            {
                if (_groupsWAutoFilterListGross == null)
                    return _groupsWAutoFilterListGross = (GroupsWAutoFilterGross ?? "")
                        .Split(',', ';', '|').Select(i => i.Trim()).Where(i => !string.IsNullOrEmpty(i)).Distinct().ToList();
                return _groupsWAutoFilterListGross;
            }
        }

        private static List<string> _groupsWAutoFilterListRetail;
        public static List<string> GroupsWAutoFilterListRetail
        {
            get
            {
                if (_groupsWAutoFilterListRetail == null)
                    return _groupsWAutoFilterListRetail = (GroupsWAutoFilterRetail ?? "")
                        .Split(',', ';', '|').Select(i => i.Trim()).Where(i => !string.IsNullOrEmpty(i)).Distinct().ToList();
                return _groupsWAutoFilterListRetail;
            }
        }

        public static bool HasGroupAutoFilter(string groupId, bool isGross)
        {
            return isGross ? GroupsWAutoFilterListGross.Contains(groupId) : GroupsWAutoFilterListRetail.Contains(groupId);
        }

        #endregion

        public static string String2Loc(string str, string loc)
        {
            var locs = str.Split('|').Select(i => i.Trim()).ToArray();
            var divider = loc.ToUpper() + ":";
            var result = (locs.FirstOrDefault(i => i.StartsWith(divider)) ?? "").Replace(divider, "");
            if (string.IsNullOrEmpty(result) && locs.Length == 1 && (locs[0].Length < 3 || locs[0][3] != ':'))
                result = str;
            return result;
        }
    }

}