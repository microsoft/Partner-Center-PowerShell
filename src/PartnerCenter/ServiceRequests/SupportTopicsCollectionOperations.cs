// -----------------------------------------------------------------------
// <copyright file="SupportTopicsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.JsonConverters;
    using Models.ServiceRequests;

    /// <summary>
    /// The operations that can be performed on support topics. Support Topics operations are localizable.
    /// </summary>
    internal class SupportTopicsCollectionOperations : BasePartnerComponent<string>, ISupportTopicsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupportTopicsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public SupportTopicsCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets a collection of available support topics to create service request.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of support topics.</returns>
        public ResourceCollection<SupportTopic> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets a collection of available support topics to create service request.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of support topics.</returns>
        public async Task<ResourceCollection<SupportTopic>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<SupportTopic>>(
                new Uri(
                  $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetServiceRequestSupportTopics.Path}",
                  UriKind.Relative),
                new ResourceCollectionConverter<SupportTopic>(), 
                cancellationToken).ConfigureAwait(false);
        }
    }
}
