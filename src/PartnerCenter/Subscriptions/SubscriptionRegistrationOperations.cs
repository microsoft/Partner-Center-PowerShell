// -----------------------------------------------------------------------
// <copyright file="SubscriptionRegistrationOperations.cs" company="Microsoft">
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

    /// <summary>
    /// This class implements the operations available on a customer's subscription registration.
    /// </summary>
    internal class SubscriptionRegistrationOperations : BasePartnerComponent<Tuple<string, string>>, ISubscriptionRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionRegistrationOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        public SubscriptionRegistrationOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Register a subscription to enable Azure Reserved instance purchase.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status.</returns>
        public string Register(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => RegisterAsync(cancellationToken));
        }

        /// <summary>
        /// Register a subscription to enable Azure Reserved instance purchase.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status.</returns>
        public async Task<string> RegisterAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.PostAsync<string, string>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateSubscriptionRegistrationStatus.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                null,
                cancellationToken).ConfigureAwait(false);
        }
    }
}