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
        Undefined = 0,

        /// <summary>
        /// Customer Resource
        /// </summary>
        Customer = 1,

        /// <summary>
        /// Customer User
        /// </summary>
        CustomerUser = 2,

        /// <summary>
        /// Order Resource
        /// </summary>
        Order = 3,

        /// <summary>
        /// Subscription Resource
        /// </summary>
        Subscription = 4,

        /// <summary>
        /// License Resource
        /// </summary>
        License = 5,

        /// <summary>
        /// Third party add-on Resource
        /// </summary>
        ThirdPartyAddOn = 6,

        /// <summary>
        /// MPN association Resource
        /// </summary>
        MpnAssociation = 7,

        /// <summary>
        /// Transfer Resource
        /// </summary>
        Transfer = 8,

        /// <summary>
        /// Application Resource
        /// </summary>
        Application = 9,

        /// <summary>
        /// Application Credential Resource
        /// </summary>
        ApplicationCredential = 10,

        /// <summary>
        /// Partner User Resource
        /// </summary>
        PartnerUser = 11,

        /// <summary>
        /// Partner Relationship Resource
        /// </summary>
        PartnerRelationship = 12,

        /// <summary>
        /// Partner Referral Resource
        /// </summary>
        Referral = 13,

        /// <summary>
        /// Software Key Resource
        /// </summary>
        SoftwareKey = 14,

        /// <summary>
        /// Software Download Link Resource
        /// </summary>
        SoftwareDownloadLink = 15,

        /// <summary>
        /// Credit Limit Resource
        /// </summary>
        CreditLimit = 16
    }
}