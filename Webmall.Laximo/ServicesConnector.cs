using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Webmall.Laximo.Entities;
using Webmall.Laximo.Repositories;
using Webmall.Laximo.Repositories.Real;

namespace Webmall.Laximo
{
    public static class ServicesConnector
    {
        public static void RegisterRepositories (ContainerBuilder builder, List<Profile> mappingProfiles, bool fake)
        {
            if (fake)
                builder.RegisterType<Repositories.Fake.LaximoRepository>().As<ILaximoRepository>();
            else
                builder.RegisterType<LaximoRepository>().As<ILaximoRepository>();

            mappingProfiles.Add(new LaximoAutoMapperProfile());
        }
    }
}
