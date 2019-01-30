// -----------------------------------------------------------------------
// <copyright file="ICustomerAgreementCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Agreements
{
    using GenericOperations;
    using Models;
    using Models.Agreements;

    /// <summary>
    /// Defines the operations available on a partner-customer agreement.
    /// </summary>
    public interface ICustomerAgreementCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<Agreement, ResourceCollection<Agreement>>, IEntityCreateOperations<Agreement, Agreement>
    {
    }
}