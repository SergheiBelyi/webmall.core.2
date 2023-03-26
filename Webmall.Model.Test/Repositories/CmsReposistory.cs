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
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class CmsReposistory : ICmsRepository
    {
        public List<Language> GetLanguages()
        {
            throw new System.NotImplementedException();
        }

        public List<CatalogCategory> GetExternalCatalog()
        {
            throw new System.NotImplementedException();
        }

        public NewsTracker GetNews(int? pageSize = null)
        {
            throw new System.NotImplementedException();
        }

        public void ResetNewsSendForSubscribersFlag(string slug)
        {
            throw new System.NotImplementedException();
        }

        public NewsTracker GetPromos(string[] activeActionsList, int? pageSize = null)
        {
            throw new System.NotImplementedException();
        }

        public void ResetPromoSendForSubscribersFlag(string slug)
        {
            throw new System.NotImplementedException();
        }

        public SeoTemplate GetSeoTemplate(string type)
        {
            throw new System.NotImplementedException();
        }

        public IncorporatingText GetIncorporatingText(string slug)
        {
            throw new System.NotImplementedException();
        }

        public Article GetArticle(string slug)
        {
            throw new System.NotImplementedException();
        }

        public BrandArticle GetBrandArticle(string slug)
        {
            throw new System.NotImplementedException();
        }

        public MailMessageTemplate GetMailMessageTemplate(MailMessages message)
        {
            throw new System.NotImplementedException();
        }

        public List<Banner> GetBanners()
        {
            throw new System.NotImplementedException();
        }

        public List<MenuLevel1> GetMenu()
        {
            throw new System.NotImplementedException();
        }

        public List<FooterColumn> GetFooterColumns()
        {
            throw new System.NotImplementedException();
        }

        public List<SocialLink> GetSocialLinks()
        {
            throw new System.NotImplementedException();
        }

        public DeliveryConfig GetDeliveryConfig()
        {
            throw new System.NotImplementedException();
        }

        public Configuration GetConfiguration()
        {
            throw new System.NotImplementedException();
        }

        public Informer GetInformerMain()
        {
            throw new System.NotImplementedException();
        }

        public List<FlashNews> GetFlashNewsMain()
        {
            throw new System.NotImplementedException();
        }

        public List<NewsCategory> GetCatalogNews(int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public List<BrandItem> GetBrands()
        {
            throw new System.NotImplementedException();
        }

        public List<CustomerReview> GetCustomerReviews()
        {
            throw new System.NotImplementedException();
        }

        public Menu GetPersonalMenu()
        {
            throw new System.NotImplementedException();
        }

        List<UserRolesCustom> ICmsRepository.GetUserRoles()
        {
            throw new System.NotImplementedException();
        }

        public List<WareGroups> GetWaregroups()
        {
            throw new System.NotImplementedException();
        }

        public List<HeaderNav> GetHeaderNav()
        {
            throw new System.NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new System.NotImplementedException();
        }

        public string GetCallManagersMails()
        {
            throw new System.NotImplementedException();
        }

        public List<Shops> GetShops(string shopName)
        {
            throw new System.NotImplementedException();
        }

        public List<OrderPayment> GetOrderPayment()
        {
            throw new System.NotImplementedException();
        }

        public OrderInfoText GetInfoAdditional()
        {
            throw new System.NotImplementedException();
        }

        public OrderInfoText GetInfoDelivery()
        {
            throw new System.NotImplementedException();
        }

        public OrderInfoText GetInfoPayment()
        {
            throw new System.NotImplementedException();
        }

        public OrderInfoText GetOrderInfo(string infoType)
        {
            throw new System.NotImplementedException();
        }

        public OrderInfoText GetInfoAttention()
        {
            throw new System.NotImplementedException();
        }

        public EmbeddedText GetEmbeddedText(int id)
        {
            throw new System.NotImplementedException();
        }

        public SuccessfulText GetSuccessPageText()
        {
            throw new System.NotImplementedException();
        }
    }
}
