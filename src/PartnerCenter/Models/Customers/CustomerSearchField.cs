// -----------------------------------------------------------------------
// <copyright file="CustomerSearchField.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Customers
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the supported customer search fields.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum CustomerSearchField
    {
        /// <summary>
        /// Customer company name.
        /// </summary>
        CompanyName,
        
        /// <summary>
        /// Customer domain name.
        /// </summary>
        Domain,
        
        /// <summary>
        /// The indirect reseller
        /// </summary>
        IndirectReseller,

        /// <summary>
        /// The indirect CSP
        /// </summary>
        IndirectCloudSolutionProvider
    }
}