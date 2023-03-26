using System;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;
using Laximo.Guayaquil.Data.Entities;
using Laximo.Guayaquil.Data.Interfaces;
using System.Security.Cryptography;

namespace Laximo.Guayaquil.Data.net.laximo.ws
{
    public partial class Catalog : ILaximoProxy
    {
    }
}

namespace Laximo.Guayaquil.Data.net.laximo.ws.aftermarket
{
    public partial class Aftermarket : ILaximoProxy
    {
    }
}

namespace Laximo.Guayaquil.Data
{
    public abstract class LaximoWSProviderBase : IDisposable
    {
        private const string ResponseStartTag = "<response>";
        private const string ResponseEndTag = "</response>"; 
        
        private readonly string _locale = "en_GB";
        private ILaximoProxy _proxy;
        private readonly ICatalogCache _cache;
        private readonly string _login = "empty";
        private readonly string _password = "empty";

        private enum authModeEnum
        {
            CERTIFICATE,
            LOGIN
        };
        private readonly authModeEnum _authMode;
        protected LaximoWSProviderBase(string certPath, string certPwd, string authMode, string login, string password,
            ICatalogCache cache)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            if (authMode.Equals("Login"))
            {
                _authMode = authModeEnum.LOGIN;
                _login = login;
                _password = password;
            }
            else if (authMode.Equals("Certificate"))
            {
                throw new ArgumentException(string.Format("Unsupported authMode: '{0}'", authMode));

                // Proxy.ClientCertificates.Add(new X509Certificate2(certPath, certPwd));
                // _authMode = authModeEnum.CERTIFICATE;
            }
            else
            {
                throw new ArgumentException("Unknown authMode " + authMode);
            }

            Proxy.ToString();
            _cache = cache;
        }

        protected LaximoWSProviderBase(string certPath, string certPwd, string authMode, string login, string password,
            ICatalogCache cache, string locale)
            : this(certPath, certPwd, authMode,login, password,cache)
        {
            _locale = locale;
        }

        private ILaximoProxy Proxy
        {
            get { return _proxy ?? (_proxy = CreateProxy()); }
        }

        protected abstract ILaximoProxy CreateProxy();

        public string Locale
        {
            get
            {
                return _locale;
            }
        }

        protected static string GetQuery(string command, params object[] p)
        {
            string parameters;
            switch (command)
            {
//                case CommandNames.ListCatalogs:
//                    parameters = String.Format("Locale={0}|ssd={1}", p);
//                    break;
//                case CommandNames.GetCatalogInfo:
//                    parameters = String.Format("Locale={0}|Catalog={1}|ssd={2}", p);
//                    break;
//                case CommandNames.FindVehicleByVIN:
//                    parameters = String.Format("Locale={0}|Catalog={1}|VIN={2}|ssd={3}", p);
//                    break;
//                case CommandNames.FindVehicleByFrame:
//                    parameters = String.Format("Locale={0}|Catalog={1}|Frame={2}|FrameNo={3}|ssd={4}", p);
//                    break;
//                case CommandNames.FindVehicleByWizard2:
//                    parameters = String.Format("Locale={0}|Catalog={1}|ssd={2}", p);
//                    break;
//                case CommandNames.GetVehicleInfo:
//                case CommandNames.ListQuickGroup:
//                    parameters = String.Format("Locale={0}|Catalog={1}|VehicleId={2}|ssd={3}", p);
//                    break;
//                case CommandNames.ListCategories:
//                case CommandNames.ListUnits:
//                    parameters = String.Format("Locale={0}|Catalog={1}|VehicleId={2}|CategoryId={3}|ssd={4}", p);
//                    break;
//                case CommandNames.GetUnitInfo:
//                case CommandNames.ListImageMapByUnit:
//                case CommandNames.ListDetailByUnit:
//                    parameters = String.Format("Locale={0}|Catalog={1}|UnitId={2}|ssd={3}", p);
//                    break;
//                case CommandNames.GetWizard2:
//                    parameters = String.Format("Locale={0}|Catalog={1}|ssd={2}", p);
//                    break;
//                case CommandNames.GetFilterByUnit:
//                    parameters = String.Format("Locale={0}|Catalog={1}|Filter={2}|VehicleId={3}|UnitId={4}|ssd={5}", p);
//                    break;
//                case CommandNames.GetFilterByDetail:
//                    parameters =
//                        String.Format(
//                            "Locale={0}|Catalog={1}|Filter={2}|VehicleId={3}|UnitId={4}}DetailId={5}|ssd={6}", p);
//                    break;
//                case CommandNames.ListQuickDetail:
//                    parameters = String.Format("Locale={0}|Catalog={1}|VehicleId={2}|QuickGroupId={3}|ssd={4}", p);
//                    if (p.Length > 5 && Convert.ToBoolean(p[5]))
//                    {
//                        parameters += "|All=1";
//                    }
//                    break;
                //Aftermarket
                case CommandNames.FindOEM:
                    parameters = String.Format("Locale={0}|OEM={1}|Options={2}", p);
                    break;
                case CommandNames.FindDetail:
                    parameters = String.Format("Locale={0}|DetailId={1}|Options={2}", p);
                    break;
                case CommandNames.GetManufacturerInfo:
                    parameters = String.Format("Locale={0}|ManufacturerId={1}", p);
                    break;
                case CommandNames.FindReplacements:
                    parameters = String.Format("Locale={0}|DetailId={1}", p);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(command);
            }
            return String.Format("{0}:{1}", command, parameters);
        }

