// -----------------------------------------------------------------------
// <copyright file="ClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using Common;
    using IdentityModel.Clients.ActiveDirectory;
    using Profile;

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
        public virtual IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            AuthenticationResult authResult;

            context.AssertNotNull(nameof(context));

            authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(context);

            return PartnerService.Instance.CreatePartnerOperations(new PowerShellCredentials(authResult));
        }
    }
}