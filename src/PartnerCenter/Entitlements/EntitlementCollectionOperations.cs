// -----------------------------------------------------------------------
// <copyright file="EntitlementCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Entitlements
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using GenericOperations;
    using Models;
    using Models.Entitlements;

    /// <summary>
    /// Entitlement collection operations implementation class.
    /// </summary>
    internal class EntitlementCollectionOperations : BasePartnerComponent<string>, IEntitlementCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitlementCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        public EntitlementCollectionOperations(IPartner rootPartnerOperations, string customerId)
            : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId)); 
        }

        /// <summary>
        /// Gets the operations that can be applied on entitlements with a given entitlement type.
        /// </summary>
        /// <param name="entitlementType">The Entitlement Type.</param>
        /// <returns>The entitlement collection operations by entitlement type.</returns>
        public IEntireEntityCollectionRetrievalOperations<Entitlement, ResourceCollection<Entitlement>> ByEntitlementType(string entitlementType)
        {
            return new EntitlementCollectionByEntitlementTypeOperations(Partner, Context, entitlementType);
        }

        /// <summary>
        /// Gets entitlement collection.
        /// </summary>
        /// <returns>The entitlement collection with the given entitlement type.</returns>
        public async Task<ResourceCollection<Entitlement>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Entitlement>>(
              new Uri(
                  string.Format(
                      CultureInfo.InvariantCulture,
                      $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetEntitlements.Path}",
                      Context),
                  UriKind.Relative),
              cancellationToken).ConfigureAwait(false);
        }
    }
}
