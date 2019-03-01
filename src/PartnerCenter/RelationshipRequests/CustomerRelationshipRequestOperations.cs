// -----------------------------------------------------------------------
// <copyright file="CustomerRelationshipRequestOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RelationshipRequests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.RelationshipRequests;

    /// <summary>
    /// Customer relationship request implementation class.
    /// </summary>
    internal class CustomerRelationshipRequestOperations : BasePartnerComponent<string>, ICustomerRelationshipRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRelationshipRequestOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public CustomerRelationshipRequestOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves the customer relationship request which can be used by a customer to establish a relationship with the current partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A customer relationship request.</returns>
        public async Task<CustomerRelationshipRequest> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<CustomerRelationshipRequest>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerRelationshipRequest.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}