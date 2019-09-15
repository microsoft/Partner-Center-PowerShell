// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Factories
{
    using Network;
    using PowerShell.Factories;

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
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public IPartner CreatePartnerOperations()
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
