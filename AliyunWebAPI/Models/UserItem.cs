using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AliyunWebAPI.Models
{
    public class UserItem
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId _id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
    class ObjectIdConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw  new Exception($"Unexpected token parsing ObjectId. Expected String.get{reader.TokenType}");
            }
            var value = (string) reader.Value;
            return string.IsNullOrEmpty(value) ? ObjectId.Empty : ObjectId.Parse(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
        }


    }
}
