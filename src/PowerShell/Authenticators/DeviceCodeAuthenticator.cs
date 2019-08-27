// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Threading.Tasks;
    using Factories;
    using Identity.Client;
    using Models;
    using Models.Authentication;

    /// <summary>
    /// Provides the ability to authenticate using the device code flow.
    /// </summary>
    internal class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public override AuthenticationResult Authenticate(AuthenticationParameters parameters)
        {
            IPublicClientApplication client = SharedTokenCacheClientFactory.CreatePublicClient(
                $"{parameters.Environment.ActiveDirectoryAuthority}{parameters.TenantId}",
                parameters.ApplicationId,
                null,
                parameters.TenantId);

            return client.AcquireTokenWithDeviceCode(
                parameters.Scopes, deviceCodeResult =>
                {
                    WriteWarning(deviceCodeResult?.Message);
                    return Task.CompletedTask;
                }).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is DeviceCodeParameters;
        }

        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="message">The message that describes the warning.</param>
        private void WriteWarning(string message)
        {
            if (PartnerSession.Instance.TryGetComponent("WriteWarning", out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs() { Message = message });
            }
        }
    }
}