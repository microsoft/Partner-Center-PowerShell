// -----------------------------------------------------------------------
// <copyright file="PartnerSubscriptionCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using GenericOperations;
    using Models;
    using Models.Subscriptions;

    /// <summary>
    /// Implements customer subscription operations grouped by a Microsoft partner.
    /// </summary>
    internal class PartnerSubscriptionCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Subscription, ResourceCollection<Subscription>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerSubscriptionCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="partnerId">The partner identifier.</param>
        public PartnerSubscriptionCollectionOperations(IPartner rootPartnerOperations, string customerId, string partnerId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, partnerId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            partnerId.AssertNotEmpty(nameof(partnerId));
        }

        /// <summary>
        /// Gets the subscriptions for the given partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner subscriptions.</returns>
        public ResourceCollection<Subscription> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the subscriptions for the given partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner subscriptions.</returns>
        public async Task<ResourceCollection<Subscription>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerSubscriptionsByPartner.Parameters.PartnerId,
                    Context.Item2
                }
            };

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Subscription>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSubscriptionsByPartner.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}