using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.Helpers.Json
{
    public class JsonHelper<T>
    {
        /// <summary>
        /// Serialize the object passed as parameter to a custom format Json string.
        /// <summary>
        public string IndentedJsonSerializer(T serializableObject)
        {

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };
            settings.Converters.Add(new IndentJsonConverter());

            var json = JsonConvert.SerializeObject(serializableObject, settings);

            string jsonFormatted = JValue.Parse(json).ToString(Formatting.Indented);

            return json;
        }
    }
}
