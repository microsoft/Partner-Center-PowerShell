// -----------------------------------------------------------------------
// <copyright file="DeviceCodeResult.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Authentication
{
    using System;

    /// <summary>
    /// This class represents the response from the service when requesting device code.
    /// </summary>
    public sealed class DeviceCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCodeResult" /> class.
        /// </summary>
        internal DeviceCodeResult()
        {
        }

        /// <summary>
        /// Gets the identifier of the client requesting device code.
        /// </summary>
        public string ClientId { get; internal set; }

        /// <summary>
        /// Gets the device code returned by the service.
        /// </summary>
        public string DeviceCode { get; internal set; }

        /// <summary>
        /// Gets the time when the device code will expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; internal set; }

        /// <summary>
        /// Gets the polling interval time to check for completion of authentication flow.
        /// </summary>
        public long Interval { get; internal set; }

        /// <summary>
        /// Gets the user friendly text response that can be used for display purpose.
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// Gets the identifier of the target resource that would be the recipient of the token.
        /// </summary>
        public string Resource { get; internal set; }

        /// <summary>
        /// Gets the user code returned by the service.
        /// </summary>
        public string UserCode { get; internal set; }

        /// <summary>
        /// Verification URL where the user must navigate to authenticate using the device code and credentials.
        /// </summary>
        public Uri VerificationUrl { get; internal set; }
    }
}
