// -----------------------------------------------------------------------
// <copyright file="ICustomerRelationshipRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RelationshipRequests
{
    using GenericOperations;
    using Models.RelationshipRequests;

    /// <summary>
    /// Holds operations that apply to customer relationship requests.
    /// </summary>
    public interface ICustomerRelationshipRequest : IPartnerComponent<string>, IEntityGetOperations<CustomerRelationshipRequest>
    {
    }
}