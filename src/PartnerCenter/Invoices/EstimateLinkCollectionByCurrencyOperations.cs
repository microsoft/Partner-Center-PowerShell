// -----------------------------------------------------------------------
// <copyright file="EstimateLinkCollectionByCurrencyOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.Invoices;
    using Models.JsonConverters;

    /// <summary>
    /// Represents the operations available on an estimate link collection by currency.
    /// </summary>
    internal class EstimateLinkCollectionByCurrencyOperations : BasePartnerComponent<string>, IEstimateLinkCollectionByCurrency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateLinkCollectionByCurrencyOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="currencyCode">The currency code.</param>
        public EstimateLinkCollectionByCurrencyOperations(IPartner rootPartnerOperations, string currencyCode)
            : base(rootPartnerOperations, currencyCode)
        {
            currencyCode.AssertNotEmpty(nameof(currencyCode));
        }

        /// <summary>
        /// Retrieves the estimate link resource collection.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The estimate link resource collection.</returns>
        public async Task<ResourceCollection<EstimateLink>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<EstimateLink>>(
               new Uri(
                   string.Format(
                       CultureInfo.InvariantCulture,
                       $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetEstimatesLinks.Path}",
                       Context),
                   UriKind.Relative),
                new ResourceCollectionConverter<EstimateLink>(),
               cancellationToken).ConfigureAwait(false);
        }
    }
}