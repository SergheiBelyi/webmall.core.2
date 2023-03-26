using Newtonsoft.Json;

namespace Webmall.Model.CoreHelpers
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj, JsonSerializerSettings settings = null)
        {
            return settings == null
                ? JsonConvert.SerializeObject(obj)
                : JsonConvert.SerializeObject(obj, settings);
        }
    }
}