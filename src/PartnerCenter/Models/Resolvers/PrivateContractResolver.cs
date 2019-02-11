// -----------------------------------------------------------------------
// <copyright file="PrivateContractResolver.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Resolvers
{
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Used by <see cref="JsonSerializer" /> to resolve a <see cref="JsonContract" /> for a given type.
    /// </summary>
    public class PrivateContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Creates a <see cref="JsonProperty" /> for the given <see cref="MemberInfo" />.
        /// </summary>
        /// <param name="member">The member for which the <see cref="JsonProperty" /> is created.</param>
        /// <param name="memberSerialization">The member's parent <see cref="MemberSerialization" />.</param>
        /// <returns> A created <see cref="JsonProperty" /> for the given <see cref="MemberInfo" />.</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (!property.Writable)
            {
                property.Writable = ((PropertyInfo)member).GetSetMethod(true) != null;
            }

            return property;
        }
    }
}