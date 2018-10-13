// -----------------------------------------------------------------------
// <copyright file="PartnerContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Profile
{
    using System.Management.Automation;

    /// <summary>
    /// Context information used for the execution of various tasks.
    /// </summary>
    public class PartnerContext
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the type of account.
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the ISO2 country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the credentials.
        /// </summary>
        public PSCredential Credentials { get; set; }

        /// <summary>
        /// Gets the environment used for authentication.
        /// </summary>
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the Azure AD tenant identifier.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets  the username.
        /// </summary>
        public string Username { get; set; }
    }
}