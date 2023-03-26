using Autofac;
using ValmiStore.Model.Repositories.Abstract;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Test.Repositories;

namespace Webmall.Model.Test
{
    public static class ServicesConnector
    {
        public static void RegisterRepositories (ContainerBuilder builder)
        {
            builder.RegisterType<CartRepository>().As<ICartRepository>();
            builder.RegisterType<CatalogRepository>().As<ICatalogRepository>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            builder.RegisterType<CmsReposistory>().As<ICmsRepository>();
            builder.RegisterType<ConfigRepository>().As<IConfigRepository>();
            builder.RegisterType<DemandReqestRepository>().As<IDemandRequestRepository>();
            builder.RegisterType<FinanceRepository>().As<IFinanceRepository>();
            builder.RegisterType<ImageRepository>().As<IImageRepository>();
            builder.RegisterType<MarketingActionsRepository>().As<IMarketingActionsRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<PresentationRepository>().As<IPresentationRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            builder.RegisterType<ReferenceRepository>().As<IReferenceRepository>();
            builder.RegisterType<ReportsRepository>().As<IReportsRepository>();
            builder.RegisterType<SuppliersRepository>().As<ISuppliersRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<VinRequestRepository>().As<IVinRequestRepository>();
            builder.RegisterType<GarageRepository>().As<IGarageRepository>();
            builder.RegisterType<AutoDataRepository>().As<IAutoDataRepository>();
        }
    }
}
