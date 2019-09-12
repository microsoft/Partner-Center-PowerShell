// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using Extensions;

    /// <summary>
    /// Represents a partner environment.
    /// </summary>
    public sealed class PSPartnerEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerEnvironment" /> class.
        /// </summary>
        public PSPartnerEnvironment()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerEnvironment" /> class.
        /// </summary>
        /// <param name="environment">The base partner environment for this instance.</param>
        public PSPartnerEnvironment(PartnerEnvironment environment)
        {
            this.CopyFrom(environment);
        }

        /// <summary>
        /// Gets or sets the authentication endpoint.
        /// </summary>
        public string ActiveDirectoryAuthority { get; set; }

        /// <summary>
        /// Gets or sets the Azure AD Graph endpoint.
        /// </summary>
        public string AzureAdGraphEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the Partner Center endpoint.
        /// </summary>
        public string PartnerCenterEndpoint { get; set; }
    }
}