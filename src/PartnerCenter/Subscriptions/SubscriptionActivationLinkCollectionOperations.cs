// -----------------------------------------------------------------------
// <copyright file="SubscriptionActivationLinkCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Orders;

    /// <summary>
    /// Implements getting customer subscription activation link resource collection for a given subscription.
    /// </summary>
    internal class SubscriptionActivationLinkCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ISubscriptionActivationLinkCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionActivationLinks"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        public SubscriptionActivationLinkCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
            : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Gets the subscription activation links.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription activation links.</returns>
        public async Task<ResourceCollection<OrderLineItemActivationLink>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<OrderLineItemActivationLink>>(
               new Uri(
                   string.Format(
                       CultureInfo.InvariantCulture,
                       $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscriptionActivationLink.Path}",
                       Context.Item1,
                       Context.Item2),
                   UriKind.Relative),
                new ResourceCollectionConverter<OrderLineItemActivationLink>(),
               cancellationToken).ConfigureAwait(false);
        }
    }
}
