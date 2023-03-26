using System.Collections.Generic;
using AutoMapper;
using Laximo.Guayaquil.Data.Entities;

namespace Webmall.Laximo.Entities
{
    public class LaximoAutoMapperProfile : Profile
    {
        public LaximoAutoMapperProfile()
        {
            CreateMap<Wizard, WizardRow>()
                .ForMember(i => i.Options, e => e.MapFrom(i => i.options))
                .ForMember(i => i.AllowListVehicles, e => e.MapFrom(i => i.allowlistvehicles))
                .ForMember(i => i.Name, e => e.MapFrom(i => i.name))
                .ForMember(i => i.Determined, e => e.MapFrom(i => i.determined))
                .ForMember(i => i.Type, e => e.MapFrom(i => i.type))
                .ForMember(i => i.Value, e => e.MapFrom(i => i.value))
                .ForMember(i => i.Ssd, e => e.MapFrom(i => i.ssd))
                .ForMember(i => i.Automatic, e => e.MapFrom(i => i.automatic));

            CreateMap<WizardOption, KeyValuePair<string, string>>()
                .ConstructUsing(kvp => new KeyValuePair<string, string>(kvp.key, kvp.value));
        }
    }
}