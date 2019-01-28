// -----------------------------------------------------------------------
// <copyright file="ResourceType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Auditing
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Enumeration to represent type of resource being performed
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ResourceType
    {
        /// <summary>
        /// The undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// Customer Resource
        /// </summary>
        Customer,

        /// <summary>
        /// Customer User
        /// </summary>
        CustomerUser,

        /// <summary>
        /// Order Resource
        /// </summary>
        Order,

        /// <summary>
        /// Subscription Resource
        /// </summary>
        Subscription,

        /// <summary>
        /// License Resource
        /// </summary>
        License,

        /// <summary>
        /// Third party add-on Resource
        /// </summary>
        ThirdPartyAddOn,

        /// <summary>
        /// MPN association Resource
        /// </summary>
        MpnAssociation,

        /// <summary>
        /// Transfer Resource
        /// </summary>
        Transfer,

        /// <summary>
        /// Application Resource
        /// </summary>
        Application,

        /// <summary>
        /// Application Credential Resource
        /// </summary>
        ApplicationCredential,

        /// <summary>
        /// Partner User Resource
        /// </summary>
        PartnerUser,

        /// <summary>
        /// Partner Relationship Resource
        /// </summary>
        PartnerRelationship,
    }
}