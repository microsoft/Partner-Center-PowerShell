// -----------------------------------------------------------------------
// <copyright file="PartnerProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    using System;

    /// <summary>
    /// Represents a profile structure with context and environments.
    /// </summary>
    public class PartnerProfile
    {
        /// <summary>
        /// Singleton instance of the <see cref="PartnerContext" /> class.
        /// </summary>
        private static readonly Lazy<PartnerProfile> instance = new Lazy<PartnerProfile>(() => new PartnerProfile());

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        public PartnerContext Context { get; set; }

        /// <summary>
        /// Gets an instance of the <see cref="PartnerProfile" /> class.
        /// </summary>
        public static PartnerProfile Instance => instance.Value;
    }
}