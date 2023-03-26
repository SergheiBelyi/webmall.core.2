using AutoMapper;
using System.Collections.Generic;
using Webmall.UI.Mappings;

namespace Webmall.UI
{

    public static class MappingConfig
    {
        public static List<Profile> Profiles = new List<Profile>();

        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<OrderRepositoryProfile>();
            cfg.AddProfile<CatalogProfile>();
            cfg.AddProfiles(Profiles);
        }
    }
}