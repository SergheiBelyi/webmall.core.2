using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using StackExchange.Profiling.DeepProfiling.Autofac;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core.Ware;
using Webmall.UI.Service;

namespace Webmall.UI
{
    public class AutofacConfig
    {

        //public delegate void DependencyInjectionInitExtender(ContainerBuilder builder);

        /// <summary>
        /// Инициация и настройка разрешения зависимостей
        /// </summary>
        public static void DependencyInjectionInit()
        {
            #region Autofac Instalation

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterControllers(typeof(Controllers.PaymentController).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            Model.Test.ServicesConnector.RegisterRepositories(builder);

            builder.RegisterType<WareHelper>().As<IWareHelper>();

            Cms.Squidex.ServicesConnector.RegisterRepositories(builder, MappingConfig.Profiles);
            Model.PriceAggregator.ServicesConnector.RegisterRepositories(builder, MappingConfig.Profiles);
            Model.ERP_1C.ServicesConnector.RegisterRepositories(builder);
            Model.Database.ServicesConnector.RegisterRepositories(builder, MappingConfig.Profiles);
            Laximo.ServicesConnector.RegisterRepositories(builder, MappingConfig.Profiles, false);

            builder.RegisterType<Cms.Squidex.Config.ConfigRepository>().As<IConfigRepository>();
            builder.RegisterModule(new MiniProfilerInterceptionModule());

            builder.RegisterServices();

            // AutoMapper configuration
            builder.Register(context =>
            {
                var config = new MapperConfiguration(MappingConfig.Configure);
                return new Mapper(config);
            }).As<IMapper>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            #endregion
        }


    }
}