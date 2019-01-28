// -----------------------------------------------------------------------
// <copyright file="IAgreementDetailsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Agreements
{
    using GenericOperations;
    using Models;
    using Models.Agreements;

    /// <summary>
    /// This interface represents the agreement details behavior.
    /// </summary>
    public interface IAgreementDetailsCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<AgreementMetaData, ResourceCollection<AgreementMetaData>>
    {
    }
}