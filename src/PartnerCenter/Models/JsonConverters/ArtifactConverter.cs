// -----------------------------------------------------------------------
// <copyright file="ArtifactConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.JsonConverters
{
    using System;
    using Entitlements;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Serialize and deserialize entitlement artifact to correct instance based on artifact type.
    /// </summary>
    public class ArtifactConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false.</c></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Artifact).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ArtifactConverter" /> can write JSON.
        /// </summary>
        public override bool CanWrite => false;

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
            JObject jobject = JObject.Load(reader);
            object obj = jobject["artifactType"].ToString().Equals("reservedinstance", StringComparison.InvariantCultureIgnoreCase) ? new ReservedInstanceArtifact() : new Artifact();
            serializer.Populate(jobject.CreateReader(), obj);
            return obj;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The object to be used when writing.</param>
        /// <param name="value">The object to be written to JSON.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
