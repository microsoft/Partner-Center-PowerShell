// -----------------------------------------------------------------------
// <copyright file="IOrderLineItemCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using Extensions;

    /// <summary>
    /// Implements the available order line item operations.
    /// </summary>
    internal class OrderLineItemCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IOrderLineItemCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemCollectionOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        public OrderLineItemCollectionOperations(IPartner rootPartnerOperations, string customerId, string orderId)
            : base(rootPartnerOperations, new Tuple<string, string>(customerId, orderId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));
        }

        /// <summary>
        /// Gets the order line item operations.
        /// </summary>
        /// <param name="id">The order line item number.</param>
        /// <returns>The order line item operations.</returns>
        public IOrderLineItem this[int id] => ById(id);

        /// <summary>
        /// Gets the order line item operations.
        /// </summary>
        /// <param name="id">The order line item number.</param>
        /// <returns>The order line item operations.</returns>
        public IOrderLineItem ById(int id) => new OrderLineItemOperations(Partner, Context.Item1, Context.Item2, id);
    }
}