// -----------------------------------------------------------------------
// <copyright file="ISubscriptionConversionCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Subscriptions;

    /// <summary>
    /// This interface defines the conversion operations available on a customer's trial subscription.
    /// </summary>
    public interface ISubscriptionConversionCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Conversion, ResourceCollection<Conversion>>, IEntityCreateOperations<Conversion, ConversionResult>
    {
    }
}