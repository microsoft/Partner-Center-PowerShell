// -----------------------------------------------------------------------
// <copyright file="SupportContact.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// Represents a form of support contact for a customer's subscription.
    /// </summary>
    public sealed class SupportContact : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the support MPN identifier.
        /// </summary>
        public string SupportMpnId { get; set; }

        /// <summary>
        /// Gets or sets the support tenant identifier.
        /// </summary>
        public string SupportTenantId { get; set; }
    }
}