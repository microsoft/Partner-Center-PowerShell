// -----------------------------------------------------------------------
// <copyright file="PSAgreement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements
{
    using System;
    using Common;
    using PartnerCenter.Models.Agreements;

    /// <summary>
    /// The class represents an agreement object.
    /// </summary>
    public sealed class PSAgreement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreement" /> class.
        /// </summary>
        public PSAgreement()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAgreement" /> class.
        /// </summary>
        /// <param name="agreement">The base agreement for this instance.</param>
        public PSAgreement(Agreement agreement)
        {
            this.CopyFrom(agreement);
        }

        /// <summary>
        /// Gets or sets the download link for the agreement.
        /// </summary>
        public Uri AgreementLink { get; set; }

        /// <summary>
        /// Gets or sets the date the agreement was signed.
        /// </summary>
        public DateTime DateAgreed { get; set; }

        /// <summary>
        /// Gets or sets the primary contact for the agreement.
        /// </summary>
        public Contact PrimaryContact { get; set; }

        /// <summary>
        /// Gets or sets the template identifier of the agreement.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        ///  Gets or sets the agreement type.
        /// </summary>
        public AgreementType Type { get; set; }

        /// <summary>
        /// Gets or sets the partner's user identifier.
        /// </summary>
        public string UserId { get; set; }
    }
}