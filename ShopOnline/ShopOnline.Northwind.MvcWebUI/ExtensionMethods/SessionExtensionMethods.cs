using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ShopOnline.Northwind.MvcWebUI.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string objectString = session.GetString(key);

            if (string.IsNullOrWhiteSpace(objectString))
                return default;

            T value = JsonConvert.DeserializeObject<T>(objectString);

            return value;
        }
    }
}
