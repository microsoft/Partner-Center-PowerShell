// -----------------------------------------------------------------------
// <copyright file="ApplicationConsent.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ApplicationConsents
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an application consent associated with a customer.
    /// </summary>
    public sealed class ApplicationConsent
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ApplicationConsent" /> class.
        /// </summary>
        public ApplicationConsent()
        {
            ApplicationGrants = new List<ApplicationGrant>();
        }

        /// <summary>
        /// Gets the application grant associated with the application consent.
        /// </summary>
        public List<ApplicationGrant> ApplicationGrants { get; private set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the application.
        /// </summary>
        public string DisplayName { get; set; }
    }
}