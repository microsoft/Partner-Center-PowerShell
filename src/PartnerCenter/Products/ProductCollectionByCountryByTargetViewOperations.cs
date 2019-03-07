// -----------------------------------------------------------------------
// <copyright file="ProductCollectionByCountryByTargetViewOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Products;

    /// <summary>
    /// Product operations by country and by target view implementation class.
    /// </summary>
    internal class ProductCollectionByCountryByTargetViewOperations : BasePartnerComponent<Tuple<string, string>>, IProductCollectionByCountryByTargetView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionByCountryByTargetViewOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="targetView">The target view which contains the products.</param>
        /// <param name="country">The country on which to base the products.</param>
        public ProductCollectionByCountryByTargetViewOperations(IPartner rootPartnerOperations, string targetView, string country)
          : base(rootPartnerOperations, new Tuple<string, string>(targetView, country))
        {
            targetView.AssertNotEmpty(nameof(targetView));
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the operations that can be applied on products that belong to a given country, catalog view and target segment.
        /// </summary>
        /// <param name="targetSegment">The target segment filter.</param>
        /// <returns>The product collection operations by country, by target view and by target segment.</returns>
        public IProductCollectionByCountryByTargetViewByTargetSegment ByTargetSegment(string targetSegment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the products in the given country and catalog view.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The products in the given country and catalog view.</returns>
        public async Task<ResourceCollection<Product>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetProducts.Parameters.Country,
                    Context.Item2
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetProducts.Parameters.TargetSegment,
                    Context.Item1
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Product>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetProducts.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Product>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}