// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System;
    using System.Collections.Generic;
    using Identity.Client;

    public class AuthResult : AuthenticationResult
    {
        public AuthResult(string accessToken, bool isExtendedLifeTimeToken, string uniqueId, DateTimeOffset expiresOn, DateTimeOffset extendedExpiresOn, string tenantId, IAccount account, string idToken, IEnumerable<string> scopes)
            : base(accessToken, isExtendedLifeTimeToken, uniqueId, expiresOn, extendedExpiresOn, tenantId, account, idToken, scopes)
        {
        }

        public string RefreshToken { get; set; }
    }
}