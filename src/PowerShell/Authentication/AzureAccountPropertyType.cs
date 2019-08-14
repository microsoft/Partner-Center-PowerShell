// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    /// <summary>
    /// The available type of properties for an Azure account.
    /// </summary>
    public enum AzureAccountPropertyType
    {
        AccessToken,
        ServicePrincipalSecret,
        Tenant,
        UserIdentifier
    }
}