        protected T GetData<T>(string query) where T : IEntity
        {
            //return GetEntityPart<T>(query);
            return _cache != null ? GetCachedData<T>(query) : GetEntityPart<T>(query);
        }

        protected response GetData(string query) 
        {
            //return GetEntityFull<response>(query);
            return _cache != null ? GetCachedDataFull<response>(query) : GetEntityFull<response>(query);
        }

        protected response GetData(Command query) 
        {
            //return GetEntityFull<response>(query.ToString());
            return _cache != null ? GetCachedDataFull<response>(query.ToString()) : GetEntityFull<response>(query.ToString());
        }

        private T GetCachedData<T>(string query) where T : IEntity
        {
            if (_cache.Exists(query))
            {
                return (T)_cache.GetCachedData(query);
            }

            T entity = GetEntityPart<T>(query);
            _cache.PutCachedData(query, entity);
            return entity;
        }

        private T GetCachedDataFull<T>(string query) where T : IEntity
        {
            if (_cache.Exists(query))
            {
                return (T)_cache.GetCachedData(query);
            }

            T entity = GetEntityFull<T>(query);
            _cache.PutCachedData(query, entity);
            return entity;
        }
        private T GetEntityFull<T>(string query) where T : IEntity
        {
            string data = callProxy(query);

            T entity = DeserializeFull<T>(data);
            return entity;
        }

        private string callProxy(string query)
        {
            switch (_authMode)
            {
                case (authModeEnum.CERTIFICATE):
                    return _proxy.QueryData(query);
                case (authModeEnum.LOGIN):
                    string hmac = calculateHMAC(query);
                    return _proxy.QueryDataLogin(query, _login, hmac);
                default:
                    throw new Exception("UNKNOWN authMode while query data");
            }            
        }

        private string calculateHMAC(string request)
        {
            try
            {
                String requestPlus = String.Format("{0}{1}", request, _password );
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(requestPlus));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("x2"));
                }
                
                return sb.ToString();
            }
            catch (Exception exc)
            {
                throw new Exception("Problem on HMAC calculating",exc);
            }
        }

        private T GetEntityPart<T>(string query) where T : IEntity
        {
            string data = callProxy(query);
            T entity = DeserializePart<T>(data);
            return entity;
        }

        private static T DeserializePart<T>(string data) where T : IEntity
        {
            StringBuilder sb = new StringBuilder(data);
            if (data.StartsWith(ResponseStartTag))
            {
                sb.Remove(0, ResponseStartTag.Length);
            }
            if (data.EndsWith(ResponseEndTag))
            {
                sb.Remove(sb.Length - ResponseEndTag.Length, ResponseEndTag.Length);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(sb.ToString());
            return (T)serializer.Deserialize(stringReader);
        }


        private static T DeserializeFull<T>(string data) where T : IEntity
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(data);
            return (T)serializer.Deserialize(stringReader);
        }

        protected string GetLocale(string locale)
        {
            return String.IsNullOrEmpty(locale) ? Locale : locale;
        }

        public void Dispose()
        {
            if (_proxy != null)
            {
                _proxy.Dispose();
                _proxy = null;
            }
        }
    }
}