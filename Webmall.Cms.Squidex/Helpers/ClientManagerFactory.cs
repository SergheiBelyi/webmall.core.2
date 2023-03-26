using Squidex.ClientLibrary;
using Webmall.Model;
using log4net;
using log4net.Config;

namespace Webmall.Cms.Squidex.Helpers
{
    public static class ClientManagerFactory
    {
        private static ClientManager _clientManager;
        private static ClientManager _shopManager;
        private static SquidexClientManager[] ClientOption = new[] {  new SquidexClientManager(
            new SquidexOptions
            {
                AppName = ConfigHelper.SquidexAppName,
                ClientId = ConfigHelper.SquidexSchemaClientId,
                ClientSecret = ConfigHelper.SquidexSchemaClientSecret,
                Url = ConfigHelper.SquidexUrl
            }), new SquidexClientManager(
            new SquidexOptions
            {
                AppName = ConfigHelper.SquidexAppName,
                ClientId = ConfigHelper.SquidexAppClientId,
                ClientSecret = ConfigHelper.SquidexAppClientSecret,
                Url = ConfigHelper.SquidexUrl
            })
        };
        private static SquidexClientManager[] ShopOption = new[] {  new SquidexClientManager(
            new SquidexOptions
            {
                AppName = "shops",
                ClientId = "shops:default",
                ClientSecret = ConfigHelper.SquidexSchemaClientSecret,
                Url = ConfigHelper.SquidexUrl
            }), new SquidexClientManager(
            new SquidexOptions
            {
                AppName = "shops",
                ClientId = ConfigHelper.SquidexAppClientId,
                ClientSecret = ConfigHelper.SquidexAppClientSecret,
                Url = ConfigHelper.SquidexUrl
            })
        };

        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(ClientManagerFactory));

        static ClientManagerFactory()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        public static ClientManager Creator(ClientManagerType type)
        {
            switch (type)
            {
                case ClientManagerType.Client:
                    return _clientManager ?? (_clientManager = new ClientManager(ClientOption[0], ClientOption[1]));
                case ClientManagerType.Shop:
                    return _shopManager ?? (_shopManager = new ClientManager(ShopOption[0], ShopOption[1]));
            }

            Log.Error($"ClientManagerType error: {type}");
            return new ClientManager(new SquidexClientManager(new SquidexOptions()), new SquidexClientManager(new SquidexOptions()));
        }
    }

    public enum ClientManagerType {
        Client = 1,
        Shop = 2
    }
}
