// -----------------------------------------------------------------------
// <copyright file="ApplicationGrant.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ApplicationConsents
{
    /// <summary>
    /// Represents an application grant associated with an application consent.
    /// </summary>
    public sealed class ApplicationGrant
    {
        /// <summary>
        /// Gets or sets the enterprise application identifier.
        /// </summary>
        /// <remarks>
        /// This is the identifier of the application in Azure AD. 
        /// </remarks>
        public string EnterpriseApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the a scopes configured for the application grant. 
        /// </summary>
        /// <remarks>
        /// This is a comma delimited string that represents the scopes for this application grant.
        /// </remarks>
        public string Scope { get; set; }
    }
}