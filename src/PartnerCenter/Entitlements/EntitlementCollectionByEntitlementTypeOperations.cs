// -----------------------------------------------------------------------
// <copyright file="EntitlementCollectionByEntitlementTypeOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Entitlements
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using GenericOperations;
    using Models;
    using Models.Entitlements;
    using Models.JsonConverters;

    /// <summary>
    /// Entitlement collection by entitlement type operations class.
    /// </summary>
    internal class EntitlementCollectionByEntitlementTypeOperations : BasePartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Entitlement, ResourceCollection<Entitlement>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitlementCollectionByEntitlementTypeOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="entitlementType">The entitlement type.</param>
        public EntitlementCollectionByEntitlementTypeOperations(IPartner rootPartnerOperations, string customerId, string entitlementType)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, entitlementType))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            entitlementType.AssertNotEmpty(nameof(entitlementType));
        }

        /// <summary>
        /// Gets entitlement collection with the given entitlement type.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entitlement collection with the given entitlement type.</returns>
        public async Task<ResourceCollection<Entitlement>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetEntitlements.Parameters.EntitlementType,
                    Context.Item2
                }
            };

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Entitlement>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetEntitlements.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Entitlement>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}