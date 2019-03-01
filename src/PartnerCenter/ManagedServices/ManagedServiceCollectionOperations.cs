// -----------------------------------------------------------------------
// <copyright file="ManagedServiceCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ManagedServices
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.ManagedServices;

    /// <summary>
    /// Implements a customer's managed services operations.
    /// </summary>
    internal class ManagedServiceCollectionOperations : BasePartnerComponent<string>, IManagedServiceCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedServiceCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public ManagedServiceCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets managed services for a customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's managed services.</returns>
        public async Task<ResourceCollection<ManagedService>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<ManagedService>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerManagedServices.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<ManagedService>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}