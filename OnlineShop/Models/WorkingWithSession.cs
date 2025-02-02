using Newtonsoft.Json;

namespace OnlineShop.Models
{
    public static class WorkingWithSession
    {
        public static void SetObjectasJson(this ISession session, string Key, object value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }

        public static T SetObjectasJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
