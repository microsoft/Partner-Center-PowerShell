// -----------------------------------------------------------------------
// <copyright file="OfferCategoryCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Offers categories implementation.
    /// </summary>
    internal class OfferCategoryCollectionOperations : BasePartnerComponent<string>, IOfferCategoryCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferCategoryCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="country">The country on which to base the offer categories.</param>
        public OfferCategoryCollectionOperations(IPartner rootPartnerOperations, string country)
          : base(rootPartnerOperations, country)
        {
        }

        /// <summary>
        /// Retrieves all offer categories available to the partner for the provided country.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All offer categories for the provided country.</returns>
        public ResourceCollection<OfferCategory> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all offer categories available to the partner for the provided country.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All offer categories for the provided country.</returns>
        public async Task<ResourceCollection<OfferCategory>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOfferCategories.Parameters.Country,
                    Context
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<OfferCategory>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOfferCategories.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}