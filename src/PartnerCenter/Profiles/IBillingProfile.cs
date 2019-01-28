// -----------------------------------------------------------------------
// <copyright file="IBillingProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using GenericOperations;
    using Models.Partners;

    /// <summary>
    /// Encapsulates behavior of a billing profile.
    /// </summary>
    public interface IBillingProfile : IPartnerComponent<string>, IEntityGetOperations<BillingProfile>, IEntityUpdateOperations<BillingProfile, BillingProfile>
    {
    }
}
