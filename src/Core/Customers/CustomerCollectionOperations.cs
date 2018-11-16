// -----------------------------------------------------------------------
// <copyright file="CustomerCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Customers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Customers;

    /// <summary>
    /// The partner customers implementation.
    /// </summary>
    internal class CustomerCollectionOperations : BasePartnerComponent, ICustomerCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public CustomerCollectionOperations(IPartner rootPartnerOperations)
            : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets the customer operations for the specified customer.
        /// </summary>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <returns>An instance of the <see cref="CustomerOperations" /> class.</returns>
        public ICustomerOperations this[string customerId] => ById(customerId);

        /// <summary>
        /// Gets the customer operations for the specified customer.
        /// </summary>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <returns>An instance of the <see cref="CustomerOperations" /> class.</returns>
        public ICustomerOperations ById(string customerId)
        {
            return new CustomerOperations(Partner, customerId);
        }

        /// <summary>
        /// Gets a collection of customers associated with the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of customers associated with the partner.</returns>
        public async Task<SeekBasedResourceCollection<Customer>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Customer>>(
                Partner,
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomers.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}