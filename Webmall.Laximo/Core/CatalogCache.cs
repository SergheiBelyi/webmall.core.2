using System;
using System.Web;
using System.Web.Caching;
using Laximo.Guayaquil.Data.Interfaces;

namespace Webmall.Laximo.Core
{
    public class CatalogCache : ICatalogCache
    {
        private const int Timeout = 60;
        /// <summary>  
        /// Adds the specified cache object. it will last for max 1hr from last access  
        /// </summary>  
        public void PutCachedData(string request, IEntity entity)
        {
            HttpContext.Current.Cache.Insert(request, entity, null, Cache.NoAbsoluteExpiration,
                                 TimeSpan.FromMinutes(Timeout));
        }

        /// <summary>  
        /// Check if object with the specified request exists.  
        /// </summary>  
        public bool Exists(string request)
        {
            return HttpContext.Current.Cache[request] != null;
        }

        /// <summary>  
        /// Gets the object with the specified request.  
        /// </summary>  
        public IEntity GetCachedData(string request)
        {
            return HttpContext.Current.Cache[request] as IEntity;
        }

        /// <summary>  
        /// Removes object with the specified request.  
        /// </summary>  
        public void Remove(string request)
        {
            HttpContext.Current.Cache.Remove(request);
        }
    }
}
