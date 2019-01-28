// -----------------------------------------------------------------------
// <copyright file="IPartnerServiceRequestCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models.ServiceRequests;

    /// <summary>
    /// Represents the behavior of partner service requests.
    /// </summary>
    public interface IPartnerServiceRequestCollection : IServiceRequestCollection
    {
        /// <summary>
        /// Gets a set of operations that can be performed on Support Topics.
        /// </summary>
        /// <returns>Support topic operations.</returns>
        ISupportTopicsCollection SupportTopics { get; }

        /// <summary>Creates a new service request.</summary>
        /// <param name="serviceRequest">The new service request information.</param>
        /// <param name="agentLocale">The agent locale.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service request information that was just created.</returns>
        ServiceRequest Create(ServiceRequest serviceRequest, string agentLocale, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Creates a new service request.</summary>
        /// <param name="serviceRequest">The new service request  information.</param>
        /// <param name="agentLocale">The agent locale.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service request information that was just created.</returns>
        Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest, string agentLocale, CancellationToken cancellationToken = default(CancellationToken));
    }
}
