using System;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Webmall.Model.CoreHelpers;

namespace Webmall.Model.ERP_1C.Connect1C
{
    public class ResponseFrom1C<T>
    {
        #region Logger

        /// <summary>
        /// Логер сервиса
        /// </summary>
        public static ILog Log { get; } = LogManager.GetLogger("ResponseFrom1C");

        /// <summary>
        /// инициализация логера
        /// </summary>
        public static void InitializeLogger()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        static ResponseFrom1C()
        {
            InitializeLogger();
        }

        public static ResponseFrom1C<T> Get(string response, string soapMethodName, out int errorCode, bool debug = true)
        {
            if (debug)
                Log.Debug($"Response from {soapMethodName}: {response}");
            ResponseFrom1C<T> result;
            try
            {
                result = JsonConvert.DeserializeObject<ResponseFrom1C<T>>(response);
            }
            catch (JsonReaderException e)
            {
                throw new ArgumentException($@"Invalid response from {soapMethodName}. Unable deserialize to response object: {e.Message}", nameof(response), e);
            }

            errorCode = result.ResultCode;
            if (result.ResultCode != 0)
            {
                Log.Debug($"{soapMethodName} failed with code {result.ResultCode}; Details: {result.ErrorDetails}", new Exception(result.ErrorDetails));
            }

            if (!debug)
                Log.Debug($"Response from {soapMethodName}: Code: {result.ResultCode}");
            return result;
        }

        public static ResponseFrom1C<T> Get(string response, string soapMethodName, bool debug = true)
        {
            if (debug)
                Log.Debug($"Response from {soapMethodName}: {response}");
            ResponseFrom1C<T> result;
            try
            {
                var jss = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateParseHandling = DateParseHandling.DateTimeOffset
                };
                result = JsonConvert.DeserializeObject<ResponseFrom1C<T>>(response, jss);
            }
            catch (JsonReaderException e)
            {
                throw new ArgumentException($@"Invalid response from {soapMethodName}. Unable deserialize to response object: {e.Message}", nameof(response), e);
            }

            if (result.ResultCode != 0)
            {
                throw new RepositoryResultException ($"{soapMethodName} failed with code {result.ResultCode}; Details: {result.ErrorDetails}", new Exception (result.ErrorDetails))
                {
                    ResultCode = result.ResultCode,
                    ErrorDetails = result.ErrorDetails,
                    MethodName = soapMethodName,
                };
            }

            if (!debug)
                Log.Debug($"Response from {soapMethodName}: Code: {result.ResultCode}");
            return result;
        }

        public static implicit operator T(ResponseFrom1C<T> response)
        {
            return response.ResultJSON;
        }

        /// <summary>
        /// Result serialized in JSON format
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public T ResultJSON { get; set; }
        
        /// <summary>
        /// Execution result code (0 - ok, 1 - error1, 2 - error2 etc)
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// Execution error details message (something like 'Unknown position Id'); contains technical details
        /// </summary>
        public string ErrorDetails { get; set; }
    }
}
