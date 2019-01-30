// -----------------------------------------------------------------------
// <copyright file="ILegalBusinessProfile.cs" company="Microsoft">
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
    /// Encapsulates behavior of a partner's legal business profile.
    /// </summary>
    public interface ILegalBusinessProfile : IPartnerComponent<string>, IEntityUpdateOperations<LegalBusinessProfile, LegalBusinessProfile>
    {
        /// <summary>
        /// Gets the legal business profile.
        /// </summary>
        /// <param name="vettingVersion">(Optional) The vetting version. The default value is set to Current.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The legal business profile.</returns>
        LegalBusinessProfile Get(VettingVersion vettingVersion = VettingVersion.Current, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the legal business profile.
        /// </summary>
        /// <param name="vettingVersion">(Optional) The vetting version. The default value is set to Current.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The legal business profile.</returns>
        Task<LegalBusinessProfile> GetAsync(VettingVersion vettingVersion = VettingVersion.Current, CancellationToken cancellationToken = default(CancellationToken));
    }
}
