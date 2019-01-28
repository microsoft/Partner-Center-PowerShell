// -----------------------------------------------------------------------
// <copyright file="CustomerServiceCostsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.ServiceCosts;

    /// <summary>
    /// Represents the behavior of the customer service cost line items as a whole.
    /// </summary>
    internal class ServiceCostLineItemsOperations : BasePartnerComponent<Tuple<string, ServiceCostsBillingPeriod>>, IServiceCostLineItemsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCostLineItemsOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="context">The context, including customer identifier and billing period.</param>
        public ServiceCostLineItemsOperations(IPartner rootPartnerOperations, Tuple<string, ServiceCostsBillingPeriod> context)
          : base(rootPartnerOperations, context)
        {
            context.AssertNotNull(nameof(context));
        }

        /// <summary>
        /// Gets a customer's service cost line items.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service cost line items.</returns>
        public ResourceCollection<ServiceCostLineItem> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets a customer's service cost line items.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service cost line items.</returns>
        public async Task<ResourceCollection<ServiceCostLineItem>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceCostLineItem>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerServiceCostLineItems.Path}",
                        Context.Item1, 
                        Context.Item2.ToString()),
                    UriKind.Relative),
                new ResourceCollectionConverter<ServiceCostLineItem>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
