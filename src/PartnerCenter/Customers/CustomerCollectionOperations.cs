// -----------------------------------------------------------------------
// <copyright file="CustomerCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.Customers;
    using Models.JsonConverters;
    using Models.Query;
    using RelationshipRequests;
    using Usage;

    /// <summary>
    /// The partner customers implementation.
    /// </summary>
    internal class CustomerCollectionOperations : BasePartnerComponent<string>, ICustomerCollection
    {
        /// <summary>
        /// A lazy reference to a customer relationship request operations.
        /// </summary>
        private readonly Lazy<ICustomerRelationshipRequest> relationshipRequest;

        /// <summary>
        /// A lazy reference to the current partner's customer usage records operations.
        /// </summary>
        private readonly Lazy<ICustomerUsageRecordCollection> usageRecords;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public CustomerCollectionOperations(IPartner rootPartnerOperations)
            : base(rootPartnerOperations)
        {
            relationshipRequest = new Lazy<ICustomerRelationshipRequest>(() => new CustomerRelationshipRequestOperations(Partner));
            usageRecords = new Lazy<ICustomerUsageRecordCollection>(() => new CustomerUsageRecordCollectionOperations(Partner));
        }

        /// <summary>
        /// Gets the relationship request behavior used to relate customers into the partner.
        /// </summary>
        public ICustomerRelationshipRequest RelationshipRequest => relationshipRequest.Value;

        /// <summary>
        /// Gets the customer usage records behavior for the partner.
        /// </summary>
        public ICustomerUsageRecordCollection UsageRecords => usageRecords.Value;

        /// <summary>
        /// Gets the customer operations for the specified customer.
        /// </summary>
        /// <param name="id">Identifier for the customer.</param>
        /// <returns>An instance of the <see cref="CustomerOperations" /> class.</returns>
        public ICustomer this[string id] => ById(id);

        /// <summary>
        /// Gets the customer operations for the specified customer.
        /// </summary>
        /// <param name="id">Identifier for the customer.</param>
        /// <returns>An instance of the <see cref="CustomerOperations" /> class.</returns>
        public ICustomer ById(string id)
        {
            return new CustomerOperations(Partner, id);
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="newEntity">The new customer information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer information that was just created.</returns>
        public async Task<Customer> CreateAsync(Customer newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<Customer, Customer>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateCustomer.Path}",
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a collection of customers associated with the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of customers associated with the partner.</returns>
        public async Task<SeekBasedResourceCollection<Customer>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Customer>>(
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomers.Path}",
                    UriKind.Relative),
                new ResourceCollectionConverter<Customer>(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Queries customers associated to the partner.
        /// - Count queries are not supported by this operation.
        /// - You can set the page size or filter or do both at the same time.
        /// - Sort is not supported.
        /// - You can navigate to other pages by specifying a seek query with the seek operation and the continuation
        ///   token sent by the previous operation.
        /// </summary>
        /// <param name="customersQuery">A query to apply onto customers. Check <see cref="QueryFactory" /> to see how to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested customers.</returns>
        public async Task<SeekBasedResourceCollection<Customer>> QueryAsync(IQuery customersQuery, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> headers = null;
            IDictionary<string, string> parameters;

            customersQuery.AssertNotNull(nameof(customersQuery));

            if (customersQuery.Type == QueryType.Seek)
            {
                customersQuery.Token.AssertNotNull(nameof(customersQuery.Token));

                headers = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetCustomers.AdditionalHeaders.ContinuationToken,
                        customersQuery.Token.ToString()
                    }
                };

                parameters = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetCustomers.Parameters.SeekOperation,
                        customersQuery.SeekOperation.ToString()
                    }
                };
            }
            else
            {
                parameters = new Dictionary<string, string>();

                if (customersQuery.Type == QueryType.Indexed)
                {
                    customersQuery.PageSize = Math.Max(customersQuery.PageSize, 0);

                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomers.Parameters.Size,
                        customersQuery.PageSize.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomers.Parameters.Size,
                        "0");
                }

                if (customersQuery.Filter != null)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomers.Parameters.Filter,
                        customersQuery.Filter.ToString());
                }
            }

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Customer>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomers.Path}",
                    UriKind.Relative),
                headers,
                parameters,
                new ResourceCollectionConverter<Customer>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}