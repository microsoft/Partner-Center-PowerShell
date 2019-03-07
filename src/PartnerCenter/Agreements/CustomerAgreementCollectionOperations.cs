// -----------------------------------------------------------------------
// <copyright file="CustomerAgreementCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Agreements
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.Agreements;

    /// <summary>
    /// Customer's agreement collection operations implementations class.
    /// </summary>
    internal class CustomerAgreementCollectionOperations : BasePartnerComponent<string>, ICustomerAgreementCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAgreementCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The identifier for the customer.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="rootPartnerOperations"/> is null.
        /// </exception>
        /// <exception>
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        public CustomerAgreementCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Creates an agreement between the partner and customer.
        /// </summary>
        /// <param name="newEntity">The customer agreement to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The newly created customer agreement.</returns>
        public async Task<Agreement> CreateAsync(Agreement newEntity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PostAsync<Agreement, Agreement>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateCustomerAgreement.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the partner-customer agreements.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A list of agreements between the partner and customer.</returns>
        public async Task<ResourceCollection<Agreement>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Agreement>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerAgreements.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}