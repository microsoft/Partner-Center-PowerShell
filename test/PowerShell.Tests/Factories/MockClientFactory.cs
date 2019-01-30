// -----------------------------------------------------------------------
// <copyright file="MockClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories
{
    using System;
    using PowerShell.Authentication;
    using PowerShell.Factories;
    using TestFramework;
    using TestFramework.Network;

    /// <summary>
    /// Factory that provides initialized clients used to mock interactions with online services.
    /// </summary>
    public class MockClientFactory : IClientFactory
    {
        /// <summary>
        /// Delegating handler used to intercept partner service client operations.
        /// </summary>
        private readonly HttpMockHandler httpMockHandler;

        /// <summary>
        /// Credentials used when communicating with the partner service.
        /// </summary>
        private readonly IPartnerCredentials credentials;

        /// <summary>
        /// Provides the ability to interact with the partner service.
        /// </summary>
        private static IPartner partnerOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockClientFactory" /> class.
        /// </summary>
        /// <param name="httpMockHandler">The delegating handler used test HTTP operations.</param>
        /// <param name="credentials">Credentials used when communicating with the partner service.</param>
        public MockClientFactory(HttpMockHandler httpMockHandler, IPartnerCredentials credentials)
        {
            this.credentials = credentials;
            this.httpMockHandler = httpMockHandler;
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public IPartner CreatePartnerOperations(PartnerContext context, Action<string> debugAction)
        {
            if (partnerOperations == null)
            {
                partnerOperations = TestPartnerService.CreatePartnerOperations(
                    credentials,
                    httpMockHandler);
            }

            return partnerOperations;
        }
    }
}