// -----------------------------------------------------------------------
// <copyright file="CustomerRelationshipCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Relationships
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Relationships;

    /// <summary>
    /// This is for indirect scenarios, holds the operations for retrieving partner relationships of a customer with respect to
    /// the logged in partner.
    /// </summary>
    internal class CustomerRelationshipCollectionOperations : BasePartnerComponent<string>, ICustomerRelationshipCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRelationshipCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerRelationshipCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets all the partners relationships associated to a specific customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner relationships.</returns>
        public async Task<ResourceCollection<PartnerRelationship>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<PartnerRelationship>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetPartnerRelationshipsForCustomer.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<PartnerRelationship>(), 
                cancellationToken).ConfigureAwait(false);
        }
    }
}