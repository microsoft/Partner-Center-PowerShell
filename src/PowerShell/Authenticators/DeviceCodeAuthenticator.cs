// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Identity.Client;
    using Models;
    using Models.Authentication;
    using Rest;

    /// <summary>
    /// Provides the ability to authenticate using the device code flow.
    /// </summary>
    internal class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public override async Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters, CancellationToken cancellationToken = default)
        {
            IClientApplicationBase app = await GetClientAsync(parameters.Account, parameters.Environment).ConfigureAwait(false);

            ServiceClientTracing.Information($"[DeviceCodeAuthenticator] Calling AcquireTokenWithDeviceCode - Scopes: '{string.Join(", ", parameters.Scopes)}'");
            return await app.AsPublicClient().AcquireTokenWithDeviceCode(parameters.Scopes, deviceCodeResult =>
            {
                WriteWarning(deviceCodeResult.Message);
                return Task.CompletedTask;
            }).ExecuteAsync(cancellationToken).ConfigureAwait(false);
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

        private void WriteWarning(string message)
        {
            if (PartnerSession.Instance.TryGetComponent("WriteWarning", out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs { Resource = message });
            }
        }
    }
}