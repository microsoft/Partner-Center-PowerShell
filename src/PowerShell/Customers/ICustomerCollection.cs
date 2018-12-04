// -----------------------------------------------------------------------
// <copyright file="ICustomerCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Customers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Customers;

    /// <summary>
    /// Represents the behavior of the partner customers.
    /// </summary>
    public interface ICustomerCollection
    {
        /// <summary>
        /// Gets the customer operations for the specified customer.
        /// </summary>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <returns>An instance of the <see cref="CustomerOperations" /> class.</returns>
        ICustomerOperations this[string customerId] { get; }

        /// <summary>
        /// Gets the customer operations for the specified customer.
        /// </summary>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <returns>An instance of the <see cref="CustomerOperations" /> class.</returns>
        ICustomerOperations ById(string customerId);

        /// <summary>
        /// Gets a collection of customers associated with the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of customers associated with the partner.</returns>
        Task<SeekBasedResourceCollection<Customer>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}