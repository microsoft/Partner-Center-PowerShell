// -----------------------------------------------------------------------
// <copyright file="SubscriptionConversionCollectionOperations.cs" company="Microsoft">
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
    /// The customer subscription conversion implementation.
    /// </summary>
    internal class SubscriptionConversionCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ISubscriptionConversionCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionConversionCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier to whom the subscriptions belong.</param>
        /// <param name="subscriptionId">The subscription identifier where the upgrade is occurring.</param>
        public SubscriptionConversionCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Submits a subscription conversion.
        /// </summary>
        /// <param name="conversion">The new subscription conversion information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription conversion results.</returns>
        public ConversionResult Create(Conversion newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => CreateAsync(newEntity, cancellationToken));
        }

        /// <summary>
        /// Submits a subscription conversion.
        /// </summary>
        /// <param name="conversion">The new subscription conversion information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription conversion results.</returns>
        public async Task<ConversionResult> CreateAsync(Conversion newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<Conversion, ConversionResult>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.PostSubscriptionConversion.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all conversions for the trial subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription conversions.</returns>
        public ResourceCollection<Conversion> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all conversions for the trial subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscription conversions.</returns>
        public async Task<ResourceCollection<Conversion>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Conversion>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscriptionConversions.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<Conversion>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}