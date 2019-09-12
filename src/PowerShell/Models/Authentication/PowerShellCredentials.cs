// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System;
    using System.Threading.Tasks;
    using Extensions;
    using Identity.Client;
    using RequestContext;

    /// <summary>
    /// Provides the credentials need to access the partner service.
    /// </summary>
    public class PowerShellCredentials : IPartnerCredentials
    {
        /// <summary>
        /// The result from a successfully token request.
        /// </summary>
        private AuthenticationToken authToken;

        /// <summary>
        /// Initializes static members of the <see cref="PowerShellCredentials" /> class.
        /// </summary>
        static PowerShellCredentials()
        {
            PartnerService.Instance.RefreshCredentials += new PartnerService.RefreshCredentialsHandler(OnCredentialsRefreshNeededAsync);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellCredentials" /> class.
        /// </summary>
        /// <param name="authToken">The authentication token for Partner Center.</param>
        public PowerShellCredentials(AuthenticationToken authToken)
        {
            this.authToken = authToken;
        }

        /// <summary>
        ///  Gets the expiry time in UTC for the token.
        /// </summary>
        public DateTimeOffset ExpiresAt => authToken.ExpiryTime;

        /// <summary>
        /// Gets the token needed to authenticate with the partner service.
        /// </summary>
        public string PartnerServiceToken => authToken.Token;

        /// <summary>
        /// Indicates whether the partner credentials have expired or not.
        /// </summary>
        /// <returns><c>true</c> if the partner credentials have expired; otherwise <c>false</c>.</returns>
        public bool IsExpired()
        {
            return DateTimeOffset.UtcNow > authToken.ExpiryTime;
        }

        /// <summary>
        /// Refreshes the partner credentials.
        /// </summary>
        /// <param name="context">The partner context.</param>
        /// <returns>A task which is complete when the refresh is done.</returns>
        private async Task RefreshAsync(IRequestContext context)
        {
            context.AssertNotNull(nameof(context));

            AuthenticationResult authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                PartnerSession.Instance.Context.Account,
                PartnerSession.Instance.Context.Environment,
                new[] { $"{PartnerSession.Instance.Context.Environment.PartnerCenterEndpoint}/user_impersonation" });

            authToken = new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);

            await Task.CompletedTask.ConfigureAwait(false);
        }

        /// <summary>
        /// Called when a partner credentials instance needs to be refreshed.
        /// </summary>
        /// <param name="credentials">The outdated partner credentials.</param>
        /// <param name="context">The partner context.</param>
        /// <returns>A task that is complete when the credential refresh is complete.</returns>
        private static async Task OnCredentialsRefreshNeededAsync(IPartnerCredentials credentials, IRequestContext context)
        {
            if (credentials is PowerShellCredentials partnerCredentials)
            {
                await partnerCredentials.RefreshAsync(context).ConfigureAwait(false);
            }
        }
    }
}