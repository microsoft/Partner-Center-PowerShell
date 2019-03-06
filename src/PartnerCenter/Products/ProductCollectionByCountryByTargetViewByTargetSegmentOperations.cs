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

    internal class ProductCollectionByCountryByTargetViewByTargetSegmentOperations : BasePartnerComponent<Tuple<string, string, string>>, IProductCollectionByCountryByTargetViewByTargetSegment
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionByCountryByTargetViewByTargetSegmentOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="targetView">The target view which contains the products.</param>
        /// <param name="country">The country on which to base the products.</param>
        /// <param name="targetSegment">The target segment used for filtering the products.</param>
        public ProductCollectionByCountryByTargetViewByTargetSegmentOperations(
          IPartner rootPartnerOperations,
          string targetView,
          string country,
          string targetSegment)
          : base(rootPartnerOperations, new Tuple<string, string, string>(targetView, country, targetSegment))
        {
            targetView.AssertNotEmpty(nameof(targetView));
            country.AssertNotEmpty(nameof(country));
            targetSegment.AssertNotEmpty(nameof(targetSegment)); 
        }

        /// <summary>
        /// Retrieves all the products in the given country, catalog view and target segment.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The products in the given country, catalog view and target segment.</returns>
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
                    Context.Item3
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetProducts.Parameters.TargetView,
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
