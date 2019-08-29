// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Agreements;

    /// <summary>
    /// Represents an agreement template that can be downloaded or viewed.
    /// </summary>
    public sealed class PSAgreementTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreementTemplate" /> class.
        /// </summary>
        public PSAgreementTemplate()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreementTemplate" /> class.
        /// </summary>
        /// <param name="agreementTemplate">The base agreement template for this instance.</param>
        public PSAgreementTemplate(AgreementTemplate agreementTemplate)
        {
            this.CopyFrom(agreementTemplate);
        }

        /// <summary>
        /// Gets or sets the country for the agreement document.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the link to preview the agreeement document.
        /// </summary>
        public Uri DisplayUri { get; set; }

        /// <summary>
        /// Gets or sets the link to download the agreement document.
        /// </summary>
        public Uri DownloadUri { get; set; }

        /// <summary>
        /// Gets or sets the localized langauge for the agreement document.
        /// </summary>
        public string Language { get; set; }
    }
}