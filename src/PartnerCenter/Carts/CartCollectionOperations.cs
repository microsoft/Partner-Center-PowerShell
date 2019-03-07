// -----------------------------------------------------------------------
// <copyright file="CartCollectionOperations.cs" company="Microsoft">
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
    /// Cart collection operations implementation class.
    /// </summary>
    internal class CartCollectionOperations : BasePartnerComponent<string>, ICartCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CartCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a specific cart behavior.
        /// </summary>
        /// <param name="id">The cart identifier.</param>
        /// <returns>The cart operations.</returns>
        public ICart this[string id] => ById(id);

        /// <summary>
        /// Gets a specific cart behavior.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns>The cart operations.</returns>
        public ICart ById(string id)
        {
            return new CartOperations(Partner, Context, id);
        }

        /// <summary>
        /// Creates a new cart for the customer.
        /// </summary>
        /// <param name="newCart"> A cart item to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A cart object </returns>
        public async Task<Cart> CreateAsync(Cart newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<Cart, Cart>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateCart.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}