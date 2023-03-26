using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Caching;
using log4net;
using log4net.Config;
using System.Threading;

namespace Webmall.Model
{
    public static class Extensions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Extensions));
        private static readonly object Lock = new object();
        private static bool _clearing;

        static Extensions()
        {
            XmlConfigurator.Configure();
        }

        public static IEnumerable<T> CloneCollection<T>(this IEnumerable<T> source)
        {
            var result = new List<T>();
            var enm = source.GetEnumerator();
            while (enm.MoveNext())
                result.Add(enm.Current.Clone());
            return result.AsEnumerable();
        }

        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T Get<T>(this Cache cache, string key, object @lock, Func<T> selector)
        {
            return cache.Get(key, @lock, selector, CacheItemPriority.Normal);
        }

        public static T Get<T>(this Cache cache, string key, object @lock, Func<T> selector, CacheItemPriority priority)
        {
            object value = null;
            try
            {
                lock (@lock)
                {
                    while (_clearing)
                        Thread.Sleep(50);
                    if ((value = cache.Get(key)) == null)
                    {
                        value = selector();
                        if (value != null)
                            cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, CacheExpirationTime(), priority, null);
                    }
                }
                return (T)value;
            }
            catch (Exception e)
            {
                Log.Error($"Cache processing error: key {key}, selector: {selector.Method.Name}", e);
                return (T)value;
            }
        }

        public static T Get<T>(this Cache cache, string key, object @lock, Func<T> selector, CacheItemPriority priority, DateTime? absExp, int? expTime = null)
        {
            object value = null;
            try
            {
                lock (@lock)
                {
                    while (_clearing)
                        Thread.Sleep(50);
                    if ((value = cache.Get(key)) == null)
                    {
                        value = selector();
                        cache.Insert(key, value, null,
                            absExp ?? Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 0, expTime ?? 0),
                            priority, null);
                    }
                }
                return (T)value;
            }
            catch (Exception e)
            {
                Log.Error("Cache processing error", e);
                return (T)value;
            }
        }


        static TimeSpan CacheExpirationTime()
        {
            return new TimeSpan(0, ConfigHelper.CacheExpirationTime, 0, 0);
        }

        /// <summary>
        /// Ограничивает длину строки
        /// </summary>
        /// <param name="str">Строка</param>
        /// <param name="maxLength">Максимальная длина</param>
        /// <returns></returns>
        public static string Cut(this string str, int maxLength)
        {
            return (str.Length > maxLength) ? str.Substring(0, maxLength) : str;
        }

        public static void ClearCacheKeys(List<string> keys, Cache cache)
        {
            lock (Lock)
            {
                _clearing = true;
                foreach (var key in keys.OrderBy(i => i))
                {
                    Log.Debug($"Clearing {key}");
                    cache.Remove(key);
                }
                _clearing = false;
            }
        }



    }
}
