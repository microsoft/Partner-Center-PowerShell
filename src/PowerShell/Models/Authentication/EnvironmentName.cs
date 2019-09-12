// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    /// <summary>
    /// Collection of names for the available instances of Microsoft Partner Center.
    /// </summary>
    public enum EnvironmentName
    {
        /// <summary>
        /// The global instance of Microsoft Partner Center.
        /// </summary>
        AzureCloud,

        /// <summary>
        /// The Chinese sovereign cloud instance of Microsoft Partner Center.
        /// </summary>
        AzureChinaCloud,

        /// <summary>
        /// The German sovereign cloud instance of Microsoft Partner Center.
        /// </summary>
        AzureGermanCloud,

        /// <summary>
        /// The pre-productions instance of Microsoft Partner Center.
        /// </summary>
        AzurePPE,

        /// <summary>
        /// The US Government sovereign cloud instance of Microsoft Partner Center.
        /// </summary>
        AzureUSGovernment
    }
}