using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Webmall.Model.Database.Mappings;
using Webmall.Model.Database.Repositories;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Database
{
    public static class ServicesConnector
    {
        public static void RegisterRepositories (ContainerBuilder builder, List<Profile> mappingProfiles)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<GarageRepository>().As<IGarageRepository>();
            builder.RegisterType<PresentationRepository>().As<IPresentationRepository>();
            builder.RegisterType<CartRepository>().As<ICartRepository>();

            mappingProfiles.Add(new GarageMappingProfile());
            mappingProfiles.Add(new UserMappingProfile());
            mappingProfiles.Add(new CartMappingProfile());
        }
    }
}
