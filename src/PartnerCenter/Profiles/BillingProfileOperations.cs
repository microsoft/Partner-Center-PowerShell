// -----------------------------------------------------------------------
// <copyright file="BillingProfileOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Partners;

    /// <summary>
    /// The billing profile operations implementation.
    /// </summary>
    internal class BillingProfileOperations : BasePartnerComponent<string>, IBillingProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public BillingProfileOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves the billing profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The billing profile.</returns>
        public async Task<BillingProfile> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<BillingProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetPartnerBillingProfile.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the billing profile.
        /// </summary>
        /// <param name="entity">The updated instacne of the billing profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Updated billing Profile.</returns>
        public async Task<BillingProfile> UpdateAsync(BillingProfile entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PutAsync<BillingProfile, BillingProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdatePartnerBillingProfile.Path}",
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
