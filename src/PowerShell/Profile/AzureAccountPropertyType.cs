// -----------------------------------------------------------------------
// <copyright file="AzureAccountPropertyType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Profile
{
    /// <summary>
    /// The available type of properties for an Azure account.
    /// </summary>
    public enum AzureAccountPropertyType
    {
        AccessToken,
        AccessTokenExpiration,
        ServicePrincipalSecret,
        Tenant,
        UserIdentifier
    }
}