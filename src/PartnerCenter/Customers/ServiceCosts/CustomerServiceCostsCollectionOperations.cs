// -----------------------------------------------------------------------
// <copyright file="CustomerServiceCostsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using Extensions;
    using Models.ServiceCosts;

    /// <summary>
    /// Holds customer service costs behavior.
    /// </summary>
    internal class CustomerServiceCostsCollectionOperations : BasePartnerComponent<string>, ICustomerServiceCostsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerServiceCostsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerServiceCostsCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Obtains the service cost operations by billing period.
        /// </summary>
        /// <param name="billingPeriod">The billing period.</param>
        /// <returns>The service cost operations.</returns>
        public IServiceCostsCollection ByBillingPeriod(ServiceCostsBillingPeriod billingPeriod)
        {
            return new ServiceCostsCollectionOperations(Partner, Context, billingPeriod);
        }
    }
}