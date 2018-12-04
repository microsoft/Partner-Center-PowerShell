// -----------------------------------------------------------------------
// <copyright file="ResourceCollectionConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.JsonConverters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Serialize and Deserialize ResourceCollection to correct ResourceCollection instance.
    /// </summary>
    /// <typeparam name="T">The type of the resource.</typeparam>
    internal class ResourceCollectionConverter<T> : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this instance can write.
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            if (!typeof(ResourceCollection<T>).IsAssignableFrom(objectType))
            {
                return typeof(SeekBasedResourceCollection<T>).IsAssignableFrom(objectType);
            }
            return true;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <exception cref="ArgumentNullException">
        /// reader
        /// or
        /// objectType
        /// </exception>
        /// <exception cref="JsonSerializationException">
        /// </exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jobject;
            object obj;

            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (objectType == null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }

            if (!CanConvert(objectType))
            {
                throw new JsonSerializationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "ResourceCollectionConverter cannot deserialize '{0}' values",
                        objectType.Name));
            }

            jobject = JObject.Load(reader);

            obj = (objectType != typeof(SeekBasedResourceCollection<T>)) ?
                new ResourceCollection<T>(new List<T>()) :
                new SeekBasedResourceCollection<T>(
                    new List<T>(),
                    (jobject["continuationToken"] ?? JToken.Parse(string.Empty)).ToString());

            serializer.Populate(jobject.CreateReader(), obj);

            return obj;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}