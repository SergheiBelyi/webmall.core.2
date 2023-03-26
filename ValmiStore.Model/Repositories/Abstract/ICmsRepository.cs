using System.Collections.Generic;
using ValmiStore.Model.Entities.Cms.Configuration;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.Cms.Brand;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.ExternalCatalog;
using Webmall.Model.Entities.Cms.Footer;
using Webmall.Model.Entities.Cms.HomePage;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Menu;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.Model.Entities.Cms.Order;
using Webmall.Model.Entities.Cms.PersonalMenu;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Repositories.Abstract
{
    public interface ICmsRepository
    {
        /// <summary>
        /// Возвращает список доступных в системе языков
        /// </summary>
        /// <returns></returns>
        List<Language> GetLanguages();

        /// <summary>
        /// Возвращает структуру внешних каталогов
        /// </summary>
        /// <returns></returns>
        List<CatalogCategory> GetExternalCatalog();

        /// <summary>
        /// Возвращает каталог новостей
        /// </summary>
        /// <param name="pageSize"></param>
        List<NewsCategory> GetCatalogNews(int pageSize);

        /// <summary>
        /// Возвращает список групп
        /// </summary>
        List<WareGroups> GetWaregroups();

        /// <summary>
        /// Возвращает список новостей в системе
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        NewsTracker GetNews(int? pageSize = null);

        /// <summary>
        /// Сбрасывает флаг рассылки у новости
        /// </summary>
        /// <param name="slug">Идентификатор новости</param>
        /// <returns></returns>
        void ResetNewsSendForSubscribersFlag(string slug);

        /// <summary>
        /// Возвращает список промо-новостей в системе
        /// </summary>
        /// <param name="activeActionsList">Список активных маркетинговых акций</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        NewsTracker GetPromos(string[] activeActionsList, int? pageSize = null);

        /// <summary>
        /// Сбрасывает флаг рассылки у promo-новости
        /// </summary>
        /// <param name="slug">Идентификатор promo-новости</param>
        /// <returns></returns>
        void ResetPromoSendForSubscribersFlag(string slug);

        /// <summary>
        /// Возвращает SEO шаблон
        /// </summary>
        /// <param name="type">Тип SEO шаблона</param>
        /// <returns></returns>
        SeoTemplate GetSeoTemplate(string type);

        /// <summary>
        /// Возвращает встраиваемый текст
        /// </summary>
        /// <param name="slug">Идентификатор текстового блока</param>
        /// <returns></returns>
        IncorporatingText GetIncorporatingText(string slug);

        /// <summary>
        /// Возвращает информационную статью
        /// </summary>
        /// <param name="slug">Идентификатор статьи</param>
        /// <returns></returns>
        Article GetArticle(string slug);

        /// <summary>
        /// Возвращает статью о брэнде
        /// </summary>
        /// <param name="slug">Идентификатор статьи</param>
        /// <returns></returns>
        BrandArticle GetBrandArticle(string slug);

        /// <summary>
        /// Возвращает список брэндов
        /// </summary>
        List<BrandItem> GetBrands();

        /// <summary>
        /// Возвращает шаблон Email сообщения
        /// </summary>
        /// <param name="message">Код сообщения</param>
        /// <returns></returns>
        MailMessageTemplate GetMailMessageTemplate(MailMessages message);

        /// <summary>
        /// Возвращает список баннеров
        /// </summary>
        /// <returns></returns>
        List<Banner> GetBanners();

        /// <summary>
        /// Возвращает уедомление на главную
        /// </summary>
        /// <returns></returns>
        Informer GetInformerMain();

        /// <summary>
        /// Возвращает флэш-новости на главную
        /// </summary>
        /// <returns></returns>
        List<FlashNews> GetFlashNewsMain();

        /// <summary>
        /// Возвращает меню для заголовка
        /// </summary>
        /// <returns></returns>
        List<MenuLevel1> GetMenu();

        /// <summary>
        /// Возвращает меню для футера
        /// </summary>
        /// <returns></returns>
        List<FooterColumn> GetFooterColumns();

        /// <summary>
        /// Возвращает список ссылок на соц.сети
        /// </summary>
        /// <returns></returns>
        List<SocialLink> GetSocialLinks();

        /// <summary>
        /// Возвращает список персонального меню
        /// </summary>
        /// <returns></returns>
        Menu GetPersonalMenu();

        /// <summary>
        /// Возвращает конфигурация доставок
        /// </summary>
        /// <returns></returns>
        DeliveryConfig GetDeliveryConfig();

        /// <summary>
        /// Возвращает конфигурацию магазина
        /// </summary>
        /// <returns></returns>
        Configuration GetConfiguration();

        /// <summary>
        /// Возвращает список отзывов клиентов
        /// </summary>
        /// <returns></returns>
        List<CustomerReview> GetCustomerReviews();

        /// <summary>
        /// Возвращает список ролей
        /// </summary>
        /// <returns></returns>
        List<UserRolesCustom> GetUserRoles();

        /// <summary>
        /// Возвращает список меню для header
        /// </summary>
        List<HeaderNav> GetHeaderNav();

        /// <summary>
        /// Возвращает список меню для header
        /// </summary>
        Contact GetContact();

        /// <summary>
        /// Возвращает список адресов, на которые отправлять сообщение от клиента
        /// </summary>
        /// <returns></returns>
        string GetCallManagersMails();

        /// <summary>
        /// Возвращает список магазинов
        /// </summary>
        /// <param name="shopName">Код магазина</param>
        /// <returns></returns>
        List<Shops> GetShops(string shopName);

        /// <summary>
        /// Возвращает список оплат для ордера
        /// </summary>
        List<OrderPayment> GetOrderPayment();

        /// <summary>
        /// Возвращает информацию для ордера по типу
        /// <param name="infoType">тип получаеиого контента</param>
        /// </summary>
        OrderInfoText GetOrderInfo(string infoType);

        /// <summary>
        /// Возвращает информацию по дополнительной информации
        /// </summary>
        OrderInfoText GetInfoAdditional();

        /// <summary>
        /// Возвращает информацию по доставке
        /// </summary>
        OrderInfoText GetInfoDelivery();

        /// <summary>
        /// Возвращает информацию по оплате
        /// </summary>
        OrderInfoText GetInfoPayment();

        /// <summary>
        /// Возвращает информацию для обязательного чекбокса, в конце создания заказа
        /// </summary>
        OrderInfoText GetInfoAttention();

        /// <summary>
        /// Возвращает встраиваемый текст по ид
        /// </summary>
        /// <param name="id">Ид текста</param>
        EmbeddedText GetEmbeddedText(int id);

        /// <summary>
        /// Возвращает все текста для странички успешного заказа
        /// </summary>
        SuccessfulText GetSuccessPageText();

    }
}
