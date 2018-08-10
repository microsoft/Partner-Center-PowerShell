// -----------------------------------------------------------------------
// <copyright file="ClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using Authentication;
    using Common;
    using Extensions;
    using IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Factory that provides initialized clients used to interact with online services.
    /// </summary>
    public class ClientFactory : IClientFactory
    {
        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="context" /> is null.
        /// </exception>
        public virtual IPartner CreatePartnerOperations(PartnerContext context)
        {
            AuthenticationResult authResult;

            context.AssertNotNull(nameof(context));

            try
            {
                authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                    context,
                    null);

                IPartnerCredentials credentials = PartnerCredentials.Instance.GenerateByUserCredentials(
                    context.ApplicationId,
                    new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn));

                PartnerService.Instance.ApplicationName = "Partner Center PowerShell (Preview)";

                return PartnerService.Instance.CreatePartnerOperations(credentials);
            }
            finally
            {
                authResult = null;
            }
        }
    }
}