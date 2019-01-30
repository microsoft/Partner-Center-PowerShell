// -----------------------------------------------------------------------
// <copyright file="SubscriptionSupportContactOperations.cs" company="Microsoft">
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
    using Models.Subscriptions;

    /// <summary>
    /// This class implements the operations for a customer's subscription support contact.
    /// </summary>
    internal class SubscriptionSupportContactOperations : BasePartnerComponent<Tuple<string, string>>, ISubscriptionSupportContact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionSupportContactOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        public SubscriptionSupportContactOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Retrieves the support contact of the customer's subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The support contact.</returns>
        public SupportContact Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves the support contact of the customer's subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The support contact.</returns>
        public async Task<SupportContact> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<SupportContact>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscriptionSupportContact.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the support contact of the customer's subscription.
        /// </summary>
        /// <param name="supportContact">The support contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated support contact.</returns>
        public SupportContact Update(SupportContact entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => UpdateAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Updates the support contact of the customer's subscription.
        /// </summary>
        /// <param name="supportContact">The support contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated support contact.</returns>
        public async Task<SupportContact> UpdateAsync(SupportContact entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PutAsync<SupportContact, SupportContact>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateSubscriptionSupportContact.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
