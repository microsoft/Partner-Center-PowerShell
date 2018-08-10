// -----------------------------------------------------------------------
// <copyright file="PartnerContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    using System;

    /// <summary>
    /// Partner and user details used by the Partner Center cmdlets.
    /// </summary>
    [Serializable]
    public class PartnerContext
    {
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the ISO2 country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or set the envrionment.
        /// </summary>
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets the locale of the authenicated user.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Username { get; set; }
    }
}