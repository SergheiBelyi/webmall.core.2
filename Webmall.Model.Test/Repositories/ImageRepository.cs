using System;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public byte[] GetImage(string culture, string imageId)
        {
            throw new NotImplementedException();
        }

        public byte[] GetWareImage(string culture, string wareId)
        {
            throw new NotImplementedException();
        }
    }
}
