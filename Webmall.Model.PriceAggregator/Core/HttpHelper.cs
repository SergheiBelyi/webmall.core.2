using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using log4net;
using log4net.Config;
using Webmall.Model.PriceAggregator.Repositories;

namespace Webmall.Model.PriceAggregator.Core
{
    public static class HttpHelper
    {

        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(HttpHelper));

        static HttpHelper()
        {
            XmlConfigurator.Configure();
        }
        #endregion

        public static HttpClient InitPriceAggregatorClient ()
        {
            var handler = new HttpClientHandler
            {
                UseDefaultCredentials = true,
                SslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(ConfigHelper.PriceAggregatorUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static string AddUrlParams (this string url, string [,] paramList)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            for (int i = 0; i <paramList.GetLength(0); i++)
            {
                query.Add(paramList[i,0], paramList[i,1]);
            }
            return url+"?"+query;
        }


        public static TResult GetRequest<TResult>(this HttpClient httpClient, string prefixUrl, List<KeyValuePair<string, string>> param)
        {
            if (param == null)
                return GetRequest<TResult>(httpClient, prefixUrl);

            var arr = new string[param.Count,2];
            for (var i = 0; i < param.Count; i++)
            {
                arr[i, 0] = param[i].Key;
                arr[i, 1] = param[i].Value;
            }

            return GetRequest<TResult>(httpClient, prefixUrl, arr);
        }

        public static TResult GetRequest<TResult>(this HttpClient httpClient, string prefixUrl, string[,] param = null)
        {
            var path = $"{ConfigHelper.PriceAggregatorUrl}{prefixUrl}";
            if(param !=null) path = path.AddUrlParams(param);
            Log.Debug($"Request:{path} started\n");
            HttpResponseMessage response = httpClient.GetAsync(path).Result;

            //Log.Debug($"Request:{path}\nStatusCode {response.StatusCode}\nContent: {System.Text.RegularExpressions.Regex.Unescape(response.Content?.ReadAsStringAsync().Result ?? "[null]").Replace(",", ",\n")}");
            Log.Debug($"Request:{path}\nStatusCode {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var httpResult = response.Content.ReadFromJsonAsync<TResult>().Result;
                return httpResult;
            }
            throw new Exception("Response error: " + response.StatusCode);
        }

        public static byte[] GetRequestByte(string prefixUrl)
        {
            var path = $"{ConfigHelper.PriceAggregatorUrl}{prefixUrl}";
            byte[] buffer = new byte[0];

            var client = InitPriceAggregatorClient();

            HttpResponseMessage response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                buffer = response.Content.ReadAsByteArrayAsync().Result;
            }

            return buffer;
        }
    }
}
