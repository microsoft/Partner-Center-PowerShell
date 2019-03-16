// -----------------------------------------------------------------------
// <copyright file="IEntitlementCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Entitlements
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Entitlements;

    /// <summary>
    /// Holds operations that can be performed on entitlements associated to the customer based on the logged in partner.
    /// </summary>
    public interface IEntitlementCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<Entitlement, ResourceCollection<Entitlement>>
    {
        /// <summary>
        /// Gets the operations that can be applied on entitlements with a given entitlement type.
        /// </summary>
        /// <param name="entitlementType">The type of entitlement.</param>
        /// <returns>The entitlement collection operations by entitlement type.</returns>
        IEntitlementCollectionByEntitlementType ByEntitlementType(string entitlementType);

        /// <summary>
        /// Gets the entitlements for a customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="showExpiry">A flag to indicate if the expiry date is required to be returned along with the entitlement (if applicable).</param>
        /// <returns>The collection of entitlements for the customer.</returns>
        Task<ResourceCollection<Entitlement>> GetAsync(bool showExpiry, CancellationToken cancellationToken = default);
    }
}