// -----------------------------------------------------------------------
// <copyright file="OrderLineItemActivationLinkOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.Orders;

    /// <summary>
    /// Implements the customer order line item activation link operations.
    /// </summary>
    internal class OrderLineItemActivationLinkOperations : BasePartnerComponent<Tuple<string, string, int>>, IOrderLineItemActivationLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemActivationLinkOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="lineItemNumber">The line item number.</param>
        public OrderLineItemActivationLinkOperations(IPartner rootPartnerOperations, string customerId, string orderId, int lineItemNumber)
            : base(rootPartnerOperations, new Tuple<string, string, int>(customerId, orderId, lineItemNumber))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));
            lineItemNumber.AssertNotNull(nameof(lineItemNumber));
        }

        /// <summary>
        /// Retrieves the order line item activation link collection.
        /// </summary>
        /// <returns>The order line item activation link collection.</returns>
        public async Task<ResourceCollection<OrderLineItemActivationLink>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<OrderLineItemActivationLink>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetActivationLinksByLineItemNumber.Path}",
                        Context.Item1,
                        Context.Item2, 
                        Context.Item3),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
