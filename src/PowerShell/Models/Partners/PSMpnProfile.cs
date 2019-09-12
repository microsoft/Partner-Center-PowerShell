// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Partners
{
    using Extensions;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Represents a partner's Microsoft partner network profile.
    /// </summary>
    public sealed class PSMpnProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSMpnProfile" /> class.
        /// </summary>
        public PSMpnProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSMpnProfile" /> class.
        /// </summary>
        /// <param name="profile">The base MPN profile for this instance.</param>
        public PSMpnProfile(MpnProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the partner's Microsoft Partner Network identifier.
        /// </summary>
        public string MpnId { get; set; }

        /// <summary>
        /// Gets or sets the partner's organization name.
        /// </summary>
        public string PartnerName { get; set; }
    }
}