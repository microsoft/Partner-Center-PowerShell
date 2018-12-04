// -----------------------------------------------------------------------
// <copyright file="EnumJsonConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.JsonConverters
{
    using System;
    using System.Globalization;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Formats the Enum values to the format that is utilized by Partner Center.
    /// </summary>
    public class EnumJsonConverter : JsonConverter
    {
        /// <summary>
        ///  Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false.</c></returns>
        public override bool CanConvert(Type objectType)
        {
            if (objectType != null)
            {
                return objectType.IsEnum;
            }

            return false;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The reader object to be read.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object that represents the serialized JSON.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return Enum.Parse(objectType, JScriptToPascalCase(reader.Value.ToString()));
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                return Enum.ToObject(objectType, reader.Value);
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The object to be used when writing.</param>
        /// <param name="value">The object to be written to JSON.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        private static string JScriptToPascalCase(string jsonValue)
        {
            if (jsonValue == null)
            {
                throw new ArgumentNullException(nameof(jsonValue));

            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(char.ToUpper(jsonValue[0], CultureInfo.InvariantCulture));

            for (int index = 1; index < jsonValue.Length; ++index)
            {
                stringBuilder.Append(jsonValue[index] == '_' ? char.ToUpper(jsonValue[++index], CultureInfo.InvariantCulture) : jsonValue[index]);
            }

            return stringBuilder.ToString();
        }
    }
}