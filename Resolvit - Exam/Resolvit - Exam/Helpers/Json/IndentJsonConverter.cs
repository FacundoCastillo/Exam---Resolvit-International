using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.Helpers.Json
{
    public class IndentJsonConverter : JsonConverter
    {
        /// <summary>
        /// Allows us to "customize" the json Converter.
        /// <summary>

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<int>) || objectType == typeof(string) || objectType == typeof(int);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(JsonConvert.SerializeObject(value, Formatting.None));
        }
    }
}
