using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace King.Utilities
{
    public class DictVec3IntStringConverter : JsonConverter<Dictionary<Vector3Int, string>>
    {
        // just avoiding magic numbers
        const int PARENSTARTCHAR = 1;
        const int PARENENDCHAR = 2;

        const int X_VALUE = 0;
        const int Y_VALUE = 1;
        const int Z_VALUE = 2;

        const int VECTOR_LENGTH = 3;

        public Vector3Int StringToVector3Int(string value)
        {
            // chop off the parens
            string s = value.Substring(PARENSTARTCHAR, value.Length - PARENENDCHAR);
            string[] vs = s.Split(',');

            if(vs.Length != VECTOR_LENGTH)
            {
                throw new FormatException("JSON Object value not in (x, y, z) format");
            }

            return new Vector3Int(int.Parse(vs[X_VALUE]),
                                  int.Parse(vs[Y_VALUE]),
                                  int.Parse(vs[Z_VALUE]));
        }

        public override Dictionary<Vector3Int, string> ReadJson(JsonReader reader, Type objectType, Dictionary<Vector3Int, string> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Dictionary<Vector3Int, string> data = new Dictionary<Vector3Int, string>();

            string s = (string)reader.Value;
            // read the field name 
            reader.Read();

            // make sure there's a value
            // this checks the key in the dict
            while(reader.TokenType != JsonToken.EndObject)
            {
                Vector3Int key = StringToVector3Int(reader.Value.ToString());
                reader.Read();
                string value = reader.Value.ToString();
                reader.Read();

                data.Add(key, value);
            }

            // do i need to read the end object token?
            return data;
        }

        public override void WriteJson(JsonWriter writer, Dictionary<Vector3Int, string> value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
