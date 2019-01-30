// -----------------------------------------------------------------------
// <copyright file="ICustomerRelationshipCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Relationships
{
    using GenericOperations;
    using Models;
    using Models.Relationships;

    /// <summary>
    /// This is for indirect scenarios, holds the operations for retrieving partner relationships of a customer with respect to
    /// the logged in partner.
    /// </summary>
    public interface ICustomerRelationshipCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<PartnerRelationship, ResourceCollection<PartnerRelationship>>
    {
    }
}