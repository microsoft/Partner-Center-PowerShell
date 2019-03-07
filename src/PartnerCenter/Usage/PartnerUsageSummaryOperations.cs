// -----------------------------------------------------------------------
// <copyright file="PartnerUsageSummaryOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Usage;

    /// <summary>
    /// This class implements the operations available on a partner's usage summary.
    /// </summary>
    internal class PartnerUsageSummaryOperations : BasePartnerComponent<string>, IPartnerUsageSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerUsageSummaryOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public PartnerUsageSummaryOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets the partner's usage summary.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner's usage summary.</returns>
        public async Task<PartnerUsageSummary> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<PartnerUsageSummary>(
               new Uri(
                   $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetPartnerUsageSummary.Path}",
                   UriKind.Relative),
               cancellationToken).ConfigureAwait(false);
        }
    }
}