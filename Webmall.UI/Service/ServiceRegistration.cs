using Autofac;
using Webmall.UI.Service.Implementations;
using Webmall.UI.Service.Interfaces;

namespace Webmall.UI.Service
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<UserRegistration>().As<IUserRegistration>();
            builder.RegisterType<LocalFilesImageUrlGenerator>().As<IImageUrlGenerator>();
        }
    }
}