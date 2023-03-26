using AutoMapper;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.Garage;

namespace Webmall.Model.Database.Mappings
{
    public class GarageMappingProfile : Profile
    {
        public GarageMappingProfile()
        {
            CreateMap<DbCar, Car>()
                .ForMember(d => d.Id, s => s.MapFrom(i => i.Id.ToString()))
                .ForMember(d => d.MarkaId, s => s.MapFrom(i => i.MarkaId.ToString()))
                .ForMember(d => d.ModelId, s => s.MapFrom(i => i.ModelId.ToString()))
                .ForMember(d => d.ModificationId, s => s.MapFrom(i => i.ModificationId.ToString()))
                .ForMember(d => d.IsSelected, s => s.MapFrom(i => i.IsSelected ?? false));

            CreateMap<Car, DbCar>()
                .ForMember(d => d.Id, s => s.Ignore())
                .ForMember(d => d.MarkaId, s => s.MapFrom(i => i.MarkaId.ToInt()))
                .ForMember(d => d.ModelId, s => s.MapFrom(i => i.ModelId.ToInt()))
                .ForMember(d => d.ModificationId, s => s.MapFrom(i => i.ModificationId.ToInt()));
       }
    }
}