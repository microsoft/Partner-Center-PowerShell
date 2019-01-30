// -----------------------------------------------------------------------
// <copyright file="LicenseGroupId.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Licenses
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// The available license group identifiers.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum LicenseGroupId
    {
        /// <summary>
        /// Indicates nothing - no type, used as an initializer.
        /// If any invalid value is passed, then it will be defaulted to this.
        /// </summary>
        None,

        /// <summary>
        /// Azure Active Directory
        /// This indicates that product SKU is managed by Azure AD.
        /// </summary>
        Group1,

        /// <summary>
        /// Store for Business
        /// This indicates that product SKU is not managed by Azure AD.
        /// </summary>
        Group2
    }
}