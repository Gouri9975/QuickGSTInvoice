using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace e2.CDM.Shared
{
    public class ValidateJson<T> where T : class
    {
        public static bool Validate(string json,  bool allowAdditionalProperties=false)
        {
            bool isValid = false;

            //JSchemaGenerator generator = new JSchemaGenerator();

            JsonSchemaGenerator schemaGenerator = new JsonSchemaGenerator();
            var schema = schemaGenerator.Generate(typeof(T));
            schema.AllowAdditionalProperties = allowAdditionalProperties;

             isValid = JObject.Parse(json).IsValid(schema);

            return isValid;
        }

        public static bool Validate(string json, bool allowAdditionalProperties ,out IList<string> errors)
        {
            bool isValid = false;
            JsonSchemaGenerator schemaGenerator = new JsonSchemaGenerator();
            var schema = schemaGenerator.Generate(typeof(T));
            schema.AllowAdditionalProperties = allowAdditionalProperties;

            isValid = JObject.Parse(json).IsValid(schema, out errors);

            return isValid;
        }


    }
}
