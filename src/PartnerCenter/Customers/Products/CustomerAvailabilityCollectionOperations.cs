// -----------------------------------------------------------------------
// <copyright file="CustomerAvailabilityCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Products
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Products;
    using PartnerCenter.Products;

    /// <summary>
    /// Implementation of customer availabilities operations.
    /// </summary>
    internal class CustomerAvailabilityCollectionOperations : BasePartnerComponent<Tuple<string, string, string>>, IAvailabilityCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAvailabilityCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="skuId">The sku identifier.</param>
        public CustomerAvailabilityCollectionOperations(IPartner rootPartnerOperations, string customerId, string productId, string skuId)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, productId, skuId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
        }

        /// <summary>
        /// Gets the operations tied with a specific availability.
        /// </summary>
        /// <param name="id">The availability identifier.</param>
        /// <returns>The availability operations.</returns>
        public IAvailability this[string id] => ById(id);

        /// <summary>
        /// Gets the operations tied with a specific availability.
        /// </summary>
        /// <param name="id">The availability identifier.</param>
        /// <returns>The availability operations.</returns>
        public IAvailability ById(string id)
        {
            return new CustomerAvailabilityOperations(Partner, Context.Item1, Context.Item2, Context.Item3, id);
        }

        /// <summary>
        /// Gets the operations that can be applied on availabilities filtered by a specific target segment.
        /// </summary>
        /// <param name="targetSegment">The availability segment filter.</param>
        /// <returns>The availability collection operations by target segment.</returns>
        public IAvailabilityCollectionByTargetSegment ByTargetSegment(string targetSegment)
        {
            return new CustomerAvailabilityCollectionByTargetSegmentOperations(Partner, Context.Item1, Context.Item2, Context.Item3, targetSegment);
        }

        /// <summary>
        /// Gets all the availabilities for the provided SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The availability for the provided SKU.</returns>
        public ResourceCollection<Availability> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets all the availabilities for the provided SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The availability for the provided SKU.</returns>
        public async Task<ResourceCollection<Availability>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Availability>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerAvailabilities.Path}",
                        Context.Item1,
                        Context.Item2,
                        Context.Item3),
                    UriKind.Relative),
                new ResourceCollectionConverter<Availability>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}