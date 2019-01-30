// -----------------------------------------------------------------------
// <copyright file="CustomerProductCollectionByTargetViewByTargetSegmentOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Products
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Products;

    /// <summary>
    /// Product operations by customer identifier, by target view and by target segment implementation class.
    /// </summary>
    internal class CustomerProductCollectionByTargetViewByTargetSegmentOperations : BasePartnerComponent<Tuple<string, string, string>>, ICustomerProductCollectionByTargetViewByTargetSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProductCollectionByTargetViewByTargetSegmentOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="targetView">The target view which contains the products.</param>
        /// <param name="targetSegment">The target segment used for filtering the products.</param>
        public CustomerProductCollectionByTargetViewByTargetSegmentOperations(IPartner rootPartnerOperations, string customerId, string targetView, string targetSegment)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, targetView, targetSegment))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            targetView.AssertNotEmpty(nameof(targetView));
            targetSegment.AssertNotEmpty(nameof(targetSegment));
        }

        /// <summary>
        /// Gets all the products in a given catalog view and that apply to a given customer, filtered by target segment.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The products in a given catalog view and that apply to a given customer, filtered by target segment.</returns>
        public ResourceCollection<Product> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets all the products in a given catalog view and that apply to a given customer, filtered by target segment.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The products in a given catalog view and that apply to a given customer, filtered by target segment.</returns>
        public async Task<ResourceCollection<Product>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerProducts.Parameters.TargetSegment,
                    Context.Item3
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerProducts.Parameters.TargetView,
                    Context.Item2
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Product>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerProducts.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Product>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}