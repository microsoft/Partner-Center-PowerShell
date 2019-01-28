// -----------------------------------------------------------------------
// <copyright file="CustomerUser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Users
{
    /// <summary>Entity to define customer user</summary>
    public sealed class CustomerUser : User
    {
        /// <summary>
        /// Gets or sets usage location, the location where user intends to use the license.
        /// </summary>
        public string UsageLocation { get; set; }
    }
}