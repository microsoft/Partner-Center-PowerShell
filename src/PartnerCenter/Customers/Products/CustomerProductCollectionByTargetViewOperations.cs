// -----------------------------------------------------------------------
// <copyright file="CustomerProductCollectionByTargetViewOperations.cs" company="Microsoft">
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
    /// Product operations by customer id and by target view implementation class.
    /// </summary>
    internal class CustomerProductCollectionByTargetViewOperations : BasePartnerComponent<Tuple<string, string>>, ICustomerProductCollectionByTargetView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProductCollectionByTargetViewOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="targetView">The target view which contains the products.</param>
        public CustomerProductCollectionByTargetViewOperations(IPartner rootPartnerOperations, string customerId, string targetView)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, targetView))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            targetView.AssertNotEmpty(nameof(targetView));
        }

        /// <summary>
        /// Gets the operations that can be applied on products in a given catalog view and that apply to a given customer, filtered by target segment.
        /// </summary>
        /// <param name="targetSegment">The product segment filter.</param>
        /// <returns>The product collection operations by customer, by target view and by target segment.</returns>
        public ICustomerProductCollectionByTargetViewByTargetSegment ByTargetSegment(string targetSegment)
        {
            return new CustomerProductCollectionByTargetViewByTargetSegmentOperations(Partner, Context.Item1, Context.Item2, targetSegment);
        }

        /// <summary>
        /// Gets all the products in a given catalog view that apply to a given customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The products in a given catalog view that apply to a given customer.</returns>
        public async Task<ResourceCollection<Product>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
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