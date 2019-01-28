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
        /// The Azure Active Directory authentication endpoint for the commercial cloud.
        /// </summary>
        public const string AzureActiveDirectoryEndpoint = "https://login.microsoftonline.com/";

        /// <summary>
        /// The Azure Active Directory authentication endpoint for the China cloud.
        /// </summary>
        public const string ChinaActiveDirectoryEndpoint = "https://login.chinacloudapi.cn/";

        /// <summary>
        /// The Azure Active Directory authentication endpoint for the German cloud.
        /// </summary>
        public const string GermanActiveDirectoryEndpoint = "https://login.microsoftonline.de/";

        /// <summary>
        /// The Azure Active Directory authentication endpoint for the US Goverment cloud.
        /// </summary>
        public const string USGovernmentActiveDirectoryEndpoint = "https://login.microsoftonline.us/";

        /// <summary>
        /// The Azure Active Directory Graph endpoint for the commercial cloud.
        /// </summary>
        public const string AzureGraphEndpoint = "https://graph.windows.net";

        /// <summary>
        /// The Azure Active Directory Graph endpoint for the China cloud.
        /// </summary>
        public const string ChinaGraphEndpoint = "https://graph.chinacloudapi.cn";

        /// <summary>
        /// The Azure Active Directory Graph endpoint for the German cloud.
        /// </summary>
        public const string GermanGraphEndpoint = "https://graph.cloudapi.de";

        /// <summary>
        /// The Azure Active Directory Graph endpoint for the US Goverment cloud.
        /// </summary>
        public const string USGovernmentGraphEndpoint = "https://graph.windows.net";

        /// <summary>
        /// The Partner Center endpoint address.
        /// </summary>
        public const string PartnerCenterEndpoint = "https://api.partnercenter.microsoft.com";

        /// <summary>
        /// The Partner Center endpoint for the China cloud.
        /// </summary>
        public const string ChinaPartnerCenterEndpoint = "https://partner.partnercenterapi.microsoftonline.cn";
    }
}