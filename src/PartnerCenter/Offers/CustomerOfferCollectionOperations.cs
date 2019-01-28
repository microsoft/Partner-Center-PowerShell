// -----------------------------------------------------------------------
// <copyright file="CustomerOfferCategoryCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Customer Offer operations implementation class.
    /// </summary>
    internal class CustomerOfferCollectionOperations : BasePartnerComponent<string>, ICustomerOfferCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOfferCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerOfferCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
        }

        /// <summary>Gets the offers available to customer from partner.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Offers available to customer from partner.</returns>
        public ResourceCollection<Offer> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets a segment of the offers available to customer from partner.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The desired segment size.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The required offers segment.</returns>
        public ResourceCollection<Offer> Get(int offset, int size, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(offset, size, cancellationToken));
        }

        /// <summary>Gets the offers available to customer from partner.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Offers available to customer from partner.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerOffers.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a segment of the offers available to customer from partner.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The desired segment size.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The required offers segment.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(int offset, int size, CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerOffers.Parameters.Offset,
                    offset.ToString(CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerOffers.Parameters.Size,
                    size.ToString(CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerOffers.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}