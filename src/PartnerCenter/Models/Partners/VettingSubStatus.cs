// -----------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Partners
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Vetting sub status
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum VettingSubStatus
    {
        /// <summary>
        /// None vetting sub status
        /// </summary>
        None,
        
        /// <summary>
        /// The entry step
        /// </summary>
        Entry,
        
        /// <summary>
        /// Email ownership check for business accounts
        /// </summary>
        EmailOwnership,
        
        /// <summary>
        /// Email domain for business accounts
        /// </summary>
        EmailDomain,
        
        /// <summary>
        /// Employment verification sub status
        /// </summary>
        EmploymentVerification,
        
        /// <summary>
        /// Decision making process
        /// </summary>
        Decision,
        
        /// <summary>
        /// Other vetting sub status
        /// </summary>
        Other,
        
        /// <summary>
        /// Business verification sub status
        /// </summary>
        BusinessVerification
    }
}
