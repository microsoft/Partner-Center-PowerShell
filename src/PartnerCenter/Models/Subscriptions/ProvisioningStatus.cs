// -----------------------------------------------------------------------
// <copyright file="ProvisioningStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the available status for a subscription provisioning status.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ProvisioningStatus
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Subscription provisioning status success.
        /// </summary>
        Success,

        /// <summary>
        /// Subscription provisioning status pending.
        /// </summary>
        Pending,

        /// <summary>
        /// Subscription provisioning status failed.
        /// </summary>
        Failed
    }
}