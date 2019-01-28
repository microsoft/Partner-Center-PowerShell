// -----------------------------------------------------------------------
// <copyright file="CustomerBillingProfileOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Profiles
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Customers;

    /// <summary>
    /// Implements the customer billing profile operations.
    /// </summary>
    internal class CustomerBillingProfileOperations : BasePartnerComponent<string>, ICustomerProfile<CustomerBillingProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBillingProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerBillingProfileOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets the customer's billing profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's billing profile.</returns>
        public CustomerBillingProfile Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the customer's billing profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's billing profile.</returns>
        public async Task<CustomerBillingProfile> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<CustomerBillingProfile>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerBillingProfile.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the customer's billing profile.
        /// </summary>
        /// <param name="billingProfile">A customer billing profile with updated fields.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated customer billing profile.</returns>
        public CustomerBillingProfile Update(CustomerBillingProfile entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => UpdateAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Updates the customer's billing profile.
        /// </summary>
        /// <param name="billingProfile">A customer billing profile with updated fields.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated customer billing profile.</returns>
        public async Task<CustomerBillingProfile> UpdateAsync(CustomerBillingProfile entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PutAsync<CustomerBillingProfile, CustomerBillingProfile>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateCustomerBillingProfile.Path}",
                        Context),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}