using System;
using AutoMapper;
using StackExchange.Profiling;
using ValmiStore.Model.Entities.Cms.Configuration;
using Webmall.Cms.Squidex.Cms.Models.Articles;
using Webmall.Cms.Squidex.Cms.Models.Banners;
using Webmall.Cms.Squidex.Cms.Models.BrandArticles;
using Webmall.Cms.Squidex.Cms.Models.ExternalCatalog;
using Webmall.Cms.Squidex.Cms.Models.FooterColumns;
using Webmall.Cms.Squidex.Cms.Models.IncorporatingText;
using Webmall.Cms.Squidex.Cms.Models.MailMessageTemplate;
using Webmall.Cms.Squidex.Cms.Models.Menu;
using Webmall.Cms.Squidex.Cms.Models.News;
using Webmall.Cms.Squidex.Cms.Models.SeoTemplate;
using Webmall.Cms.Squidex.Cms.Models.SocialLinks;
using Webmall.Cms.Squidex.Helpers;
using Webmall.Cms.Squidex.Cms.Models.Informer;
using Webmall.Cms.Squidex.Cms.Models.FlashNews;
using Webmall.Cms.Squidex.Cms.Models.CatalogNews;
using Webmall.Cms.Squidex.Cms.Models.Brands;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using Webmall.Cms.Squidex.Cms.Models.CustomerReviews;
using Webmall.Cms.Squidex.Cms.Models.PersonalMenu;
using Webmall.Cms.Squidex.Cms.Models.UserRolesCustom;
using Webmall.Model.Entities.Cms;
using Webmall.Cms.Squidex.Cms.Models.WareGroup;
using Webmall.Cms.Squidex.Cms.Models.HeaderNav;
using Webmall.Cms.Squidex.Cms.Models.Contact;
using log4net;
using log4net.Config;
using Webmall.Model;
using Webmall.Model.Entities.Cms.Brand;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.ExternalCatalog;
using Webmall.Model.Entities.Cms.Footer;
using Webmall.Model.Entities.Cms.HomePage;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Menu;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.Model.Entities.Cms.PersonalMenu;
using Webmall.Model.Entities.Cms.Seo;
using Webmall.Model.Repositories.Abstract;
using Webmall.Cms.Squidex.Cms.Models.Shops;
using Webmall.Model.Entities.Cms.Order;
using Webmall.Cms.Squidex.Cms.Models.Order;
using Webmall.Cms.Squidex.Cms.Models.EmbeddedText;
// ReSharper disable PossibleNullReferenceException

namespace Webmall.Cms.Squidex.Cms
{
    public class CmsRepository : ICmsRepository
    {
        private readonly IMapper _mapper;
        private readonly ClientManager _clientManager;
        private readonly ClientManager _shopManager;
        private static readonly object Lock = new object();

        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(CmsRepository));

        static CmsRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        public CmsRepository(IMapper mapper)
        {
            _mapper = mapper;
            _clientManager = ClientManagerFactory.Creator(ClientManagerType.Client);
            _shopManager = ClientManagerFactory.Creator(ClientManagerType.Shop);

        }

        public List<Language> GetLanguages()
        {
            return HttpRuntime.Cache.Get("Languages", Lock, () =>
            {
                using (MiniProfiler.Current.Step("GetLanguages from CMS"))
                {
                    var cm = _clientManager.App;
                    var appClient = cm.CreateAppsClient();
                    var applangs = Task.Run(() => appClient.GetLanguagesAsync(cm.App)).Result;
                    return _mapper.Map<List<Language>>(applangs.Items);
                }
            });
        }

