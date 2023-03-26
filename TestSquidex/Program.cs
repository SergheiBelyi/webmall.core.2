using Squidex.ClientLibrary;
using Webmall.Cms.Squidex.Cms.Models.BrandArticles;
using Webmall.Cms.Squidex.Cms.Models.FooterColumns;
using Webmall.Cms.Squidex.Cms.Models.News;
using Webmall.Cms.Squidex.Config.Models.Email;

namespace TestSquidex
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientManager = new SquidexClientManager(
                   new SquidexOptions
                   {
                       AppName = "motex",
                       ClientId = "motex:default",
                       ClientSecret = "9a8ctydmloajnwtnd39k5xknhsgmyz3xcfi8xl2pm10x",
                       Url = "https://localhost:8005"
                   });


            var appManager = new SquidexClientManager(
                new SquidexOptions
                {
                    AppName = "motex",
                    ClientId = "60b100690a6177fe18ae9ba1",
                    ClientSecret = "lqsq5de3ggpng3v3o3ox5jtn6qoevzzeyh9adxv3fo0x",
                    Url = "https://localhost:8005"
                });

            //var footerquery = new ContentQuery();
            var footerClient = clientManager.CreateContentsClient<FooterPositionItem, FooterPositionData>("footer-positions");
            var footers = footerClient.GetAsync().Result;

            var query = new ContentQuery();
            var newsclient = clientManager.CreateContentsClient<NewsItem, NewsData>("news");
            var news = newsclient.GetAsync().Result;

            var brandClient = clientManager.CreateContentsClient<BrandArticlesItem, BrandArticleData>("brandarticles");
            var brands = brandClient.GetAsync().Result;

            var imageId = news.Items[0].Data.Image[0];
            var imageClient = clientManager.CreateAssetsClient();
            var image = imageClient.GetAssetAsync(clientManager.App, imageId).Result;
            var imageContent = imageClient.GetAssetContentBySlugAsync(clientManager.App, imageId, "").Result;

            var client = clientManager.CreateContentsClient<EmailConfig, EmailConfigData>("emailconfig");
            // Read posts pages

            //var r = new ConfigRepository(null);
            //var res = r.GetEmailConfig();

            var config1 = client.GetAsync().Result;
            var config = config1.Items[0].Data;

            var langClient = clientManager.CreateLanguagesClient();
            var langs = langClient.GetLanguagesAsync().Result;

            var apsClient = appManager.CreateAppsClient();
            var applangs = apsClient.GetLanguagesAsync(clientManager.App).Result;

        }
    }
}
