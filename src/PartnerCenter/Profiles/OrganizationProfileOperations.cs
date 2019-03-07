// -----------------------------------------------------------------------
// <copyright file="OrganizationProfileOperations.cs" company="Microsoft">
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
    /// The organization profile operations implementation.
    /// </summary>
    internal class OrganizationProfileOperations : BasePartnerComponent<string>, IOrganizationProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public OrganizationProfileOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves the organization profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The organization profile.</returns>
        public async Task<OrganizationProfile> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<OrganizationProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrganizationProfile.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the organization profile.</summary>
        /// <param name="entity">The updated organization profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated organization profile.</returns>
        public async Task<OrganizationProfile> UpdateAsync(OrganizationProfile entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PutAsync<OrganizationProfile, OrganizationProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrganizationProfile.Path}",
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}