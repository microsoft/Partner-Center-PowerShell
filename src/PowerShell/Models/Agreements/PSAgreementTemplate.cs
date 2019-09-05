// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements
{
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
            this.CopyFrom(agreementTemplate, CloneAdditionalOperations);
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

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="AgreementTemplate" /> to an instance of <see cref="PSAgreementTemplate" />. 
        /// </summary>
        /// <param name="item">The item being cloned.</param>
        private void CloneAdditionalOperations(AgreementTemplate item)
        {
            DisplayUri = item.DisplayUri.ToString();
            DownloadUri = item.DownloadUri.ToString();
        }
    }
}