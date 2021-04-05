using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static Bank_Transaction_Calculator.StatusClasses;

namespace Bank_Transaction_Calculator
{
    public class FeesConverter : JsonConverter
    {
        // This is used when you're converting the C# List back to a JSON format
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (var fee in (List<Fee>)value)
            {
                writer.WriteRawValue(JsonConvert.SerializeObject(fee));
            }
            writer.WriteEndArray();
        }

        // This is when you're reading the JSON object and converting it to C#
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var response = new List<Fee>();
            // Loading the JSON object
            JObject fees = JObject.Load(reader);
            // Looping through all the properties. C# treats it as key value pair
            foreach (var fee in fees)
            {
                // Finally I'm deserializing the value into an actual Player object
                var p = JsonConvert.DeserializeObject<Fee>(fee.Value.ToString());
                // Also using the key as the player Id
                //p.Id = player.Key;
                //response.Add(p);
            }

            return response;
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(List<Fee>);
    }
}

