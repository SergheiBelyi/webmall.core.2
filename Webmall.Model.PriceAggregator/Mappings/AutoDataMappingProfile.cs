using System.Web.Mvc;
using AutoMapper;
using PriceAggregator.Domain.Common;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.PriceAggregator.DataModels.AutoData;
using AutoMarka = Webmall.Model.Entities.Auto.AutoMarka;
using AutoModel = Webmall.Model.Entities.Auto.AutoModel;

namespace Webmall.Model.PriceAggregator.Mappings
{
    public class AutoDataMappingProfile : Profile
    {
        public AutoDataMappingProfile()
        {
            CreateMap<DataModels.AutoData.AutoMarka, AutoMarka>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id.ToString()));
            CreateMap<DataModels.AutoData.AutoModel, AutoModel>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id.ToString()));
            CreateMap<AutoModificationBase, AutoModification>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id.ToString()));
            CreateMap<AutoModificationData, AutoModification>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id.ToString()));
            CreateMap<AutoModificationFull, AutoModification>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id.ToString()));
            CreateMap<BaseReference<int, string>, SelectListItem>()
                .ForMember(i => i.Value, e => e.MapFrom(i => i.Id.ToString()))
                .ForMember(i => i.Text, e => e.MapFrom(i => i.Value));
            CreateMap<AssemblyTreeItem, Group>()
                .ForMember(i => i.Id, e => e.MapFrom(i => i.Id.ToString()))
                .ForMember(i => i.SubGroups, e => e.MapFrom(i => i.Children))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.Name))
                .ForMember(i => i.Children, e => e.Ignore());
        }
    }
}