// -----------------------------------------------------------------------
// <copyright file="Reservation.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Entitlements
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that represents a reservation.
    /// </summary>
    public class Reservation : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the applied scopes.
        /// </summary>
        public IEnumerable<string> AppliedScopes { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the effective date and time.
        /// </summary>
        public DateTime EffectiveDateTime { get; set; }

        /// <summary>
        /// Gets or sets the expiry date and time.
        /// </summary>
        public DateTime ExpiryDateTime { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets reservation identifier.
        /// </summary>
        public string ReservationId { get; set; }

        /// <summary>
        /// Gets or sets the scope type.
        /// </summary>
        public string ScopeType { get; set; }
    }
}