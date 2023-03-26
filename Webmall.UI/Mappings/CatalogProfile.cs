using AutoMapper;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Mappings
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<WareListItem, Ware>();
            CreateMap<Offer, Offer>();
        }
    }
}