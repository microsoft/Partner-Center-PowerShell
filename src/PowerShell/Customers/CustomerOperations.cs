// -----------------------------------------------------------------------
// <copyright file="CustomerOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Customers
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Customers;
    using Profiles;

    /// <summary>
    /// Impelements the available operations for a customer.
    /// </summary>
    internal class CustomerOperations : BasePartnerComponent, ICustomerOperations
    {
        /// <summary>
        /// The customer profiles operations.
        /// </summary>
        private readonly Lazy<ICustomerProfileCollection> profiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        public CustomerOperations(IPartner rootPartnerOperations, string customerId)
            : base(rootPartnerOperations, customerId)
        {
            profiles = new Lazy<ICustomerProfileCollection>(() => new CustomerProfileCollectionOperations(Partner, Context));
        }

        /// <summary>
        /// Gets the available customer profile operations.
        /// </summary>
        public ICustomerProfileCollection Profiles => profiles.Value;

        /// <summary>
        /// Deletes the customer from a testing in production account. This won't work for real accounts.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public void Delete(CancellationToken cancellationToken = default(CancellationToken))
        {
            PartnerService.SynchronousExecute(() => DeleteAsync(cancellationToken));
        }

        /// <summary>
        /// Deletes the customer from a testing in production account. This won't work for real accounts.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Partner.ServiceClient.DeleteAsync(
                Partner,
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.DeleteCustomer.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information for the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The information for the customer.</returns>
        public Customer Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the information for the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The information for the customer.</returns>
        public async Task<Customer> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<Customer>(
                Partner,
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomer.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes Customer Partner relationship when RelationshipToPartner == CustomerPartnerRelationship.None.
        /// </summary>
        /// <param name="customer">A customer with RelationshipToPartner == CustomerPartnerRelationship.None.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer information.</returns>
        public Customer Patch(Customer entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => PatchAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Removes the relationship between the partner and customer when RelationshipToPartner == CustomerPartnerRelationship.None.
        /// </summary>
        /// <param name="customer">A customer with RelationshipToPartner == CustomerPartnerRelationship.None.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer information.</returns>
        public async Task<Customer> PatchAsync(Customer entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.PatchAsync(
                Partner,
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.RemoveCustomerRelationship.Path}",
                        Context),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}