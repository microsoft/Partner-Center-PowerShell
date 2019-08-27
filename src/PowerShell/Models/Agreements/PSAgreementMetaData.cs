// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Agreements;

    /// <summary>
    /// This class represents the meta data about agreements.
    /// </summary>
    public sealed class PSAgreementMetaData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreementMetaData" /> class.
        /// </summary>
        public PSAgreementMetaData()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreementMetaData" /> class.
        /// </summary>
        /// <param name="agreementMetaData">The base agreement meta data for this instance.</param>
        public PSAgreementMetaData(AgreementMetaData agreementMetaData)
        {
            this.CopyFrom(agreementMetaData);
        }

        /// <summary>
        /// Gets or sets the download link for the agreement.
        /// </summary>
        public Uri AgreementLink { get; set; }

        /// <summary>
        /// Gets or sets the agreement type.
        /// </summary>
        public string AgreementType { get; set; }

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