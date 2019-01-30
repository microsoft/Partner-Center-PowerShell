// -----------------------------------------------------------------------
// <copyright file="SubscriptionUpgradeCollectionOperations.cs" company="Microsoft">
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
    using Models.Subscriptions;

    /// <summary>
    /// The customer subscription upgrade implementation.
    /// </summary>
    internal class SubscriptionUpgradeCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ISubscriptionUpgradeCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionUpgradeCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        public SubscriptionUpgradeCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Performs a subscription upgrade.
        /// </summary>
        /// <param name="subscriptionUpgrade">The subscription upgrade to perform.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription upgrade result.</returns>
        public UpgradeResult Create(Upgrade newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => CreateAsync(newEntity, cancellationToken));
        }

        /// <summary>
        /// Performs a subscription upgrade.
        /// </summary>
        /// <param name="subscriptionUpgrade">The subscription upgrade to perform.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription upgrade result.</returns>
        public async Task<UpgradeResult> CreateAsync(Upgrade newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<Upgrade, UpgradeResult>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.PostSubscriptionUpgrade.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all subscription upgrades.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription upgrades.</returns>
        public ResourceCollection<Upgrade> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all subscription upgrades.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription upgrades.</returns>
        public async Task<ResourceCollection<Upgrade>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Upgrade>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscriptionUpgrades.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<Upgrade>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}