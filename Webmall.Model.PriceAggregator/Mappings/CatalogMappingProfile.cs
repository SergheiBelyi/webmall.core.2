using AutoMapper;
using Webmall.Model.Entities.Auto;
using Webmall.Model.PriceAggregator.DataModels;
using Webmall.Model.PriceAggregator.DataModels.Brand;
using Webmall.Model.PriceAggregator.DataModels.Groups;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.PriceAggregator.DataModels.Ware;
using WareListItem = Webmall.Model.Entities.Catalog.WareListItem;

namespace Webmall.Model.PriceAggregator.Mappings
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<GroupViewListModel, Group>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.GroupId))
                .ForMember(i => i.ParentId, e => e.MapFrom(i => i.GroupParentId))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.GroupName))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.GroupName));

            CreateMap<GroupsModel, Group>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.ParentId, e => e.MapFrom(i => i.ParentId))
                .ForMember(i => i.Order, e => e.MapFrom(i => i.Order))
                .ForMember(i => i.Title, e => e.MapFrom(i => i.Title))
                .ForMember(i => i.Keywords, e => e.MapFrom(i => i.Keywords))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.Description))
                .ForMember(i => i.Text, e => e.MapFrom(i => i.Text))
                .ForMember(i => i.Url, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.IconUrl, e => e.MapFrom(i => i.Image))
                .ForMember(i => i.ImageUrl, e => e.MapFrom(i => i.ImageUrl))
                .ForMember(i => i.IsNew, e => e.MapFrom(i => i.IsNew))
                .ForMember(i => i.SubGroups, e => e.MapFrom(i => i.SubGroups));

            CreateMap<ProducerModel, Producer>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.OurProducer, e => e.MapFrom(i => i.OurProducer))
                .ForMember(i => i.UrlName, e => e.MapFrom(i => i.Url))
                .ForMember(i => i.ImageUrl, e => e.MapFrom(i => i.Image))
                .ForMember(i => i.IsOEM, e => e.MapFrom(i => i.IsOEM))
                .ForMember(i => i.DescriptionText, e => e.MapFrom(i => i.Description));

            CreateMap<BrandModel, Producer>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.BrandId.ToString()))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.BrandName))
                .ForMember(i => i.IsOEM, e => e.MapFrom(i => i.IsOriginal));

            CreateMap<BrandModel, Producer>()
               .ForMember(i => i.Id, e => e.MapFrom(i => i.BrandId.ToString()))
               .ForMember(i => i.Name, e => e.MapFrom(i => i.BrandName))
               .ForMember(i => i.IsOEM, e => e.MapFrom(i => i.IsOriginal));

            CreateMap<WareReplacementsModel, WareReplacement>().IncludeBase<OfferModel, Offer>()
                .ForMember(i => i.Ware, e => e.MapFrom(i => i.WareData));

            CreateMap<OfferModel, Offer>()
              .ForMember(i => i.SupplierUid, e => e.MapFrom(i => i.SupplierUid))
              .ForMember(i => i.IsTradeOrganization, e => e.MapFrom(i => i.IsOrganization))
              .ForMember(i => i.SupplierWarehouseUid, e => e.MapFrom(i => i.SupplierWarehouseUid))
              .ForMember(i => i.SupplierWarehouseName, e => e.MapFrom(i => i.SupplierWarehouseName))
              .ForMember(i => i.PricelistUid, e => e.MapFrom(i => i.PricelistUid))
              .ForMember(i => i.SaleQnt, e => e.MapFrom(i => i.SaleMultiplier))
              .ForMember(i => i.AvailableQnt, e => e.MapFrom(i => i.AvailableQnt))
              .ForMember(i => i.AvailableQntStr, e => e.MapFrom(i => i.AvailableQntStr))
              .ForMember(i => i.ClientPrice, e => e.MapFrom(i => i.ClientPrice))
              .ForMember(i => i.ClientSalePrice, e => e.MapFrom(i => i.ClientSalePrice))
              .ForMember(i => i.RecommendedPrice, e => e.MapFrom(i => i.RegPrice))
              .ForMember(i => i.DeliveryDays, e => e.MapFrom(i => i.DeliveryDays))
              .ForMember(i => i.DeliveryTerm, e => e.MapFrom(i => i.DeliveryDate))
              .ForMember(i => i.DeliveryRating, e => e.MapFrom(i => (int) (i.DeliveryRating ?? 0)))
              .ForMember(i => i.ReturnDays, e => e.MapFrom(i => i.ReturnDays))
              .ForMember(i => i.SupplierWareName, e => e.MapFrom(i => i.SupplierWareName))
              .ForMember(i => i.SupplierWareNumber, e => e.MapFrom(i => i.SupplierWareNumber))
              .ForMember(i => i.SupplierBrandName, e => e.MapFrom(i => i.SupplierBrandName))
              .ForMember(i => i.MyWarehouse, e => e.MapFrom(i => i.MyWarehouse))
              .ForMember(i => i.BestPrice, e => e.MapFrom(i => i.BestPrice))
              .ForMember(i => i.BestQnt, e => e.MapFrom(i => i.BestQnt))
              .ForMember(i => i.BestDelivery, e => e.MapFrom(i => i.BestDelivery))
              .ForMember(i => i.BestReturn, e => e.MapFrom(i => i.BestReturn))
              .ForMember(i => i.Id, e => e.MapFrom(i => i.OfferId));

            CreateMap<ImageInfoModel, ImageInfo>();

            CreateMap<WareModel, Ware>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.WareData.Id > 0 ? i.WareData.Id.ToString() : null))
                .ForMember(i => i.GroupId, e => e.MapFrom(i => i.WareData.GroupId))
                .ForMember(i => i.ProducerId, e => e.MapFrom(i => i.WareData.ProducerUid))
                .ForMember(i => i.WareNumber, e => e.MapFrom(i => i.WareData.WareNumber))
                .ForMember(i => i.ProducerName, e => e.MapFrom(i => i.WareData.ProducerName))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.WareData.Name))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.WareData.Description))
                .ForMember(i => i.InAction, e => e.MapFrom(i => i.Features.InAction))
                //.ForMember(i => i.IsSale, e => e.MapFrom(i => i.Features.IsSale))
                .ForMember(i => i.IsNew, e => e.MapFrom(i => i.Features.IsNew))
                .ForMember(i => i.MeasureUnit, e => e.MapFrom(i => i.WareData.UnitId))
                .ForMember(i => i.Images, e => e.MapFrom(i => i.Images));

            CreateMap<WareModel, WareListItem>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.WareData.Id > 0 ? i.WareData.Id.ToString() : null))
                .ForMember(i => i.GroupId, e => e.MapFrom(i => i.WareData.GroupId))
                .ForMember(i => i.ProducerId, e => e.MapFrom(i => i.WareData.ProducerId))
                .ForMember(i => i.WareNumber, e => e.MapFrom(i => i.WareData.WareNumber))
                .ForMember(i => i.ProducerName, e => e.MapFrom(i => i.WareData.ProducerName))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.WareData.Name))
                .ForMember(i => i.Description, e => e.MapFrom(i => i.WareData.Description))
                .ForMember(i => i.MeasureUnit, e => e.MapFrom(i => i.WareData.UnitId));

            CreateMap<WarePropertiesModel, WareProperty>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
                .ForMember(i => i.PropTypeId, e => e.MapFrom(i => (i.PropTypeId ?? 0).ToString()))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Value, e => e.MapFrom(i => i.Value))
                .ForMember(i => i.Importance, e => e.MapFrom(i => i.Importance));

            CreateMap<WareApplicabilityModel, Applicability>()
              .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
              .ForMember(i => i.Mark, e => e.MapFrom(i => i.Mark))
              .ForMember(i => i.Model, e => e.MapFrom(i => i.Model))
              .ForMember(i => i.Modification, e => e.MapFrom(i => i.Modification))
              .ForMember(i => i.DateBegin, e => e.MapFrom(i => i.DateBegin))
              .ForMember(i => i.DateEnd, e => e.MapFrom(i => i.DateEnd))
              .ForMember(i => i.KW, e => e.MapFrom(i => i.KW))
              .ForMember(i => i.PS, e => e.MapFrom(i => i.Ps))
              .ForMember(i => i.CcmTech, e => e.MapFrom(i => i.CcmTech))
              .ForMember(i => i.BodyTypeName, e => e.MapFrom(i => i.BodyTypeName));

            CreateMap<DataModels.WareListItem, WareListItem>()
              .ForMember(i => i.Id, e => e.MapFrom(i => i.Id > 0 ? i.Id.ToString() : null))
              .ForMember(i => i.GroupId, e => e.MapFrom(i => i.GroupUid))
              .ForMember(i => i.ProducerId, e => e.MapFrom(i => i.ProducerId))
              .ForMember(i => i.WareNumber, e => e.MapFrom(i => i.WareNumber))
              .ForMember(i => i.ProducerName, e => e.MapFrom(i => i.ProducerName))
              .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
              .ForMember(i => i.Description, e => e.MapFrom(i => i.Description))
              .ForMember(i => i.Qnt, e => e.MapFrom(i => i.PackQnt));

            CreateMap<GroupPropertyModel, GroupProperty>()
             .ForMember(i => i.Id, e => e.MapFrom(i => i.Id))
             .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
             .ForMember(i => i.AvailableValues, e => e.MapFrom(i => i.AvailableValues))
             .ForMember(i => i.Importance, e => e.MapFrom(i => i.Importance));

        }
    }
}