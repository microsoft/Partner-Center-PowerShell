// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions
{
    using Extensions;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// Represents a form of support contact for a customer's subscription.
    /// </summary>
    public sealed class PSSupportContact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSupportContact" /> class.
        /// </summary>
        public PSSupportContact()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSupportContact" /> class.
        /// </summary>
        /// <param name="subscription">The base contact for this instance.</param>
        public PSSupportContact(SupportContact contact)
        {
            this.CopyFrom(contact);
        }

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