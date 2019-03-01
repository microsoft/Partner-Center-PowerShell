// -----------------------------------------------------------------------
// <copyright file="CustomerUsersCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Query;
    using Models.Users;

    /// <summary>
    /// Customer user collection operations class.
    /// </summary>
    internal class CustomerUsersCollectionOperations : BasePartnerComponent<string>, ICustomerUserCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUsersCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerUsersCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a specific customer user behavior.
        /// </summary>
        /// <param name="id">The identifier for the customer user.</param>
        /// <returns>The customer user operations.</returns>
        public ICustomerUser this[string id] => ById(id);

        /// <summary>
        /// Gets a specific customer user behavior.
        /// </summary>
        /// <param name="id">The identifier for the customer user.</param>
        /// <returns>The customer user operations.</returns>
        public ICustomerUser ById(string id)
        {
            return new CustomerUserOperations(Partner, Context, id);
        }

        /// <summary>
        /// Create a new user for the customer.
        /// </summary>
        /// <param name="newEntity">The user object containing details for the new user to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The newly created user.</returns>
        public async Task<CustomerUser> CreateAsync(CustomerUser newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<CustomerUser, CustomerUser>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateCustomerUser.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the customer users.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer orders.</returns>
        public async Task<SeekBasedResourceCollection<CustomerUser>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<CustomerUser>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<CustomerUser>(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Queries customer users associated to the partner's customers.
        /// - Count queries are not supported by this operation.
        /// - You can set page size, filter and sort option.
        /// - You can navigate to other pages by specifying a seek query with the seek operation and the continuation
        ///   token sent by the previous operation.
        /// </summary>
        /// <param name="customerusersQuery">
        /// A query to apply onto customer users collection. Check <see cref="QueryFactory" /> to see how to build queries.
        /// </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested customer users.</returns>
        public async Task<SeekBasedResourceCollection<CustomerUser>> QueryAsync(IQuery query, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> headers = null;
            IDictionary<string, string> parameters;

            query.AssertNotNull(nameof(query));

            if (query.Type == QueryType.Seek)
            {
                query.Token.AssertNotNull(nameof(query.Token));

                headers = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.AdditionalHeaders.ContinuationToken,
                        query.Token.ToString()
                    }
                };

                parameters = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Parameters.SeekOperation,
                        query.SeekOperation.ToString()
                    }
                };
            }
            else
            {
                parameters = new Dictionary<string, string>();

                if (query.Type == QueryType.Indexed)
                {
                    query.PageSize = Math.Max(query.PageSize, 0);

                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Parameters.Size,
                        query.PageSize.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Parameters.Size,
                        "0");
                }

                if (query.Filter != null)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Parameters.Filter,
                        query.Filter.ToString());
                }

                if (query.Sort != null)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Parameters.SortDirection,
                        query.Sort.SortDirection.ToString());

                    parameters.Add(
                       PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Parameters.SortField,
                       query.Sort.SortField.ToString(CultureInfo.InvariantCulture));
                }
            }

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<CustomerUser>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerUsers.Path}",
                    UriKind.Relative),
                headers,
                parameters,
                new ResourceCollectionConverter<CustomerUser>(),
                cancellationToken).ConfigureAwait(false);

        }
    }
}