using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Webmall.Model.PriceAggregator.Mappings;
using Webmall.Model.PriceAggregator.Repositories;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.PriceAggregator
{
    public static class ServicesConnector
    {
        public static void RegisterRepositories (ContainerBuilder builder, List<Profile> mappingProfiles)
        {
            builder.RegisterType<CatalogRepository>().As<ICatalogRepository>();
            builder.RegisterType<AutoDataRepository>().As<IAutoDataRepository>();

            mappingProfiles.Add(new CatalogMappingProfile());
            mappingProfiles.Add(new AutoDataMappingProfile());
        }
    }
}
