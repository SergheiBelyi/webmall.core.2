using System;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IImageRepository : IDisposable
    {
        /// <summary>
        /// Получение изображения товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <returns>Изображение товара</returns>
        byte[] GetWareImage(string culture, string wareId);

        /// <summary>
        /// Получение картинки по ее идентификатору
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="imageId">Код изображения</param>
        /// <returns>Изображение товара</returns>
        byte[] GetImage(string culture, string imageId);
    }
}
