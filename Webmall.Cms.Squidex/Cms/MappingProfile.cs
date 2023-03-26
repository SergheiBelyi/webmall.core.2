using AutoMapper;
using Webmall.Cms.Squidex.Cms.Models.Articles;
using Webmall.Cms.Squidex.Cms.Models.Banners;
using Webmall.Cms.Squidex.Cms.Models.BrandArticles;
using Webmall.Cms.Squidex.Cms.Models.Brands;
using Webmall.Cms.Squidex.Cms.Models.CatalogNews;
using Webmall.Cms.Squidex.Cms.Models.Contact;
using Webmall.Cms.Squidex.Cms.Models.CustomerReviews;
using Webmall.Cms.Squidex.Cms.Models.EmbeddedText;
using Webmall.Cms.Squidex.Cms.Models.ExternalCatalog;
using Webmall.Cms.Squidex.Cms.Models.FlashNews;
using Webmall.Cms.Squidex.Cms.Models.FooterColumns;
using Webmall.Cms.Squidex.Cms.Models.HeaderNav;
using Webmall.Cms.Squidex.Cms.Models.IncorporatingText;
using Webmall.Cms.Squidex.Cms.Models.Informer;
using Webmall.Cms.Squidex.Cms.Models.MailMessageTemplate;
using Webmall.Cms.Squidex.Cms.Models.Menu;
using Webmall.Cms.Squidex.Cms.Models.News;
using Webmall.Cms.Squidex.Cms.Models.Order;
using Webmall.Cms.Squidex.Cms.Models.PersonalMenu;
using Webmall.Cms.Squidex.Cms.Models.SeoTemplate;
using Webmall.Cms.Squidex.Cms.Models.Shops;
using Webmall.Cms.Squidex.Cms.Models.SocialLinks;
using Webmall.Cms.Squidex.Cms.Models.UserRolesCustom;
using Webmall.Cms.Squidex.Cms.Models.WareGroup;
using Webmall.Cms.Squidex.Helpers;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.Cms.Brand;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.ExternalCatalog;
using Webmall.Model.Entities.Cms.Footer;
using Webmall.Model.Entities.Cms.HomePage;
using Webmall.Model.Entities.Cms.Menu;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.Model.Entities.Cms.Order;
using Webmall.Model.Entities.Cms.PersonalMenu;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Cms.Squidex.Cms
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewsData, NewsArticle>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Date, e => e.MapFrom(i => i.Date))
                .ForMember(i => i.Header, e => e.MapFrom(i => i.Header))
                .ForMember(i => i.ShortText, e => e.MapFrom(i => i.Short))
                .ForMember(i => i.FullText, e => e.MapFrom(i => i.Full.ToHtml()))
                .ForMember(i => i.ImageUrl, e => e.MapFrom(i => i.Image[0]))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle ?? i.Header))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly))
                .ForMember(i => i.SendForSubscribers, e => e.MapFrom(i => i.IsForMailing))
                .ForMember(i => i.Sort, e => e.MapFrom(i => i.Sort));

            CreateMap<PromoData, PromotionNews>()
                .IncludeBase<NewsData, NewsArticle>()
                .ForMember(i => i.MarketingActionLink, e => e.MapFrom(i => i.MarketingActionLink));

            CreateMap<SeoTemplateData, SeoTemplate>()
                .ForMember(i => i.Type, e => e.MapFrom(i => i.Type.ToLower()))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings));

            CreateMap<CustomerReviewsData, CustomerReview>()
                .ForMember(i => i.CustomerName, e => e.MapFrom(i => i.CustomerName))
                .ForMember(i => i.Image, e => e.MapFrom(i => i.Image[0]))
                .ForMember(i => i.ShortText, e => e.MapFrom(i => i.Short))
                .ForMember(i => i.Date, e => e.MapFrom(i => i.Date))
                .ForMember(i => i.IsScroll, e => e.MapFrom(i => i.IsScroll))
                .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.FullText, e => e.MapFrom(i => i.Full.ToHtml()))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings));

            CreateMap<ArticleData, Article>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Header, e => e.MapFrom(i => i.Header))
                .ForMember(i => i.FullText, e => e.MapFrom(i => i.Full.ToHtml()))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle ?? i.Header))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly))
                .ForMember(i => i.SendForSubscribers, e => e.MapFrom(i => i.IsForMailing));

            CreateMap<BrandArticleData, BrandArticle>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
                .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Header, e => e.MapFrom(i => i.Header))
                .ForMember(i => i.FullText, e => e.MapFrom(i => i.Full.ToHtml()))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle ?? i.Header))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings));

            CreateMap<BrandItemData, BrandItem>()
               .ForMember(i => i.Image, e => e.MapFrom(i => i.Image[0]))
               .ForMember(i => i.OriginalName, e => e.MapFrom(i => i.OriginalName))
               .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
               .ForMember(i => i.IsRecommended, e => e.MapFrom(i => i.IsRecommended))
               .ForMember(i => i.IsAction, e => e.MapFrom(i => i.IsAction))
               .ForMember(i => i.Articles, e => e.MapFrom(i => i.Articles[0]))
               .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug))
               .ForMember(i => i.Rating, e => e.MapFrom(i => i.Rating))
               .ForMember(i => i.CountryOrigin, e => e.MapFrom(i => i.CountryOrigin))
               .ForMember(i => i.LinkOrigin, e => e.MapFrom(i => i.LinkOrigin))
               .ForMember(i => i.LinkCatalog, e => e.MapFrom(i => i.LinkCatalog))
               .ForMember(i => i.Sort, e => e.MapFrom(i => i.Sort))
               .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle))
               .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
               .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings))
               .ForMember(i => i.Marks, e => e.MapFrom(i => i.Marks.LTagStrings))
               .ForMember(i => i.Assemblies, e => e.MapFrom(i => i.Assemblies.LTagStrings))
               .ForMember(i => i.VehicleTypes, e => e.MapFrom(i => i.VehicleTypes.LTagStrings))
               .ForMember(i => i.Features, e => e.MapFrom(i => i.Features))
               .ForMember(i => i.Gallery, e => e.MapFrom(i => i.Gallery));

            CreateMap<IncorporatingTextData, IncorporatingText>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Text, e => e.MapFrom(i => i.Text.ToHtml()));

            CreateMap<MailMessageTemplateData, MailMessageTemplate>()
                .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug.ToLower()))
                .ForMember(i => i.Receivers, e => e.MapFrom(i => i.Receivers))
                .ForMember(i => i.Text, e => e.MapFrom(i => i.Text.ToHtml()));

            CreateMap<BannerData, Banner>()
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ImageUrl, e => e.MapFrom(i => i.Image[0]))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly))
                .ForMember(i => i.ForLanguage, e => e.MapFrom(i => i.ForLanguage));

            CreateMap<MenuItemData, MenuItem>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Link, e => e.MapFrom(i => i.Link))
                .ForMember(i => i.Sort, e => e.MapFrom(i => i.Sort))
                .ForMember(i => i.ColumnNumber, e => e.MapFrom(i => i.Column))
                .ForMember(i => i.Image, e => e.MapFrom(i => i.Image[0]))
                .ForMember(i => i.RoleIds, e => e.MapFrom(i => i.Roles))
                .ForMember(i => i.Roles, e => e.Ignore());

            CreateMap<UserRolesCustomData, UserRolesCustom>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name));

            //CreateMap<Property, MenuItem>()
            //    .ForMember(i => i.Id, e => e.MapFrom(i => i.Property1))
            //    .ForMember(i => i.Name, e => e.MapFrom(i => i.Property2));

            CreateMap<InformerData, Informer>()
                .ForMember(i => i.Name, e => e.MapFrom(i=>i.Name))
                .ForMember(i => i.DateStart, e => e.MapFrom(i => i.DateStart))
                .ForMember(i => i.DateEnd, e => e.MapFrom(i => i.DateEnd))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly))
                .ForMember(i => i.ForLanguage, e => e.MapFrom(i => i.ForLanguage))
                .ForMember(i => i.Image, e => e.MapFrom(i => i.Image[0]))
                .ForMember(i => i.ImageMob, e => e.MapFrom(i => i.ImageMob[0]))
                .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId));

            CreateMap<FlashNewsData, FlashNews>()
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.DateStart, e => e.MapFrom(i => i.DateStart))
                .ForMember(i => i.DateEnd, e => e.MapFrom(i => i.DateEnd))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly));

            CreateMap<SocialLinkData, SocialLink>()
                .ForMember(i => i.OrderNumber, e => e.MapFrom(i => i.OrderNumber))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Type))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ClassName, e => e.MapFrom(i => i.CssClass))
                .ForMember(i => i.IconName, e => e.MapFrom(i => i.IconName));

            CreateMap<FooterColumnData, FooterColumn>()
                .ForMember(i => i.OrderNumber, e => e.MapFrom(i => i.OrderNumber))
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Title));

            CreateMap<FooterPositionData, FooterPosition>()
                .ForMember(i => i.OrderNumber, e => e.MapFrom(i => i.OrderNumber))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Title))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly));

            CreateMap<MenuLevel1Data, MenuLevel1>()
                .ForMember(i => i.OrderNumber, e => e.MapFrom(i => i.OrderNumber))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Title))
                .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly));

            CreateMap<MenuLevel2Data, MenuLevel2>()
                .ForMember(i => i.OrderNumber, e => e.MapFrom(i => i.OrderNumber))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Title))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ForGrossOnly, e => e.MapFrom(i => i.IsGrossOnly))
                .ForMember(i => i.ForRetailOnly, e => e.MapFrom(i => i.IsRetailOnly));

            CreateMap<CatalogCategoryData, CatalogCategory>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
                .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Header));

            CreateMap<CatalogItemData, CatalogItem>()
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.Icon, e => e.MapFrom(i => i.Icon))
                .ForMember(i => i.LinkText, e => e.MapFrom(i => i.Description))
                .ForMember(i => i.FileUrl, e => e.MapFrom(i => i.Content[0]));

            CreateMap<CatalogNewsData, NewsCategory>()
               .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
               .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug))
               .ForMember(i => i.Name, e => e.MapFrom(i => i.Header))
               .ForMember(i => i.IsActive, e => e.MapFrom(i => i.IsActive))
               .ForMember(i => i.Sort, e => e.MapFrom(i => i.Sort));

            CreateMap<WareGroupData, WareGroups>()
                .ForMember(i => i.IdGroup, e => e.MapFrom(i => i.IdGroup))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Order, e => e.MapFrom(i => i.Order))
                .ForMember(i => i.Slug, e => e.MapFrom(i => i.Slug))
                .ForMember(i => i.IsNew, e => e.MapFrom(i => i.IsNew))
                .ForMember(i => i.IconUrl, e => e.MapFrom(i => i.IconUrl))
                .ForMember(i => i.ImageUrl, e => e.MapFrom(i => i.ImageUrl))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings));

            CreateMap<HeaderNavData, HeaderNav>()
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.Image, e => e.MapFrom(i => i.Image[0]))
                .ForMember(i => i.Icon, e => e.MapFrom(i => i.Icon))
                .ForMember(i => i.Sort, e => e.MapFrom(i => i.Sort));

            CreateMap<ContactData, Contact>()
                .ForMember(i => i.CompanyName, e => e.MapFrom(i => i.CompanyName))
                .ForMember(i => i.Phones, e => e.MapFrom(i => i.Phones))
                .ForMember(i => i.Emails, e => e.MapFrom(i => i.Emails))
                .ForMember(i => i.Schedule, e => e.MapFrom(i => i.Schedule))
                .ForMember(i => i.MainOffice, e => e.MapFrom(i => i.MainOffice))
                .ForMember(i => i.PaymentImg, e => e.MapFrom(i => i.Payment));

            CreateMap<ShopData, Shops>()
               .ForMember(i => i.Id, e => e.MapFrom(i => i.ItemId))
               .ForMember(i => i.Title, e => e.MapFrom(i => i.MetaTitle ?? i.Name))
               .ForMember(i => i.Description, e => e.MapFrom(i => i.MetaDescription))
               .ForMember(i => i.Keywords, e => e.MapFrom(i => i.MetaKeywords.LTagStrings));

            CreateMap<PaymentData, OrderPayment>()
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.Description))
                .ForMember(i => i.Files, e => e.MapFrom(i => i.FileList))
                .ForMember(i => i.Checkbox, e => e.MapFrom(i => i.CheckboxList))
                .ForMember(i => i.ViewName, e => e.MapFrom(i => i.ViewName))
                .ForMember(i => i.Sort, e => e.MapFrom(i => i.Sort));

            CreateMap<InfoTextData, OrderInfoText>()
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.Description));

            CreateMap<EmbeddedTextData, EmbeddedText>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.Description));

            CreateMap<SuccessfulTextData, SuccessfulText>();

        }
    }
}