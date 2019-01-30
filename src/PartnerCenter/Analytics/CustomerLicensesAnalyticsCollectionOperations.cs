// -----------------------------------------------------------------------
// <copyright file="CustomerLicensesAnalyticsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    using Extensions;

    /// <summary>
    /// Implements the operations on a customer licenses analytics collection.
    /// </summary>
    internal class CustomerLicensesAnalyticsCollectionOperations : BasePartnerComponent<string>, ICustomerLicensesAnalyticsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerLicensesAnalyticsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The identifier of the customer</param>
        public CustomerLicensesAnalyticsCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));

            Deployment = new CustomerLicensesDeploymentInsightsCollectionOperations(rootPartnerOperations, customerId);
            Usage = new CustomerLicensesUsageInsightsCollectionOperations(rootPartnerOperations, customerId);
        }

        /// <summary>
        /// Gets the operations on a customer's licenses' deployment insights collection.
        /// </summary>
        public ICustomerLicensesDeploymentInsightsCollection Deployment { get; }

        /// <summary>
        /// Gets the operations on a customer's licenses' usage insights collection.
        /// </summary>
        public ICustomerLicensesUsageInsightsCollection Usage { get; }
    }
}