// -----------------------------------------------------------------------
// <copyright file="OfferCollectionOperations.cs" company="Microsoft">
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
    /// Offer Collection operations implementation.
    /// </summary>
    internal class OfferCollectionOperations : BasePartnerComponent<string>, IOfferCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="country">The country on which to base the offers.</param>
        public OfferCollectionOperations(IPartner rootPartnerOperations, string country)
          : base(rootPartnerOperations, country)
        {
        }

        /// <summary>
        /// Gets the operations tied with a specific offer.
        /// </summary>
        /// <param name="offerId">The offer identifier.</param>
        /// <returns>The offer operations.</returns>
        public IOffer this[string offerId] => ById(offerId);

        /// <summary>
        /// Retrieves the operations that can be applied on offers the belong to an offer category.
        /// </summary>
        /// <param name="categoryId">The offer category identifier.</param>
        /// <returns>The category offers operations.</returns>
        public ICategoryOffersCollection ByCategory(string categoryId) => new CategoryOffersCollectionOperations(Partner, categoryId, Context);

        /// <summary>
        /// Retrieves the operations tied with a specific offer.
        /// </summary>
        /// <param name="id">The offer identifier.</param>
        /// <returns>The offer operations.</returns>
        public IOffer ById(string id) => new OfferOperations(Partner, id, Context);

        /// <summary>
        /// Retrieves all the offers for the provided country.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All offers for the provided country.</returns>
        public ResourceCollection<Offer> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves a subset of offers  for the provided country.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of offers to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested segment of the offers for the provided country.</returns>
        public ResourceCollection<Offer> Get(int offset, int size, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(offset, size, cancellationToken));
        }

        /// <summary>
        /// Retrieves all the offers for the provided country.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All offers for the provided country.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.Country,
                    Context
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOffers.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a subset of offers  for the provided country.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of offers to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested segment of the offers for the provided country.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(int offset, int size, CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.Country,
                        Context
                    },
                    {
                        PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.Offset,
                        offset.ToString(CultureInfo.InvariantCulture)
                    },
                    {
                        PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.Size,
                        size.ToString(CultureInfo.InvariantCulture)
                    }
                };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOffers.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}