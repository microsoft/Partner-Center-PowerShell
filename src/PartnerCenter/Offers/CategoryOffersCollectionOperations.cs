// -----------------------------------------------------------------------
// <copyright file="CategoryOffersCollectionOperations.cs" company="Microsoft">
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
    /// Category offers operations implementation class
    /// .</summary>
    internal class CategoryOffersCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ICategoryOffersCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryOffersCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="categoryId">The category ID which contains the offers.</param>
        /// <param name="country">The country on which to base the offers.</param>
        public CategoryOffersCollectionOperations(IPartner rootPartnerOperations, string categoryId, string country)
          : base(rootPartnerOperations, new Tuple<string, string>(categoryId, country))
        {
        }

        /// <summary>
        /// Retrieves all the offers in the given offer category.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The offers in the given offer category.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.Country,
                    Context.Item2
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.OfferCategoryId,
                    Context.Item1
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOffers.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a subset of offers in the given offer category.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of offers to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested segment of the offers in the given offer category.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(int offset, int size, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.Country,
                    Context.Item2
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetOffers.Parameters.OfferCategoryId,
                    Context.Item1
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
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOffers.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}