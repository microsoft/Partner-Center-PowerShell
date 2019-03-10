// -----------------------------------------------------------------------
// <copyright file="PartnerEnvironment.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
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
                [EnvironmentName.GlobalCloud] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.AzureActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.AzureGraphEndpoint,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterEndpoint,
                },

                [EnvironmentName.ChinaCloud] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.ChinaActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.ChinaGraphEndpoint,
                    PartnerCenterEndpoint = EnvironmentConstants.ChinaPartnerCenterEndpoint,
                },

                [EnvironmentName.PPE] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.AzureActiveDirectoryPpeEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.AzureGraphPpeEndpoint,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterPpeEndpoint,
                },

                [EnvironmentName.USGovernment] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.USGovernmentActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.USGovernmentGraphEndpoint,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterEndpoint,
                },

                [EnvironmentName.GermanCloud] = new PartnerEnvironment
                {
                    ActiveDirectoryAuthority = EnvironmentConstants.GermanActiveDirectoryEndpoint,
                    AzureAdGraphEndpoint = EnvironmentConstants.GermanGraphEndpoint,
                    PartnerCenterEndpoint = EnvironmentConstants.PartnerCenterEndpoint,
                }
            };
        }
    }
}