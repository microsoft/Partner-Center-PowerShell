// -----------------------------------------------------------------------
// <copyright file="ICustomerServiceCostsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using Models.ServiceCosts;

    /// <summary>
    /// Holds customer service costs behavior.
    /// </summary>
    public interface ICustomerServiceCostsCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Obtains the service cost operations by billing period.
        /// </summary>
        /// <param name="billingPeriod">The billing period.</param>
        /// <returns>The service cost operations.</returns>
        IServiceCostsCollection ByBillingPeriod(ServiceCostsBillingPeriod billingPeriod);
    }
}
