// -----------------------------------------------------------------------
// <copyright file="ClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using Common;
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
            context.AssertNotNull(nameof(context));

            return PartnerService.Instance.CreatePartnerOperations(
                new PowerShellCredentials(
                    PartnerSession.Instance.AuthenticationFactory.Authenticate(context)));
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="Core.PartnerOperations" /> class.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="context" /> is null.
        /// </exception>
        public virtual Core.IPartner CreateCorePartnerOperations(PartnerContext context)
        {
            context.AssertNotNull(nameof(context));

            AuthenticationToken token = PartnerSession.Instance.AuthenticationFactory.Authenticate(context);

            return Core.PartnerService.Instance.CreatePartnerOperations(
                new PowerShellCoreCredentials(
                    new Core.AuthenticationToken(token.Token, token.ExpiryTime)));
        }
    }
}