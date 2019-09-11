// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements
{
    using Extensions;
    using PartnerCenter.Models.Agreements;

    /// <summary>
    /// Represents an agreement document that contains links to the content of an agreement template.
    /// </summary>
    public sealed class PSAgreementDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreementDocument" /> class.
        /// </summary>
        public PSAgreementDocument()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreementDocument" /> class.
        /// </summary>
        /// <param name="agreementDocument">The base agreement document for this instance.</param>
        public PSAgreementDocument(AgreementDocument agreementDocument)
        {
            this.CopyFrom(agreementDocument);
        }

        /// <summary>
        /// Gets or sets the country for the agreement document.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the link to preview the agreeement document.
        /// </summary>
        public string DisplayUri { get; set; }

        /// <summary>
        /// Gets or sets the link to download the agreement document.
        /// </summary>
        public string DownloadUri { get; set; }

        /// <summary>
        /// Gets or sets the localized langauge for the agreement document.
        /// </summary>
        public string Language { get; set; }
    }
}