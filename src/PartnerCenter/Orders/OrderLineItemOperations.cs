// -----------------------------------------------------------------------
// <copyright file="OrderLineItemOperations.cs" company="Microsoft">
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
    internal class OrderLineItemOperations : BasePartnerComponent<Tuple<string, string, int>>, IOrderLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="lineItemNumber">The line item number</param>
        public OrderLineItemOperations(IPartner rootPartnerOperations, string customerId, string orderId, int lineItemNumber)
            : base(rootPartnerOperations, new Tuple<string, string, int>(customerId, orderId, lineItemNumber))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));
            lineItemNumber.AssertNotNull(nameof(lineItemNumber));
        }

        /// <summary>
        /// Gets the available customer order line item activation link operations.
        /// </summary>
        public IOrderLineItemActivationLink ActivationLink => new OrderLineItemActivationLinkOperations(Partner, Context.Item1, Context.Item2, Context.Item3);
    }
}
