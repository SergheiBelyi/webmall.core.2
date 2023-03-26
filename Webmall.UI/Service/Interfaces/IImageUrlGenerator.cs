using System.Web.Mvc;

namespace Webmall.UI.Service.Interfaces
{
    public interface IImageUrlGenerator
    {
        string ProducerImage(UrlHelper urlHelper, string producerName);

        string MarkaImage(UrlHelper urlHelper, string markaName);

        string ModelImage(UrlHelper urlHelper, string markaName, string modelName);

        //string WareImage(string wareId, string wareNumber, string producerName);

        string WareImage(UrlHelper urlHelper, string imageId);

        //string[] WareImages(string wareId, string wareNumber, string producerName);
    }
}