// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests
{
    using Network;

    /// <summary>
    /// This class contains the entry point the partner SDK test framework.
    /// </summary>
    public static class TestPartnerService
    {
        /// <summary>
        /// Creates an object used to access the Partner Center API with the specified credentials.
        /// </summary>
        /// <param name="credentials">Credentials to be used when accessing resources.</param>
        /// <param name="handler">Mock delegating handler used for testing purposes.</param>
        /// <returns>A configured partner operations object.</returns>
        public static IPartner CreatePartnerOperations(IPartnerCredentials credentials, HttpMockHandler handler)
        {
            return PartnerService.Instance.CreatePartnerOperations(credentials, handler);
        }
    }
}
