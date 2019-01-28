// -----------------------------------------------------------------------
// <copyright file="IOrderProvisioningStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Orders;

    /// <summary>
    /// Holds operations that apply Order provisioning status.
    /// </summary>
    public interface IOrderProvisioningStatus : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<OrderLineItemProvisioningStatus, ResourceCollection<OrderLineItemProvisioningStatus>>
    {
    }
}
