// -----------------------------------------------------------------------
// <copyright file="ICartCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Carts
{
    using GenericOperations;
    using Models.Carts;

    /// <summary>
    /// Encapsulates a customer cart behavior.
    /// </summary>
    public interface ICartCollection : IPartnerComponent<string>, IEntityCreateOperations<Cart, Cart>, IEntitySelector<ICart>
    {
    }
}
