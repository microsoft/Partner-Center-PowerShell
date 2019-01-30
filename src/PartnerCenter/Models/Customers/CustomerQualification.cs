// -----------------------------------------------------------------------
// <copyright file="CustomerQualification.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Customers
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Customer Qualification
    /// When a partner creates a new customer by default the customer is assigned "CustomerQualification.None". If the partner validates that the customer
    /// belongs to Education segment they can set the qualification of the Customer to "CustomerQualification.Education". This operation is irreversible and
    /// the partner will not be allowed to override the customer qualification once set.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum CustomerQualification
    {
        /// <summary>
        /// No qualification
        /// </summary>
        None,

        /// <summary>
        /// Education qualification
        /// </summary>
        Education,

        /// <summary>
        /// Non-Profit / Charity qualification
        /// </summary>
        Nonprofit,

        /// <summary>
        /// Government Community Cloud (GCC)
        /// </summary>
        GovernmentCommunityCloud
    }
}