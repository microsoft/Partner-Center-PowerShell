// -----------------------------------------------------------------------
// <copyright file="CustomerUsageSpendingBudgetOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Microsoft.Store.PartnerCenter.Models.Usage;

    /// <summary>
    /// This class implements the operations available on a customer's usage spending budget.
    /// </summary>
    internal class CustomerUsageSpendingBudgetOperations : BasePartnerComponent<string>, ICustomerUsageSpendingBudget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUsageSpendingBudgetOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerUsageSpendingBudgetOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets the usage spending budget allocated to a customer by the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer usage spending budget.</returns>
        public async Task<SpendingBudget> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SpendingBudget>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerUsageSpendingBudget.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the usage spending budget allocated to a customer by the partner.
        /// </summary>
        /// <param name="usageSpendingBudget">The new customer usage spending budget.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated customer usage spending budget.</returns>
        public async Task<SpendingBudget> PatchAsync(SpendingBudget entity, CancellationToken cancellationToken = default)
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<SpendingBudget, SpendingBudget>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.PatchCustomerUsageSpendingBudget.Path}",
                        Context),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}