// -----------------------------------------------------------------------
// <copyright file="SubscriptionOperations.cs" company="Microsoft">
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
    using Usage;
    using Utilization;

    /// <summary>
    /// This class implements the operations for a customer's subscription.
    /// </summary>
    internal class SubscriptionOperations : BasePartnerComponent<Tuple<string, string>>, ISubscription
    {
        /// <summary>
        /// A lazy reference to the current subscription's add-ons operations.
        /// </summary>
        private readonly Lazy<ISubscriptionAddOnCollection> subscriptionAddOnsOperations;

        /// <summary>
        /// A lazy reference to the current subscription's conversion operations.
        /// </summary>
        private readonly Lazy<ISubscriptionConversionCollection> subscriptionConversionOperations;

        /// <summary>
        /// A lazy reference to the current subscription's provisioning status operations.
        /// </summary>
        private readonly Lazy<ISubscriptionProvisioningStatus> subscriptionProvisioningStatusOperations;

        /// <summary>
        /// A lazy reference to the current subscription's support contact operations.
        /// </summary>
        private readonly Lazy<ISubscriptionSupportContact> subscriptionSupportContactOperations;

        /// <summary>
        /// A lazy reference to the current subscription's registration operations.
        /// </summary>
        private readonly Lazy<ISubscriptionRegistration> subscriptionRegistrationOperations;

        /// <summary>
        /// A lazy reference to the current subscription's registration status operations.
        /// </summary>
        private readonly Lazy<ISubscriptionRegistrationStatus> subscriptionRegistrationStatusOperations;

        /// <summary>
        /// A lazy reference to the current subscription's upgrade operations.
        /// </summary>
        private readonly Lazy<ISubscriptionUpgradeCollection> subscriptionUpgradeOperations;

        /// <summary>
        /// A lazy reference to the current subscription's usage summary operations.
        /// </summary>
        private readonly Lazy<ISubscriptionUsageSummary> subscriptionUsageSummaryOperations;

        /// <summary>
        /// A lazy reference to the current subscription's resource usage records operations.
        /// </summary>
        private readonly Lazy<ISubscriptionUsageRecordCollection> usageRecordsOperations;

        /// <summary>
        /// A lazy reference to the current subscription's utilities operations.
        /// </summary>
        private readonly Lazy<IUtilizationCollection> subscriptionUtilizationOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <param name="subscriptionId">Identifier for the subscription.</param>
        public SubscriptionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
            : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));

            subscriptionAddOnsOperations = new Lazy<ISubscriptionAddOnCollection>(
                () => new SubscriptionAddOnCollectionOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionConversionOperations = new Lazy<ISubscriptionConversionCollection>(
                () => new SubscriptionConversionCollectionOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionProvisioningStatusOperations = new Lazy<ISubscriptionProvisioningStatus>(
                () => new SubscriptionProvisioningStatusOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionRegistrationOperations = new Lazy<ISubscriptionRegistration>(
                () => new SubscriptionRegistrationOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionRegistrationStatusOperations = new Lazy<ISubscriptionRegistrationStatus>(
                () => new SubscriptionRegistrationStatusOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionSupportContactOperations = new Lazy<ISubscriptionSupportContact>(
                () => new SubscriptionSupportContactOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionUpgradeOperations = new Lazy<ISubscriptionUpgradeCollection>(
                () => new SubscriptionUpgradeCollectionOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionUsageSummaryOperations = new Lazy<ISubscriptionUsageSummary>(
                () => new SubscriptionUsageSummaryOperations(rootPartnerOperations, customerId, subscriptionId));
            subscriptionUtilizationOperations = new Lazy<IUtilizationCollection>(
                () => new UtilizationCollectionOperations(rootPartnerOperations, customerId, subscriptionId));
            usageRecordsOperations = new Lazy<ISubscriptionUsageRecordCollection>(
                () => new SubscriptionUsageRecordCollectionOperations(rootPartnerOperations, customerId, subscriptionId));
        }

        /// <summary>
        /// Gets the current subscription's add-ons operations.
        /// </summary>
        public ISubscriptionAddOnCollection AddOns => subscriptionAddOnsOperations.Value;

        /// <summary>
        /// Gets the current subscription's conversion operations. These operations will only apply to trial subscriptions.
        /// </summary>
        public ISubscriptionConversionCollection Conversions => subscriptionConversionOperations.Value;

        /// <summary>
        /// Gets the current subscription's provisioning status operations.
        /// </summary>
        public ISubscriptionProvisioningStatus ProvisioningStatus => subscriptionProvisioningStatusOperations.Value;

        /// <summary>
        /// Gets the current subscription's registration operations.
        /// </summary>
        public ISubscriptionRegistration Registration => subscriptionRegistrationOperations.Value;

        /// <summary>
        /// Gets the current subscription's registration status operations.
        /// </summary>
        public ISubscriptionRegistrationStatus RegistrationStatus => subscriptionRegistrationStatusOperations.Value;

        /// <summary>
        /// Gets the current subscription's support contact operations.
        /// </summary>
        public ISubscriptionSupportContact SupportContact => subscriptionSupportContactOperations.Value;

        /// <summary>
        /// Gets the current subscription's upgrade operations.
        /// </summary>
        public ISubscriptionUpgradeCollection Upgrades => subscriptionUpgradeOperations.Value;

        /// <summary>
        /// Gets the current subscription's resource usage records operations.
        /// </summary>
        public ISubscriptionUsageRecordCollection UsageRecords => usageRecordsOperations.Value;

        /// <summary>
        /// Gets the current subscription's usage summary operations.
        /// </summary>
        public ISubscriptionUsageSummary UsageSummary => subscriptionUsageSummaryOperations.Value;

        /// <summary>
        /// Gets the subscription utilization operations.
        /// </summary>
        public IUtilizationCollection Utilization => subscriptionUtilizationOperations.Value;

        /// <summary>
        /// Gets the subscription innformation.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Information for the specified subscription.</returns>
        public async Task<Subscription> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<Subscription>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscription.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Patches a subscription.
        /// </summary>
        /// <param name="entity">The subscription information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated subscription information.</returns>
        public async Task<Subscription> PatchAsync(Subscription entity, CancellationToken cancellationToken = default)
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<Subscription, Subscription>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateSubscription.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
