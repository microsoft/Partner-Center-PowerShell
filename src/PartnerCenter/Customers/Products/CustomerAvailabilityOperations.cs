// -----------------------------------------------------------------------
// <copyright file="CustomerAvailabilityOperations.cs" company="Microsoft">
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
    using Models.Products;
    using PartnerCenter.Products;

    /// <summary>
    /// Single customer availability operations implementation.
    /// </summary>
    internal class CustomerAvailabilityOperations : BasePartnerComponent<Tuple<string, string, string, string>>, IAvailability
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAvailabilityOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The corresponding customer identifier.</param>
        /// <param name="productId">The corresponding product identifier.</param>
        /// <param name="skuId">The corresponding SKU identifier.</param>
        /// <param name="availabilityId">The availability identifier.</param>
        public CustomerAvailabilityOperations(IPartner rootPartnerOperations, string customerId, string productId, string skuId, string availabilityId)
          : base(rootPartnerOperations, new Tuple<string, string, string, string>(customerId, productId, skuId, availabilityId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
            availabilityId.AssertNotEmpty(nameof(availabilityId));
        }

        /// <summary>
        /// Gets the availability information.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The availability information.</returns>
        public Availability Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the availability information.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The availability information.</returns>
        public async Task<Availability> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<Availability>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerAvailability.Path}",
                        Context.Item1,
                        Context.Item2,
                        Context.Item3,
                        Context.Item4),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}