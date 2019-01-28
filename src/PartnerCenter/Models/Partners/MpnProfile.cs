// -----------------------------------------------------------------------
// <copyright file="MpnProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Partners
{
    /// <summary>
    /// Represents a partner's partner network profile.
    /// </summary>
    public sealed class MpnProfile : ResourceBaseWithLinks<StandardResourceLinks>
    {
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