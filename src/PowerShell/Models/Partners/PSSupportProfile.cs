// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Partners
{
    using Extensions;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Represents a partner's support profile.
    /// </summary>
    public sealed class PSSupportProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSupportProfile" /> class.
        /// </summary>
        public PSSupportProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSupportProfile" /> class.
        /// </summary>
        /// <param name="profile">The base support profile for this instance.</param>
        public PSSupportProfile(SupportProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        public string Website { get; set; }
    }
}