// -----------------------------------------------------------------------
// <copyright file="LegalBusinessProfileOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Partners;

    /// <summary>
    /// The legal business profile operations implementation.
    /// </summary>
    internal class LegalBusinessProfileOperations : BasePartnerComponent<string>, ILegalBusinessProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegalBusinessProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public LegalBusinessProfileOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves the legal business profile.
        /// </summary>
        /// <param name="vettingVersion">The vetting version. The default value is set to Current.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The legal business profile.</returns>
        public async Task<LegalBusinessProfile> GetAsync(VettingVersion vettingVersion = VettingVersion.Current, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetLegalBusinessProfile.Parameters.VettingVersion,
                    vettingVersion.ToString()
                }
            };

            return await Partner.ServiceClient.GetAsync<LegalBusinessProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetLegalBusinessProfile.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the legal business profile.
        /// </summary>
        /// <param name="entity">Payload of the update request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated legal business profile.</returns>
        public async Task<LegalBusinessProfile> UpdateAsync(LegalBusinessProfile entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PutAsync<LegalBusinessProfile, LegalBusinessProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetLegalBusinessProfile.Path}",
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
