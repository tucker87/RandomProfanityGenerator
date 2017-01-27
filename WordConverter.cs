using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RandomProfanityGenerator
{
    public class WordConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            var jObject = JObject.Load(reader);

            var type = jObject["type"].Value<string>().ToEnum<WordType>();

            // Create target object based on JObject
            var target = WordFactory.Create(type);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Word).IsAssignableFrom(objectType);
        }
    }
}