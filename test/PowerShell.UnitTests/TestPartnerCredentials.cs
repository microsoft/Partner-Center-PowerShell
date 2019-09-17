// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests
{
    using System;

    /// <summary>
    /// Test credentials used during testing with the partner service.
    /// </summary>
    public class TestPartnerCredentials : IPartnerCredentials
    {
        /// <summary>
        /// Gets the token needed to authenticate with the partner service.
        /// </summary>
        public string PartnerServiceToken => "STUB_TOKEN";

        /// <summary>
        /// Gets the expiry time in UTC for the token.
        /// </summary>
        public DateTimeOffset ExpiresAt => DateTime.UtcNow.AddHours(1);

        /// <summary>
        /// Gets a flag indicating whether the partner credentials have expired or not.
        /// </summary>
        /// <returns><c>true</c> if credentials have expired; otherwise <c>false</c>.</returns>
        public bool IsExpired()
        {
            return false;
        }
    }
}