// -----------------------------------------------------------------------
// <copyright file="ICart.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Carts
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models.Carts;

    /// <summary>
    /// Encapsulates a customer cart behavior.
    /// </summary>
    public interface ICart : IPartnerComponent<Tuple<string, string>>, IEntityPutOperations<Cart>, IEntityGetOperations<Cart>
    {
        /// <summary>
        /// Checks out the cart.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The cart checkout result.</returns>
        CartCheckoutResult Checkout(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks out the cart.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The cart checkout result.</returns>
        Task<CartCheckoutResult> CheckoutAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}