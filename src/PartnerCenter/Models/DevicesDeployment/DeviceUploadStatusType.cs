// -----------------------------------------------------------------------
// <copyright file="DeviceUploadDetails.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Devices Batch upload status.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum DeviceUploadStatusType
    {
        /// <summary>
        /// Should never happen.
        /// </summary>
        Unknown,

        /// <summary>
        /// Batch is queued.
        /// </summary>
        Queued,

        /// <summary>
        /// Batch is processing.
        /// </summary>
        Processing,

        /// <summary>
        /// Batch is complete.
        /// </summary>
        Finished,

        /// <summary>
        /// Batch is complete with an error.
        /// </summary>
        FinishedWithErrors,
    }
}