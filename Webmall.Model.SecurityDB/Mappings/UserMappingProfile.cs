using AutoMapper;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.Address;
using Webmall.Model.Entities.User;
using Webmall.Model.Entities.VinSearch;

namespace Webmall.Model.Database.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<DbUser, DbUserHistory>().ForMember(d => d.Id, s => s.Ignore());

            CreateMap<DbUser, User>()
                .ForMember(d => d.FullName, s => s.Ignore())
                .ForMember(d => d.Configuration, s => s.MapFrom(i => i.Configuration ?? new DbUserConfiguration()))
                .ForMember(d => d.Presenters, s => s.MapFrom(i => i.Presentations))
                .ForMember(d => d.IsVinSearchUnlimited, s => s.MapFrom(i => i.Configuration.VinSearchLimit.HasValue && i.Configuration.VinSearchLimit.Value == 0))
                .ForMember(d => d.IsVinSearchDefaultLimit, s => s.MapFrom(i => !i.Configuration.VinSearchLimit.HasValue || i.Configuration.VinSearchLimit.Value == -1))
                .ForMember(d => d.VinSearchLimitCounter, s => s.MapFrom(i => (i.Configuration.VinSearchLimit ?? -1) > 0 ? i.Configuration.VinSearchLimit ?? 1 : 1))
                ;

            CreateMap<User, DbUser>()
                .ForMember(d => d.Id, s => s.Ignore())
                .ForMember(d => d.Password, s => s.Ignore())
                .ForMember(d => d.RegistrationDate, s => s.Ignore())
                .ForMember(d => d.Configuration, s => s.MapFrom(i => i.Configuration));

            CreateMap<DbUserConfiguration, UserConfiguration>();

            CreateMap<UserConfiguration, DbUserConfiguration>()
                .ForMember(d => d.User, s => s.Ignore())
                .ForMember(d => d.UserId, s => s.Ignore())
                .ForMember(d => d.SendOrderResume, s => s.MapFrom(i => i.SendOrderResume));

            CreateMap<DbUserConfiguration, UserConfiguration>();

            CreateMap<UserConfiguration, DbUserConfiguration>()
                .ForMember(d => d.User, s => s.Ignore())
                .ForMember(d => d.UserId, s => s.Ignore())
                ;

            CreateMap<DbClientPresenter, ClientPresenter>();

            CreateMap<ClientPresenter, DbClientPresenter>()
                .ForMember(d => d.User, s => s.Ignore())
                .ForMember(d => d.UserId, s => s.Ignore())
                ;

            CreateMap<DbAddress, Address>();

            CreateMap<ClientPresenter, DbClientPresenter>()
                .ForMember(d => d.User, s => s.Ignore())
                .ForMember(d => d.UserId, s => s.Ignore())
                ;

            CreateMap<VinSearchHistoryItem, DbVinSearchHistory>()
                .ForMember(d => d.Id, s => s.Ignore())
                .ForMember(d => d.UserId, s => s.MapFrom(i => i.UserId))
                .ForMember(d => d.IP, s => s.MapFrom(i => i.UserIP))
                .ForMember(d => d.Date, s => s.MapFrom(i => i.Date))
                .ForMember(d => d.Vin, s => s.MapFrom(i => i.VIN))
                .ForMember(d => d.AutoName, s => s.MapFrom(i => i.AutoName))
                .ForMember(d => d.IsSuccessful, s => s.MapFrom(i => i.IsSuccessful))
                ;

            CreateMap<DbVinSearchHistory, VinSearchHistoryItem>()
                .ForMember(d => d.Id, s => s.Ignore())
                .ForMember(d => d.UserId, s => s.MapFrom(i => i.UserId))
                .ForMember(d => d.UserIP, s => s.MapFrom(i => i.IP))
                .ForMember(d => d.Date, s => s.MapFrom(i => i.Date))
                .ForMember(d => d.VIN, s => s.MapFrom(i => i.Vin))
                .ForMember(d => d.AutoName, s => s.MapFrom(i => i.AutoName))
                .ForMember(d => d.IsSuccessful, s => s.MapFrom(i => i.IsSuccessful))
                ;
        }
    }
}