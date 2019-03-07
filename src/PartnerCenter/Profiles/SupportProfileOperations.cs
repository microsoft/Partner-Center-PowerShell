// -----------------------------------------------------------------------
// <copyright file="SupportProfileOperations.cs" company="Microsoft">
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
    /// The support profile operations implementation.
    /// </summary>
    internal class SupportProfileOperations : BasePartnerComponent<string>, ISupportProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupportProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public SupportProfileOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves the support profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The support profile.</returns>
        public async Task<SupportProfile> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SupportProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSupportProfile.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the support Profile.
        /// </summary>
        /// <param name="entity">The updated instance of the support profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated support profile</returns>
        public async Task<SupportProfile> UpdateAsync(SupportProfile entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PutAsync<SupportProfile, SupportProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateSupportProfile.Path}",
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
