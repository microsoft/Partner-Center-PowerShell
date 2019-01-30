// -----------------------------------------------------------------------
// <copyright file="SkuDownloadOptions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    /// <summary>
    /// Class that represents a SKU download option.
    /// </summary>
    public class SkuDownloadOptions
    {
        /// <summary>
        /// Gets or sets the option key.
        /// </summary>
        public string OptionKey { get; set; }

        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        public string OptionTitle { get; set; }

        /// <summary>
        /// Gets or sets the display rank.
        /// </summary>
        public int DisplayRank { get; set; }

        /// <summary>
        /// Gets or sets the CPU and file type.
        /// </summary>
        public string CPUandFileType { get; set; }

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Gets or sets the language display name.
        /// </summary>
        public string LanguageName { get; set; }

        /// <summary>
        /// Gets or sets the file size in bytes.
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// Gets or sets the SKU download link.
        /// </summary>
        public Link DownloadLink { get; set; }
    }
}