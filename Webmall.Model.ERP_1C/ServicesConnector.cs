using System;
using System.Configuration;
using System.ServiceModel.Security;
using Autofac;
using AutoMapper;
using Webmall.Model.ERP_1C.ERP_1C_ServiceReference;
using Webmall.Model.ERP_1C.Repositories;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.ERP_1C
{
    public static class ServicesConnector
    {
        public static void RegisterRepositories(this ContainerBuilder builder, Action<IMapperConfigurationExpression> externalMapperConfig = null)
        {
            builder.RegisterType<ClientRepository>().As<IClientRepository>();   

            //builder.RegisterType<CartRepository>().As<ICartRepository>();
            //builder.RegisterType<CatalogRepository>().As<ICatalogRepository>();
            //builder.RegisterType<ImageRepository>().As<IImageRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            //builder.RegisterType<ReferenceRepository>().As<IReferenceRepository>();
            //builder.RegisterType<SuppliersRepository>().As<ISuppliersRepository>();
            //builder.RegisterType<ReportsRepository>().As<IReportsRepository>();
            //builder.RegisterType<MarketingActionsRepository>().As<Interfaces.IMarketingActionsRepository>();
            builder.Register(x =>
            {
                var client = new TW_SiteIntegrationPortTypeClient("ITW_SiteIntegrationSoap12");
                client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["Erp1CUser"];
                client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["Erp1CPassword"];
                var noCertValidationAuth = new X509ServiceCertificateAuthentication
                {
                    CertificateValidationMode = X509CertificateValidationMode.None
                };
                client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = noCertValidationAuth;
                return client;
            }).InstancePerRequest();
        }
    }
}