        public List<CatalogCategory> GetExternalCatalog()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var positions = _clientManager.Get<CatalogItemItem, CatalogItemData>("external-catalog-items");
                var columns = _clientManager.Get<CatalogCategoryItem, CatalogCategoryData>("external-catalogs-categories");
                var result = _mapper.Map<List<CatalogCategory>>(columns);
                foreach (var item in positions)
                {
                    //https://localhost:8005/api/assets/motex/62f319bd-dcac-46a2-adc3-c25ed5765f76/news-2.jpg?version=0
                    var col = result.FirstOrDefault(i =>
                        i.Id == columns.FirstOrDefault(c => c.ItemId == item.Category[0])?.ItemId);

                    var catalogItem = _mapper.Map<CatalogItem>(item);
                    var assetInfo = _clientManager.GetAsset(catalogItem.FileUrl);
                    var opts = _clientManager.Schema.Options;
                    catalogItem.FileUrl = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    col?.Items.Add(catalogItem);
                }
                return result;
            });
        }

        #region News & Promo-news
        public NewsTracker GetNews(int? pageSize = null)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<NewsItem, NewsData>("news");
                var result = new NewsTracker(_mapper.Map<List<NewsArticle>>(data), pageSize);
                foreach (var item in result)
                {
                    var assetInfo = _clientManager.GetAsset(item.ImageUrl);
                    var opts = _clientManager.Schema.Options;
                    item.ImageUrl = assetInfo == null
                        ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                        : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    //https://localhost:8005/api/assets/motex/62f319bd-dcac-46a2-adc3-c25ed5765f76/news-2.jpg?version=0
                }
                return result;
            });
        }

        public void ResetNewsSendForSubscribersFlag(string slug)
        {
            var entities = _clientManager.GetListItems<NewsItem, NewsData>("news", $"data/slug/iv eq '{slug}'");
            if (entities.Total == 1)
            {
                entities.Items[0].Data.IsForMailing = false;
                _clientManager.Update<NewsItem, NewsData>("news", entities.Items[0]);
            }
        }

        public NewsTracker GetPromos(string[] activeActionsList, int? pageSize = null)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var allPromos = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<PromoItem, PromoData>("promos");
                var promoList = _mapper.Map<List<PromotionNews>>(data);
                foreach (var item in promoList)
                {
                    var assetInfo = _clientManager.GetAsset(item.ImageUrl);
                    var opts = _clientManager.Schema.Options;
                    item.ImageUrl = assetInfo == null
                        ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                        : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    //https://localhost:8005/api/assets/motex/62f319bd-dcac-46a2-adc3-c25ed5765f76/news-2.jpg?version=0
                }
                return promoList;
            });
            var result = allPromos.Where(i =>
                string.IsNullOrEmpty(i.MarketingActionLink) || activeActionsList.Contains(i.MarketingActionLink));

            return new NewsTracker(result, pageSize);
        }

        public void ResetPromoSendForSubscribersFlag(string slug)
        {
            var entities = _clientManager.GetListItems<PromoItem, PromoData>("promos", $"data/slug/iv eq '{slug}'");
            if (entities.Total == 1)
            {
                entities.Items[0].Data.IsForMailing = false;
                _clientManager.Update<PromoItem, PromoData>("promos", entities.Items[0]);
            }
        }

        public List<NewsCategory> GetCatalogNews(int pageSize)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var positions = _clientManager.Get<NewsItem, NewsData>("news");
                var columns = _clientManager.Get<CatalogNewsItem, CatalogNewsData>("external-catalogs-news");
                var result = _mapper.Map<List<NewsCategory>>(columns);
                foreach (var cat in result)
                {
                    cat.Items = new NewsTracker(pageSize);
                }

                foreach (var item in positions)
                {
                    var catalogItem = _mapper.Map<NewsArticle>(item);
                    var assetInfo = _clientManager.GetAsset(catalogItem.ImageUrl);
                    var opts = _clientManager.Schema.Options;
                    catalogItem.ImageUrl = assetInfo == null
                        ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                        : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    foreach (var category in item.Category)
                    {
                        var categoryObj = result.FirstOrDefault(i => i.Id == columns.FirstOrDefault(c => c.ItemId == category)?.ItemId);
                        categoryObj?.Items.Add(catalogItem);
                    }
                }
                return result.OrderByDescending(i => i.Sort).ToList();
            });
        }

        #endregion News & Promo-news

        #region Articles and Texts

        public Article GetArticle(string slug)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<ArticlesItem, ArticleData>("articles");
                var result = _mapper.Map<List<Article>>(data);
                return result.ToDictionary(i => i.Id, i => i);
            });
            slug = slug?.ToLower() ?? "";
            return list.ContainsKey(slug) ? list[slug] : null;
        }

        public BrandArticle GetBrandArticle(string slug)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<BrandArticlesItem, BrandArticleData>("brandarticles");
                var result = _mapper.Map<List<BrandArticle>>(data);
                return result.ToDictionary(i => i.Slug, i => i);
            });
            slug = slug?.ToLower() ?? "";
            return list.ContainsKey(slug) ? list[slug] : null;
        }

        public List<BrandItem> GetBrands()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<BrandItemItem, BrandItemData>("brand");
                var brandarticles = _clientManager.Get<BrandArticlesItem, BrandArticleData>("brandarticles");

                var result = _mapper.Map<List<BrandItem>>(data);
                foreach (var item in result)
                {
                    var assetInfo = _clientManager.GetAsset(item.Image);
                    var opts = _clientManager.Schema.Options;
                    item.Image = assetInfo == null
                            ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                            : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";

                    item.ArticlesSlug = brandarticles.FirstOrDefault(i =>
                        i.ItemId == item.Articles)?.Slug?.ToLower();

                    foreach (var gItemSet in item.Gallery.Values)
                    {
                        foreach (var gItem in gItemSet)
                        {
                            for (int i = 0; i < gItem.Image.Length; i++)
                            {
                                var gAssetInfo = _clientManager.GetAsset(gItem.Image[i]);
                                gItem.Image[i] = gAssetInfo == null
                                    ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                                    : $"{opts.Url}/api/assets/{opts.AppName}/{gAssetInfo.Slug}";

                            }
                        }
                    }

                    foreach (var gItemSet in item.Docs.Values)
                    {
                        foreach (var gItem in gItemSet)
                        {
                            for (int i = 0; i < gItem.File.Length; i++)
                            {
                                var gAssetInfo = _clientManager.GetAsset(gItem.File[i]);
                                gItem.File[i] = gAssetInfo == null
                                    ? null
                                    : $"{opts.Url}/api/assets/{opts.AppName}/{gAssetInfo.Slug}";

                            }
                        }
                    }

                    for (int i = 0; i < item.WarrantyImages.Length; i++)
                    {
                        var gAssetInfo = _clientManager.GetAsset(item.WarrantyImages[i]);
                        item.WarrantyImages[i] = gAssetInfo == null
                            ? null
                            : $"{opts.Url}/api/assets/{opts.AppName}/{gAssetInfo.Slug}";

                    }
                }
                return result.OrderByDescending(i => i.Sort).ToList();
            });
        }

        public List<CustomerReview> GetCustomerReviews()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<CustomerReviewsItem, CustomerReviewsData>("customer-reviews");
                var result = _mapper.Map<List<CustomerReview>>(data);
                foreach (var item in result)
                {
                    var assetInfo = _clientManager.GetAsset(item.Image);
                    var opts = _clientManager.Schema.Options;
                    item.Image = assetInfo == null
                        ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                        : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    //https://localhost:8005/api/assets/motex/62f319bd-dcac-46a2-adc3-c25ed5765f76/news-2.jpg?version=0
                }
                return result;
            });

        }

        public IncorporatingText GetIncorporatingText(string slug)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<IncorporatingTextItem, IncorporatingTextData>("incorporatingpages");
                var result = _mapper.Map<List<IncorporatingText>>(data);
                return result.ToDictionary(i => i.Id, i => i);
            });
            slug = slug?.ToLower() ?? "";
            return list.ContainsKey(slug) ? list[slug] : null;
        }

        #endregion Articles and Texts

        public SeoTemplate GetSeoTemplate(string type)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<SeoTemplateItem, SeoTemplateData>("seotemplate");
                var result = _mapper.Map<List<SeoTemplate>>(data);
                return result.ToDictionary(i => i.Type, i => i);
            });
            return list[type];
        }

        public MailMessageTemplate GetMailMessageTemplate(MailMessages message)
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<MailMessageTemplateItem, MailMessageTemplateData>("mail-messages");
                var result = _mapper.Map<List<MailMessageTemplate>>(data);
                return result.ToDictionary(i => i.Slug, i => i);
            });
            var msgKey = message.ToString().ToLower();
            if (!list.ContainsKey(msgKey))
            {
                Log.Error($"Mail message template {msgKey} not found");
                return null;
            }
            return list[msgKey];
        }

        public List<Banner> GetBanners()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<BannerItem, BannerData>("banners");
                var result = _mapper.Map<List<Banner>>(data);
                foreach (var item in result)
                {
                    var assetInfo = _clientManager.GetAsset(item.ImageUrl);
                    var opts = _clientManager.Schema.Options;
                    item.ImageUrl = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    //https://localhost:8005/api/assets/motex/62f319bd-dcac-46a2-adc3-c25ed5765f76/news-2.jpg?version=0
                }
                return result;
            });
            return list;
        }

        public Informer GetInformerMain()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<InformerItem, InformerData>("informer-main");
                if (!data.Any()) return null;
                var result = _mapper.Map<List<Informer>>(data).Last();

                if (result.Image != null)
                {
                    var assetInfo = _clientManager.GetAsset(result.Image);
                    var opts = _clientManager.Schema.Options;
                    result.Image = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                }

                if (result.ImageMob != null)
                {
                    var assetInfo = _clientManager.GetAsset(result.ImageMob);
                    var opts = _clientManager.Schema.Options;
                    result.ImageMob = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                }

                return result;
            });
            return list;
        }

        public List<FlashNews> GetFlashNewsMain()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<FlashNewsItem, FlashNewsData>("flash-news");
                if (!data.Any()) return new List<FlashNews>();
                var date = DateTime.Today;
                var result = _mapper.Map<List<FlashNews>>(data.Where(i => i.DateStart <= date && i.DateEnd >= date));
                return result;
            });

            return list;
        }

        public List<SocialLink> GetSocialLinks()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<SocialLinkItem, SocialLinkData>("social-links");
                return _mapper.Map<List<SocialLink>>(data.OrderBy(i => i.OrderNumber));
            });
        }

        public Menu GetPersonalMenu()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var dataItem = _clientManager.Get<MenuItemItem, MenuItemData>("menu-item");
                var resultItem = _mapper.Map<List<MenuItem>>(dataItem);

                var userRoles = GetUserRoles();

                foreach (var item in dataItem.Where(i => i.Parent?.Length > 0))
                {
                    foreach (var c in resultItem.Where(i => i.Id == item.Parent[0]))
                    {
                        c.Children.Add(resultItem.FirstOrDefault(i => i.Id == item.ItemId));
                    }
                }

                foreach (var item in resultItem)
                {
                    // Обработка ролей
                    if (item.RoleIds?.Length > 0)
                    {
                        item.Roles = new List<UserRolesCustom>();
                        foreach (var roleId in item.RoleIds)
                        {
                            var role = userRoles.FirstOrDefault(i => i.Id == roleId);
                            if (role != null) item.Roles.Add(role);
                        }
                    }

                    // Обработка изображений
                    var assetInfo = _clientManager.GetAsset(item.Image);
                    var opts = _clientManager.Schema.Options;
                    item.Image = assetInfo == null
                            ? null //$"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                            : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                }
                var removeList = dataItem.Where(i => i.Parent == null).Select(j => j.ItemId).ToList();
                resultItem = resultItem.Where(i => removeList.Contains(i.Id)).ToList();

                return new Menu { MenuItems = resultItem.OrderBy(i => i.ColumnNumber).ThenBy(i => i.Sort).ToList() };
            });
        }

        public DeliveryConfig GetDeliveryConfig()
        {
            return new DeliveryConfig
            {
                MaxAdressesCount = 100
            };
        }

        public Configuration GetConfiguration()
        {
            return new Configuration();
        }

        public List<FooterColumn> GetFooterColumns()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var positions = _clientManager.Get<FooterPositionItem, FooterPositionData>("footer-positions");
                var columns = _clientManager.Get<FooterColumnItem, FooterColumnData>("footer-columns");
                var result = _mapper.Map<List<FooterColumn>>(columns.OrderBy(i => i.OrderNumber));
                foreach (var item in positions.OrderBy(i => i.OrderNumber))
                {
                    var col = result.FirstOrDefault(i =>
                        i.Id == columns.FirstOrDefault(c => c.ItemId == item.Column[0])?.Id);
                    col?.Positions.Add(_mapper.Map<FooterPosition>(item));
                }
                return result;
            });
        }

        public List<MenuLevel1> GetMenu()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var positions = _clientManager.Get<MenuLevel2Item, MenuLevel2Data>("top-menu-level2");
                var columns = _clientManager.Get<MenuLevel1Item, MenuLevel1Data>("top-menu-level1");
                var result = _mapper.Map<List<MenuLevel1>>(columns.OrderBy(i => i.OrderNumber));
                foreach (var item in positions.OrderBy(i => i.OrderNumber))
                {
                    var col = result.FirstOrDefault(i =>
                        i.Id == columns.FirstOrDefault(c => c.ItemId == item.Level1[0])?.ItemId);
                    col?.Level2.Add(_mapper.Map<MenuLevel2>(item));
                }
                return result;
            });
        }

        public List<UserRolesCustom> GetUserRoles()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<UserRolesCustomItem, UserRolesCustomData>("user-roles");
                var list = _mapper.Map<List<UserRolesCustom>>(data);

                return list;
            });

        }

        public List<WareGroups> GetWaregroups()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<WareGroupItem, WareGroupData>("ware-groups");
                var result = _mapper.Map<List<WareGroups>>(data);
                foreach (var item in result)
                {
                    var assetInfo = _clientManager.GetAsset(item.ImageUrl);
                    var opts = _clientManager.Schema.Options;
                    item.ImageUrl = assetInfo == null
                        ? $"{opts.Url}/api/assets/{opts.AppName}/{ConfigHelper.DefaultImg}"
                        : $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                }
                return result;
            });
            return list;
        }

        public List<HeaderNav> GetHeaderNav()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<HeaderNavItem, HeaderNavData>("header-nav");
                var result = _mapper.Map<List<HeaderNav>>(data);
                foreach (var item in result)
                {
                    if (item.Image != null)
                    {
                        var assetInfo = _clientManager.GetAsset(item.Image);
                        var opts = _clientManager.Schema.Options;
                        item.Image = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    }

                }
                return result;
            });
            return list;
        }

        public Contact GetContact()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<ContactItem, ContactData>("contact");
                if (!data.Any()) return new Contact();
                var result = _mapper.Map<Contact>(data[0]);
                var image = new List<string>();
                foreach (var item in result.PaymentImg)
                {
                    var assetInfo = _clientManager.GetAsset(item);
                    var opts = _clientManager.Schema.Options;
                    image.Add($"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}");
                }
                result.PaymentImg = image;
                return result;
            });
            return list;
        }

        public string GetCallManagersMails()
        {
            throw new System.NotImplementedException();
        }

        public List<Shops> GetShops(string shopName = "motex-item")
        {
            var key = MethodBase.GetCurrentMethod().Name + shopName;
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _shopManager.Get<ShopItem, ShopData>(shopName);
                var result = _mapper.Map<List<Shops>>(data);
                foreach (var item in result)
                {
                    foreach (var img in item.Image.Select((value, i) => new { i, value }))
                    {
                        var assetInfo = _shopManager.GetAsset(img.value);
                        var opts = _shopManager.Schema.Options;
                        item.Image[img.i] = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                    }
                }
                return result;
            });
            return list;
        }

        public List<OrderPayment> GetOrderPayment()
        {

            var data = _clientManager.Get<PaymentItem, PaymentData>("payment");
            if (!data.Any()) return new List<OrderPayment>();

            var result = _mapper.Map<List<OrderPayment>>(data);
            foreach (var item in result)
            {
                foreach (var files in item.Files.ToLObjectGeneric())
                {
                    var assetInfo = _clientManager.GetAsset(files.File[0]);
                    var opts = _clientManager.Schema.Options;
                    files.File[0] = $"{opts.Url}/api/assets/{opts.AppName}/{assetInfo.Slug}";
                }
            }

            return result.OrderBy(i => i.Sort).ToList();
        }

        public OrderInfoText GetOrderInfo(string infoType)
        {
            var data = _clientManager.Get<InfoTextItem, InfoTextData>(infoType);
            if (data == null) return new OrderInfoText();

            var result = _mapper.Map<OrderInfoText>(data[0]);
            return result;
        }

        public OrderInfoText GetInfoAdditional()
        {
            return GetOrderInfo("info-additional");
        }

        public OrderInfoText GetInfoDelivery()
        {
            return GetOrderInfo("info-delivery");
        }

        public OrderInfoText GetInfoPayment()
        {
            return GetOrderInfo("info-payment");
        }

        public OrderInfoText GetInfoAttention()
        {
            return GetOrderInfo("info-attention");
        }

        public EmbeddedText GetEmbeddedText(int id)
        {

            var key = $"{MethodBase.GetCurrentMethod().Name}_{id}";
            var list = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<EmbeddedTextItem, EmbeddedTextData>("embedded-text");
                if (data == null) return new EmbeddedText();

                var listEmbedded = _mapper.Map<List<EmbeddedText>>(data);
                var result = listEmbedded.FirstOrDefault(i => i.Id == id);

                return result ?? new EmbeddedText();
            });
            return list;
        }

        public SuccessfulText GetSuccessPageText()
        {
            var key = $"{MethodBase.GetCurrentMethod().Name}";
            var text = HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.Get<SuccessfulTextItem, SuccessfulTextData>("successful-page");
                var result = _mapper.Map<SuccessfulText>(data[0]);
                return result;
            });
            return text;
        }
    }
}
