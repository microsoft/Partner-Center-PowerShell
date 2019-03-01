// -----------------------------------------------------------------------
// <copyright file="OfferAddOnsOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Implements offer add-ons behavior.
    /// </summary>
    internal class OfferAddOnsOperations : BasePartnerComponent<Tuple<string, string>>, IOfferAddOns
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferAddOnsOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="offerId">The offer Id to get its add on offers.</param>
        /// <param name="country">The country on which to base the offer add-ons.</param>
        public OfferAddOnsOperations(IPartner rootPartnerOperations, string offerId, string country)
          : base(rootPartnerOperations, new Tuple<string, string>(offerId, country))
        {
        }

        /// <summary>
        /// Retrieves the add-ons for the given offer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The offer add-ons.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetOfferAddons.Parameters.Country,
                        Context.Item2
                    }
                };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOfferAddons.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a subset of offers  for the provided country.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of offers to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested segment of the offers for the provided country.</returns>
        public async Task<ResourceCollection<Offer>> GetAsync(int offset, int size, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOfferAddons.Parameters.Country,
                    Context.Item2
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetOfferAddons.Parameters.Offset,
                    offset.ToString(CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetOfferAddons.Parameters.Size,
                    size.ToString(CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Offer>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOfferAddons.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);

        }
    }
}