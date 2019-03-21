// -----------------------------------------------------------------------
// <copyright file="ClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Net.Http;
    using Authentication;
    using Common;

    /// <summary>
    /// Factory that provides initialized clients used to interact with online services.
    /// </summary>
    public class ClientFactory : IClientFactory
    {
        /// <summary>
        /// The client used to perform HTTP operations.
        /// </summary>
        private readonly static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="debugAction" /> is null.
        /// </exception>
        public virtual IPartner CreatePartnerOperations(Action<string> debugAction)
        {
            debugAction.AssertNotNull(nameof(debugAction));

            return PartnerService.Instance.CreatePartnerOperations(
                new PowerShellCredentials(
                    PartnerSession.Instance.AuthenticationFactory.Authenticate(PartnerSession.Instance.Context, debugAction)),
                httpClient);
        }
    }
}