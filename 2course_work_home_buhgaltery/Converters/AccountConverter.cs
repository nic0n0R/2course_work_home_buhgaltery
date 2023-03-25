using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2course_work_home_buhgaltery
{
    public class AccountConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IAccount);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            string typeName = item["$type"]?.ToString();

            if (typeName == null)
            {
                throw new ArgumentNullException("Type свойство не найден в Json.");
            }

            Type accountType = Type.GetType(typeName);
            return item.ToObject(accountType, serializer);

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject item = JObject.FromObject(value, serializer);
            item["$type"] = value.GetType().AssemblyQualifiedName;
            item.WriteTo(writer);
        }
    }
}
