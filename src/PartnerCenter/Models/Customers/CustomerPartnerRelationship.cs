// -----------------------------------------------------------------------
// <copyright file="CustomerPartnerRelationship.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Customers
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Enumerates partner and customer relationships.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum CustomerPartnerRelationship
    {
        /// <summary>
        /// Unknown. Used for initialization.
        /// </summary>
        Unknown,

        /// <summary>
        /// A reseller relationship.
        /// </summary>
        Reseller,

        /// <summary>
        /// An advisor relationship.
        /// </summary>
        Advisor,

        /// <summary>
        /// Indicates that the partner is a syndication partner of the customer.
        /// </summary>
        Syndication,

        /// <summary>
        /// Indicates that the partner is a Microsoft Support agent for the customer.
        /// </summary>
        MicrosoftSupport,

        /// <summary>
        /// None. Used to remove reseller relationship between the customer and partner.
        /// </summary>
        None,
    }
}