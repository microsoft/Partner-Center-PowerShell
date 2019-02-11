// -----------------------------------------------------------------------
// <copyright file="CartOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Carts
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Carts;

    /// <summary>
    /// Cart operations implementation class.
    /// </summary>
    internal class CartOperations : BasePartnerComponent<Tuple<string, string>>, ICart
    {
        /// <summary>
        /// Content used when checking out a cart.
        /// </summary>
        private const string Success = "success";

        /// <summary>
        /// Initializes a new instance of the <see cref="CartOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="cartId">The cart identifier.</param>
        public CartOperations(IPartner rootPartnerOperations, string customerId, string cartId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, cartId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            cartId.AssertNotEmpty(nameof(cartId));
        }

        /// <summary>
        /// Checks out the cart.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The cart checkout result.</returns>
        public CartCheckoutResult Checkout(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => CheckoutAsync(cancellationToken));
        }

        /// <summary>
        /// Checks out the cart.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The cart checkout result.</returns>
        public async Task<CartCheckoutResult> CheckoutAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.PostAsync<string, CartCheckoutResult>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.PlaceOrder.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                Success,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a customer cart.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Required cart object</returns>
        public Cart Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves a customer cart.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Required cart object</returns>
        public async Task<Cart> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<Cart>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCart.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an existing cart.
        /// </summary>
        /// <param name="entity">The cart to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated cart object.</returns>
        public Cart Put(Cart entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => PutAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Updates an existing cart.
        /// </summary>
        /// <param name="entity">The cart to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated cart object.</returns>
        public async Task<Cart> PutAsync(Cart entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PutAsync<Cart, Cart>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateCart.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}