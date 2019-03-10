// -----------------------------------------------------------------------
// <copyright file="EnvironmentName.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    /// <summary>
    /// Collection of names for the available instances of Microsoft Partner Center.
    /// </summary>
    public enum EnvironmentName
    {
        /// <summary>
        /// The global instance of Microsoft Partner Center.
        /// </summary>
        GlobalCloud,

        /// <summary>
        /// The Chinese sovereign cloud instance of Microsoft Partner Center.
        /// </summary>
        ChinaCloud,

        /// <summary>
        /// The German sovereign cloud instance of Microsoft Partner Center.
        /// </summary>
        GermanCloud,

        /// <summary>
        /// The pre-productions instance of Microsoft Partner Center.
        /// </summary>
        PPE,

        /// <summary>
        /// The US Government sovereign cloud instance of Microsoft Partner Center.
        /// </summary>
        USGovernment
    }
}