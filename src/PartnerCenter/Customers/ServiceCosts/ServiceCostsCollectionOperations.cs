// -----------------------------------------------------------------------
// <copyright file="CustomerServiceCostsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using System;
    using Extensions;
    using Models.ServiceCosts;

    /// <summary>
    ///  Holds the operations related to a customer's service costs.
    /// </summary>
    internal class ServiceCostsCollectionOperations : BasePartnerComponent<Tuple<string, ServiceCostsBillingPeriod>>, IServiceCostsCollection
    {
        /// <summary>
        /// Provides access to the current customer's service cost line items operations.
        /// </summary>
        private readonly Lazy<IServiceCostLineItemsCollection> lineItems;

        /// <summary>
        /// Provides access to the current customer's service cost summary operations.
        /// </summary>
        private readonly Lazy<IServiceCostSummary> summary;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCostsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="billingPeriod">The service cost billing period.</param>
        public ServiceCostsCollectionOperations(IPartner rootPartnerOperations, string customerId, ServiceCostsBillingPeriod billingPeriod)
          : base(rootPartnerOperations, new Tuple<string, ServiceCostsBillingPeriod>(customerId, billingPeriod))
        {
            customerId.AssertNotEmpty(nameof(customerId));

            lineItems = new Lazy<IServiceCostLineItemsCollection>(() => new ServiceCostLineItemsOperations(Partner, Context));
            summary = new Lazy<IServiceCostSummary>(() => new ServiceCostSummaryOperations(Partner, Context));
        }

        /// <summary>
        /// Gets the customer's service cost line items.
        /// </summary>
        public IServiceCostLineItemsCollection LineItems => lineItems.Value;

        /// <summary>
        /// Gets the customer's service cost summary.
        /// </summary>
        public IServiceCostSummary Summary => summary.Value;
    }
}
