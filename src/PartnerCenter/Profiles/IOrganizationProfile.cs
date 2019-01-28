// -----------------------------------------------------------------------
// <copyright file="IOrganizationProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using GenericOperations;
    using Models.Partners;

    /// <summary>
    /// Encapsulates the behavior of an organization profile.
    /// </summary>
    public interface IOrganizationProfile : IPartnerComponent<string>, IEntityGetOperations<OrganizationProfile>, IEntityUpdateOperations<OrganizationProfile, OrganizationProfile>
    {
    }
}