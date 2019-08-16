// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    using System;

    /// <summary>
    /// The different types of authentication.
    /// </summary>
    [Flags]
    public enum AuthenticationTypes
    {
        None = 0,
        AppOnly = 1,
        AppPlusUser = 2,
        Both = AppOnly | AppPlusUser
    }
}