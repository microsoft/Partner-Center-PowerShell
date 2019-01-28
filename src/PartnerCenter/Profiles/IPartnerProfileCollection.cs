// -----------------------------------------------------------------------
// <copyright file="IPartnerProfileCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    /// <summary>Represents the behavior of a partner's profiles.</summary>
    public interface IPartnerProfileCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the operations available for the partner billing profile.
        /// </summary>
        IBillingProfile BillingProfile { get; }

        /// <summary>
        /// Gets the operations available for the legal business profile.
        /// </summary>
        ILegalBusinessProfile LegalBusinessProfile { get; }

        /// <summary>
        /// Gets the operations available for the Mpn profile.
        /// </summary>
        IMpnProfile MpnProfile { get; }

        /// <summary>
        /// Gets the operations available for the organization profile.
        /// </summary>
        IOrganizationProfile OrganizationProfile { get; }

        /// <summary>
        /// Gets the operations available for the partner support profile.
        /// </summary>
        ISupportProfile SupportProfile { get; }
    }
}