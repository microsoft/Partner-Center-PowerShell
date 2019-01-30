// -----------------------------------------------------------------------
// <copyright file="PartnerProfileCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using System;

    /// <summary>
    /// The partner profile collection operations implementation.
    /// </summary>
    internal class PartnerProfileCollectionOperations : BasePartnerComponent<string>, IPartnerProfileCollection
    {
        /// <summary>
        /// The legal business profile operations.
        /// </summary>
        private readonly Lazy<ILegalBusinessProfile> legalBusinessProfile;

        /// <summary>
        /// The MPN profile operations.
        /// </summary>
        private readonly Lazy<IMpnProfile> mpnProfileOperations;

        /// <summary>
        /// The support profile operations.
        /// </summary>
        private readonly Lazy<ISupportProfile> supportProfileOperations;

        /// <summary>
        /// The organization profile operations.
        /// </summary>
        private readonly Lazy<IOrganizationProfile> organizationProfile;

        /// <summary>
        /// The billing profile operations.
        /// </summary>
        private readonly Lazy<IBillingProfile> billingProfile;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerProfileCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public PartnerProfileCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
            billingProfile = new Lazy<IBillingProfile>(() => new BillingProfileOperations(Partner));
            legalBusinessProfile = new Lazy<ILegalBusinessProfile>(() => new LegalBusinessProfileOperations(Partner));
            mpnProfileOperations = new Lazy<IMpnProfile>(() => new MpnProfileOperations(Partner));
            organizationProfile = new Lazy<IOrganizationProfile>(() => new OrganizationProfileOperations(Partner));
            supportProfileOperations = new Lazy<ISupportProfile>((Func<ISupportProfile>)(() => (ISupportProfile)new SupportProfileOperations(Partner)));
        }

        /// <summary>
        /// Gets the operations available for the partner billing profile.
        /// </summary>
        public IBillingProfile BillingProfile => billingProfile.Value;

        /// <summary>
        /// Gets the operations available for the legal business profile.
        /// </summary>
        public ILegalBusinessProfile LegalBusinessProfile => legalBusinessProfile.Value;

        /// <summary>
        /// Gets the operations available for the Mpn profile.
        /// </summary>
        public IMpnProfile MpnProfile => mpnProfileOperations.Value;

        /// <summary>
        /// Gets the operations available for the organization profile.
        /// </summary>
        public IOrganizationProfile OrganizationProfile => organizationProfile.Value;

        /// <summary>
        /// Gets the operations available for the partner support profile.
        /// </summary>
        public ISupportProfile SupportProfile => supportProfileOperations.Value;
    }
}
