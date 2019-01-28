// -----------------------------------------------------------------------
// <copyright file="SupportTopicsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.SubscribedSkus
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Licenses;

    /// <summary>
    /// Represents the behavior of the customer's subscribed products.
    /// </summary>
    public interface ICustomerSubscribedSkuCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets all the customer subscribed products.
        /// </summary>
        /// <param name="licenseGroupIds">A collection of license group identifiers.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer subscribed products.</returns>
        ResourceCollection<SubscribedSku> Get(List<LicenseGroupId> licenseGroupIds = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the customer subscribed products.
        /// </summary>
        /// <param name="licenseGroupIds">A collection of license group identifiers.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer subscribed products.</returns>
        Task<ResourceCollection<SubscribedSku>> GetAsync(List<LicenseGroupId> licenseGroupIds = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}