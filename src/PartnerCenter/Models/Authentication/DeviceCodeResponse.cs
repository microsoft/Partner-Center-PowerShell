// -----------------------------------------------------------------------
// <copyright file="DeviceCodeResponse.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Authentication
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The class that represents a response for a device code.
    /// </summary>
    [DataContract]
    internal sealed class DeviceCodeResponse
    {
        /// <summary>
        /// Gets the device code returned by the service.
        /// </summary>
        [DataMember(IsRequired = false, Name = "device_code")]
        public string DeviceCode { get; internal set; }

        /// <summary>
        /// Gets or sets the error, if one was encountered.
        /// </summary>

        [DataMember(IsRequired = false, Name = "error")]
        public string Error { get; internal set; }

        /// <summary>
        /// Gets the description of the error, if one was encountered.
        /// </summary>
        [DataMember(IsRequired = false, Name = "error_description")]
        public string ErrorDescription { get; internal set; }

        /// <summary>
        /// Gets the number of seconds until the device code expires.
        /// </summary>
        [DataMember(IsRequired = false, Name = "expires_in")]
        public long ExpiresIn { get; internal set; }

        /// <summary>
        /// Gets the polling interval time to check for completion of authentication flow.
        /// </summary>
        [DataMember(IsRequired = false, Name = "interval")]
        public long Interval { get; internal set; }

        /// <summary>
        /// Gets the user friendly text response that can be used for display purpose.
        /// </summary>
        [DataMember(IsRequired = false, Name = "message")]
        public string Message { get; internal set; }

        /// <summary>
        /// Gets the user code returned by the service.
        /// </summary>
        [DataMember(IsRequired = false, Name = "user_code")]
        public string UserCode { get; internal set; }

        /// <summary>
        /// Verification URL where the user must navigate to authenticate using the device code and credentials.
        /// </summary>
        [DataMember(IsRequired = false, Name = "verification_url")]
        public Uri VerificationUrl { get; internal set; }

        /// <summary>
        /// Get an instance of the <see cref="DeviceCodeResult" /> class based on this instnace of <see cref="DeviceCodeResponse" />.
        /// </summary>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
        /// <returns>
        /// An instance of the <see cref="DeviceCodeResponse" /> class based on this instance of <see cref="DeviceCodeResponse" />.
        /// </returns>
        public DeviceCodeResult GetResult(string clientId, string resource)
        {
            return new DeviceCodeResult()
            {
                ClientId = clientId,
                DeviceCode = DeviceCode,
                ExpiresOn = DateTime.UtcNow.AddSeconds(ExpiresIn),
                Interval = Interval,
                Message = Message,
                Resource = resource,
                UserCode = UserCode,
                VerificationUrl = VerificationUrl
            };
        }
    }
}