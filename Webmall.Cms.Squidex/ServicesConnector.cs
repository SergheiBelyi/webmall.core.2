using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Webmall.Cms.Squidex.Cms;
using Webmall.Cms.Squidex.Config;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Cms.Squidex
{
    public static class ServicesConnector
    {
        public static void RegisterRepositories (ContainerBuilder builder, List<Profile> mappingProfiles)
        {
            builder.RegisterType<ConfigRepository>().As<IConfigRepository>();
            builder.RegisterType<CmsRepository>().As<ICmsRepository>();

            mappingProfiles.Add(new Config.MappingProfile());
            mappingProfiles.Add(new Cms.MappingProfile());
        }
    }
}
