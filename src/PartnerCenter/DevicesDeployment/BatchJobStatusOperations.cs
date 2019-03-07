// -----------------------------------------------------------------------
// <copyright file="BatchJobStatusOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.DevicesDeployment;

    /// <summary>
    /// Implements operations that apply to devices batch upload status.
    /// </summary>
    internal class BatchJobStatusOperations : BasePartnerComponent<Tuple<string, string>>, IBatchJobStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchJobStatusOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="trackingId">The status tracking identifier.</param>
        public BatchJobStatusOperations(IPartner rootPartnerOperations, string customerId, string trackingId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, trackingId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            trackingId.AssertNotEmpty(nameof(trackingId));
        }

        /// <summary>
        /// Gets devices batch upload status of the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Devices batch upload status.</returns>
        public async Task<BatchUploadDetails> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<BatchUploadDetails>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetBatchUploadStatus.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}