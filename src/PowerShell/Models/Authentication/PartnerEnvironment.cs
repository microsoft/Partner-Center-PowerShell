// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// A record of metadata necessary to manage assets in a specific cloud, including necessary endpoints,
    /// location of service-specific endpoints, and information for bootstrapping authentication
    /// </summary>
    public class PartnerEnvironment
    {
        /// <summary>
        /// Gets or sets the authentication endpoint.
        /// </summary>
        public string ActiveDirectoryAuthority { get; set; }

        /// <summary>
        /// Gets or sets the Azure AD Graph endpoint.
        /// </summary>
        public string AzureAdGraphEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the partner environment name.
        /// </summary>
        public EnvironmentName EnvironmentName { get; set; }

        /// <summary>
        /// Gets the Partner Center endpoint.
        /// </summary>
        public string PartnerCenterEndpoint { get; set; }

        /// <summary>
        /// Gets the defined Microsoft Partner Center environments.
        /// </summary>
        public static IDictionary<EnvironmentName, PartnerEnvironment> PublicEnvironments { get; } = InitializeEnvironments();

        /// <summary>
        /// Initializes a list of known environments.
        /// </summary>
        /// <returns>A dictionary containing the known environments.</returns>
        private static IDictionary<EnvironmentName, PartnerEnvironment> InitializeEnvironments()
        {
            return new ConcurrentDictionary<EnvironmentName, PartnerEnvironment>
            {
                [EnvironmentName.AzureCloud] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.AzureActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.AzureGraphEndpoint,
                    EnvironmentName = EnvironmentName.AzureCloud,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterEndpoint,
                },

                [EnvironmentName.AzureChinaCloud] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.ChinaActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.ChinaGraphEndpoint,
                    EnvironmentName = EnvironmentName.AzureChinaCloud,
                    PartnerCenterEndpoint = EnvironmentConstants.ChinaPartnerCenterEndpoint,
                },

                [EnvironmentName.AzureGermanCloud] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.GermanActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.GermanGraphEndpoint,
                    EnvironmentName = EnvironmentName.AzureGermanCloud,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterEndpoint,
                },

                [EnvironmentName.AzurePPE] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.AzureActiveDirectoryPpeEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.AzureGraphPpeEndpoint,
                    EnvironmentName = EnvironmentName.AzurePPE,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterPpeEndpoint,
                },

                [EnvironmentName.AzureUSGovernment] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.USGovernmentActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.USGovernmentGraphEndpoint,
                    EnvironmentName = EnvironmentName.AzureUSGovernment,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterEndpoint,
                }
            };
        }
    }
}