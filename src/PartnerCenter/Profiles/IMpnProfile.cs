// -----------------------------------------------------------------------
// <copyright file="IMpnProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models.Partners;

    /// <summary>
    /// Encapsulates behavior of a partner's MPN profile.
    /// </summary>
    public interface IMpnProfile : IPartnerComponent<string>, IEntityGetOperations<MpnProfile>
    {
        /// <summary>
        /// Retrieves a partner's MPN profile by identifier.
        /// </summary>
        /// <param name="mpnId">The MPN identifier.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner's MPN profile.</returns>
        MpnProfile Get(string mpnId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves a partner's MPN profile by identifier.
        /// </summary>
        /// <param name="mpnId">The MPN identifier.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner's MPN profile.</returns>
        Task<MpnProfile> GetAsync(string mpnId, CancellationToken cancellationToken = default(CancellationToken));
    }
}