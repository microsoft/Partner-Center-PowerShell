// -----------------------------------------------------------------------
// <copyright file="AgreementDetailsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Agreements
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Agreements;

    /// <summary>
    /// Agreement details collection operations implementation class.
    /// </summary>
    internal class AgreementDetailsCollectionOperations : BasePartnerComponent<string>, IAgreementDetailsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgreementDetailsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rootPartnerOperations"/> is null.
        /// </exception>
        public AgreementDetailsCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets the list of agreement details.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of agreement details.</returns>
        public async Task<ResourceCollection<AgreementMetaData>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<AgreementMetaData>>(
                new Uri(
                     $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAgreementsDetails.Path}",
                     UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}