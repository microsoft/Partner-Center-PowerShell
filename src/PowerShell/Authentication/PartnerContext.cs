// -----------------------------------------------------------------------
// <copyright file="PartnerContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    /// <summary>
    /// Context information used for the execution of various tasks.
    /// </summary>
    public class PartnerContext
    {
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public AzureAccount Account { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the type of authentication used to establish the session.
        /// </summary>
        public AuthenticationTypes AuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the ISO2 country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets the environment used for authentication.
        /// </summary>
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        public string Locale { get; set; }
    }
}