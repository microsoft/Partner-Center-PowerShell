// -----------------------------------------------------------------------
// <copyright file="IEntitlementCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Entitlements
{
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
        /// <param name="entitlementType">The type of entiltment.</param>
        /// <returns>The entitlement collection operations by entitlement type.</returns>
        IEntireEntityCollectionRetrievalOperations<Entitlement, ResourceCollection<Entitlement>> ByEntitlementType(string entitlementType);
    }
}