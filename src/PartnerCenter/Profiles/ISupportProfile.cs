// -----------------------------------------------------------------------
// <copyright file="ISupportProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using GenericOperations;
    using Models.Partners;

    /// <summary>
    /// Encapsulates behavior of a support profile.
    /// </summary>
    public interface ISupportProfile : IPartnerComponent<string>, IEntityGetOperations<SupportProfile>, IEntityUpdateOperations<SupportProfile, SupportProfile>
    {
    }
}