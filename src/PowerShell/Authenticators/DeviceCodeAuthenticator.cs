﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Identity.Client;

    /// <summary>
    /// Provides the ability to authenticate using the device code flow.
    /// </summary>
    internal class DeviceCodeAuthenticator : DelegatingAuthenticator
    {
        /// <summary>
        /// The message that will be written utilizing the prompt action.
        /// </summary>
        private string message;

        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="promptAction">The action used to prompt for interaction.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public override async Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters, Action<string> promptAction = null, CancellationToken cancellationToken = default)
        {
            IPublicClientApplication app = GetClient(parameters.Account, parameters.Environment).AsPublicClient();

            Task<AuthenticationResult> task = Task<AuthenticationResult>.Factory.StartNew(() =>
                app.AcquireTokenWithDeviceCode(parameters.Scopes, deviceCodeResult =>
                {
                    message = deviceCodeResult.Message;
                    return Task.CompletedTask;
                }).ExecuteAsync(cancellationToken).GetAwaiter().GetResult());

            while (true)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    promptAction(message);
                    break;
                }

                cancellationToken.ThrowIfCancellationRequested();
                Thread.Sleep(1000);
            }

            await Task.CompletedTask;

            return task.Result;
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
    }
}