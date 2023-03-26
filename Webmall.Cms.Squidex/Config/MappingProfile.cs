using AutoMapper;
using Squidex.ClientLibrary.Management;
using Webmall.Cms.Squidex.Config.Models.Email;
using Webmall.Model.Entities.Cms.Localization;
using EmailConfig = ValmiStore.Model.Entities.Configuration.EmailConfig;

namespace Webmall.Cms.Squidex.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmailConfigData, EmailConfig>()
                .ForMember(i => i.IsSslEnabled, e => e.MapFrom(i => i.SSLEnabled));

            CreateMap<AppLanguageDto, Language>()
                .ForMember(i => i.Culture, e => e.MapFrom(i => i.Iso2Code.ToLower()))
                .ForMember(i => i.Display, e => e.MapFrom(i => i.Iso2Code.Contains("-") ? i.Iso2Code.Split('-')[0] : i.Iso2Code))
                .ForMember(i => i.IsDefault, e => e.MapFrom(i => i.IsMaster));
        }
    }
}