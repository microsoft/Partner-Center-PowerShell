// -----------------------------------------------------------------------
// <copyright file="SupportProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Partners
{
    /// <summary>
    /// Represents a partner's support profile.
    /// </summary>
    public sealed class SupportProfile : ResourceBaseWithLinks<StandardResourceLinks>
    {
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