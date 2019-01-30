// -----------------------------------------------------------------------
// <copyright file="IPartnerUsageSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using GenericOperations;
    using Models.Usage;

    /// <summary>
    /// Defines the operations available on a partner's usage summary.
    /// </summary>
    public interface IPartnerUsageSummary : IPartnerComponent<string>, IEntityGetOperations<PartnerUsageSummary>
    {
    }
}