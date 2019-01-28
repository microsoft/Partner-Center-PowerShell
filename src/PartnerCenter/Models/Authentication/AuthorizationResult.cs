// -----------------------------------------------------------------------
// <copyright file="AuthorizationResult.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    /// <summary>
    /// Represents an authorization result from the authentication system.
    /// </summary>
    [DataContract]
    internal class AuthorizationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationResult" /> class
        /// </summary>
        /// <param name="status">The status of the authorization request.</param>
        internal AuthorizationResult(AuthorizationStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationResult" /> class
        /// </summary>
        /// <param name="status">The status of the authorization request.</param>
        /// <param name="returnedUriInput">The address returned from the web browser.</param>
        internal AuthorizationResult(AuthorizationStatus status, string returnedUriInput) : this(status)
        {
            if (Status == AuthorizationStatus.UserCancel)
            {
                Error = "authentication_canceled";
                ErrorDescription = "User canceled authentication. On an Android device, this could be due to the lack of capabilities, such as custom tabs, for the system browser. See https://aka.ms/msal-net-system-browsers for more information.";
            }
            else if (Status == AuthorizationStatus.UnknownError)
            {
                Error = "unknown_error";
                ErrorDescription = "Unknown error";
            }
            else
            {
                ParseAuthorizeResponse(returnedUriInput);
            }
        }

        public AuthorizationStatus Status { get; private set; }

        [DataMember]
        public string Code { get; private set; }

        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public string ErrorDescription { get; set; }

        [DataMember]
        public string CloudInstanceHost { get; set; }

        public string State { get; set; }

        public void ParseAuthorizeResponse(string webAuthenticationResult)
        {
            Uri resultUri = new Uri(webAuthenticationResult);

            // NOTE: The Fragment property actually contains the leading '#' character and that must be dropped
            string resultData = resultUri.Query;

            if (!string.IsNullOrWhiteSpace(resultData))
            {
                // RemoveAccount the leading '?' first
                NameValueCollection parameters = HttpUtility.ParseQueryString(resultData.Substring(1));
                Dictionary<string, string> response = parameters.AllKeys.ToDictionary(k => k, k => parameters[k]); 

                if (response.ContainsKey("state"))
                {
                    State = response["state"];
                }

                if (response.ContainsKey("code"))
                {
                    Code = response["code"];
                }
                else if (webAuthenticationResult.StartsWith("msauth://", StringComparison.OrdinalIgnoreCase))
                {
                    Code = webAuthenticationResult;
                }
                else if (response.ContainsKey("error"))
                {
                    Error = response["error"];
                    ErrorDescription = response.ContainsKey("error_description")
                        ? response["error_description"]
                        : null;
                    Status = AuthorizationStatus.ProtocolError;
                }
                else
                {
                    Error = "authentication_failed";
                    ErrorDescription = "The authorization server returned an invalid response";
                    Status = AuthorizationStatus.UnknownError;
                }

                if (response.ContainsKey("cloud_instance_host_name"))
                {
                    CloudInstanceHost = response["cloud_instance_host_name"];
                }
            }
            else
            {
                Error = "authentication_failed";
                ErrorDescription = "The authorization server returned an invalid response";
                Status = AuthorizationStatus.UnknownError;
            }
        }
    }
}