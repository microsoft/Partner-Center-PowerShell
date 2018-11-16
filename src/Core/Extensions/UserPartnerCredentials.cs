﻿// -----------------------------------------------------------------------
// <copyright file="RequestContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Extensions
{
    using System;
    using System.Threading.Tasks;
    using IdentityModel.Clients.ActiveDirectory;
    using Exceptions;
    using RequestContext;

    /// <summary>
    /// Partner service credentials based on azure active directory user credentials.
    /// </summary>
    internal class UserPartnerCredentials : BasePartnerCredentials
    {
        /// <summary>
        /// The delegate used to refresh the azure active directory token.
        /// </summary>
        private readonly TokenRefresher tokenRefresher;

        /// <summary>
        /// Initializes static members of the <see cref="UserPartnerCredentials" /> class.
        /// </summary>
        static UserPartnerCredentials()
        {
            PartnerService.Instance.RefreshCredentials += new PartnerService.RefreshCredentialsHandler(OnCredentialsRefreshNeededAsync);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.Store.PartnerCenter.Extensions.UserPartnerCredentials" /> class.
        /// </summary>
        /// <param name="aadApplicationId">The id of the application in azure active directory.</param>
        /// <param name="aadAuthenticationToken">The azure active directory token.</param>
        /// <param name="aadTokenRefresher">An optional delegate which will be called when the azure active directory token
        /// expires and can no longer be used to generate the partner credentials. This delegate should return
        /// an up to date azure active directory token.</param>
        public UserPartnerCredentials(string aadApplicationId, AuthenticationToken aadAuthenticationToken, TokenRefresher aadTokenRefresher = null)
          : base(aadApplicationId)
        {
            if (aadAuthenticationToken == null)
            {
                throw new ArgumentNullException(nameof(aadAuthenticationToken));
            }

            if (aadAuthenticationToken.IsExpired())
            {
                throw new ArgumentException("aadAuthenticationToken is expired.");
            }

            AADToken = aadAuthenticationToken;
            tokenRefresher = aadTokenRefresher;
        }

        /// <summary>
        /// Called when a partner credentials instance needs to be refreshed.
        /// </summary>
        /// <param name="credentials">The outdated partner credentials.</param>
        /// <param name="context">The partner context.</param>
        /// <returns>A task that is complete when the credential refresh is done.</returns>
        private static async Task OnCredentialsRefreshNeededAsync(IPartnerCredentials credentials, IRequestContext context)
        {
            if (credentials is UserPartnerCredentials partnerCredentials)
            {
                await partnerCredentials.RefreshAsync(context).ConfigureAwait(false);
            }
        }

        /// <summary>Refreshes the partner credentials.</summary>
        /// <param name="context">The partner context.</param>
        /// <returns>A task which is complete when the refresh is done.</returns>
        private async Task RefreshAsync(IRequestContext context)
        {
            if (AADToken.IsExpired())
            {
                if (tokenRefresher != null)
                {
                    AuthenticationToken authenticationToken = await tokenRefresher(AADToken).ConfigureAwait(false);
                    if (authenticationToken == null)
                    {
                        throw new PartnerException("Token refresher returned null token.", context, PartnerErrorCategory.Unauthorized, (Exception)null);
                    }
                    if (authenticationToken.IsExpired())
                    {
                        throw new PartnerException("Token refresher returned an expired token.", context, PartnerErrorCategory.Unauthorized, (Exception)null);
                    }

                    AADToken = authenticationToken;
                }
                else
                {
                    throw new PartnerException("AAD Token needs refreshing but no handler was registered.", context, PartnerErrorCategory.Unauthorized, (Exception)null);
                }
            }

            await AuthenticateAsync(context).ConfigureAwait(false);
        }
    }
}
