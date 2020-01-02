using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace King.Utilities
{
    public class Vector3IntConverter : JsonConverter<Vector3Int>
    {
        public override Vector3Int ReadJson(JsonReader reader, Type objectType, Vector3Int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            // chop off the parens
            s = s.Substring(1, s.Length - 1);
            string[] vs = s.Split(',');

            if(vs.Length != 3)
            {
                throw new FormatException("JSON Object value not in (x, y, z) format");
            }

            return new Vector3Int(int.Parse(vs[0]),
                                  int.Parse(vs[1]),
                                  int.Parse(vs[2]));
        }

        public override void WriteJson(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
        {
            writer.WriteValue("Yay!" + value.ToString());
        }
    }
}
