using AutoMapper;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.Cart;

namespace Webmall.Model.Database.Mappings
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<DbCartPosition, CartPosition>()
                .ForMember(d => d.Id, s => s.MapFrom(i => i.Id));

            CreateMap<CartPosition, DbCartPosition>()
                .ForMember(d => d.Id, s => s.Ignore());
       }
    }
}