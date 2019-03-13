// -----------------------------------------------------------------------
// <copyright file="IEstimateLink.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;
    using Models;
    using Models.Invoices;

    /// <summary>
    /// Holds operations that can be performed on estimate link collection that belong to a given currency.
    /// </summary>
    public interface IEstimateLinkCollectionByCurrency : IPartnerComponent<string>, IEntityGetOperations<ResourceCollection<EstimateLink>>
    {
    }
}
