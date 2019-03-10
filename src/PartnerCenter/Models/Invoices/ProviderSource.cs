// -----------------------------------------------------------------------
// <copyright file="ProviderSource.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Different providers of billing information
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ProviderSource
    {
        /// <summary>
        /// Enum initializer
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the provider is both first party and third party
        /// </summary>
        All,

        /// <summary>
        /// Indicates that the provider is first party    
        /// </summary>
        Microsoft,

        /// <summary>
        /// Indicates that the provider is third party       
        /// </summary>
        External
    }
}