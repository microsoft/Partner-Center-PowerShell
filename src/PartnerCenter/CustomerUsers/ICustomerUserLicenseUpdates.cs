// -----------------------------------------------------------------------
// <copyright file="ICustomerUserLicenseUpdates.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System;
    using GenericOperations;
    using Models.Licenses;

    /// <summary>
    /// Represents the behavior of a customer user's license update collection.
    /// </summary>
    public interface ICustomerUserLicenseUpdates : IPartnerComponent<Tuple<string, string>>, IEntityCreateOperations<LicenseUpdate, LicenseUpdate>
    {
    }
}