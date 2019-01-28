// -----------------------------------------------------------------------
// <copyright file="AgreementMetaData.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Agreements
{
    using System;

    /// <summary>
    /// This class represents the meta data about agreements.
    /// </summary>
    public sealed class AgreementMetaData
    {
        /// <summary>
        /// Gets or sets the download link for the agreement.
        /// </summary>
        public Uri AgreementLink { get; set; }

        /// <summary>
        /// Gets or sets the agreement type.
        /// </summary>
        public AgreementType AgreementType { get; set; }

        /// <summary>
        /// Gets or sets the template identifier for the agreement.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the ranking for the version for enforcement.
        /// </summary>
        public int VersionRank { get; set; }
    }
}