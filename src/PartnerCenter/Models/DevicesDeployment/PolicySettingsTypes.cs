// -----------------------------------------------------------------------
// <copyright file="PolicySettingsTypes.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System;
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the settings for an OOBE(Out of box experience) policy
    /// </summary>
    [Flags]
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum PolicySettingsTypes
    {
        /// <summary>
        /// Default value for policy settings.
        /// </summary>
        None = 0,

        /// <summary>
        /// Remove OEM Pre-installs.
        /// </summary>
        RemoveOemPreinstalls = 1,

        /// <summary>
        /// OOBE(Out of box experience) user will not be a local admin on the configured device.
        /// </summary>
        OobeUserNotLocalAdmin = 2,

        /// <summary>
        /// Skip express settings.
        /// </summary>
        SkipExpressSettings = 4,

        /// <summary>
        /// Skip OEM registration settings.
        /// </summary>
        SkipOemRegistration = 8,

        /// <summary>
        /// Skip EULA settings.
        /// </summary>
        SkipEula = 16
    }
}
