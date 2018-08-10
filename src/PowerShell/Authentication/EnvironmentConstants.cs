// -----------------------------------------------------------------------
// <copyright file="EnvironmentConstants.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    /// <summary>
    /// Known endpoint values for accessing cloud based resources.
    /// </summary>
    public static class EnvironmentConstants
    {
        /// <summary>
        /// The Azure Active Directory authentication endpoint
        /// </summary>
        public const string AzureActiveDirectoryEndpoint = "https://login.microsoftonline.com/";
        public const string ChinaActiveDirectoryEndpoint = "https://login.chinacloudapi.cn/";
        public const string GermanActiveDirectoryEndpoint = "https://login.microsoftonline.de/";
        public const string USGovernmentActiveDirectoryEndpoint = "https://login.microsoftonline.us/";

        /// <summary>
        /// The Azure Active Directory Graph endpoint
        /// </summary>
        public const string AzureGraphEndpoint = "https://graph.windows.net/";
        public const string ChinaGraphEndpoint = "https://graph.chinacloudapi.cn/";
        public const string GermanGraphEndpoint = "https://graph.cloudapi.de/";
        public const string USGovernmentGraphEndpoint = "https://graph.windows.net/";

        /// <summary>
        /// The Partner Center endpoint
        /// </summary>
        public const string PartnerCenterEndpoint = "https://api.partnercenter.microsoft.com";
    }
}