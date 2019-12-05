// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using Identity.Client;

    /// <summary>
    /// Represents information about a single account.
    /// </summary>
    public sealed class ResourceAccount : IAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAccount" /> class.
        /// </summary>
        /// <param name="environment">A string containing the identity provider for this account.</param>
        /// <param name="identifier">The unique identifier for the account.</param>
        /// <param name="objectId">A string representation for a GUID which is the ID of the user owning the account in the tenant.</param>
        /// <param name="tenantId">A string representation for a GUID, which is the ID of the tenant where the account resides.</param>
        /// <param name="username">A string containing the displayable value in UserPrincipalName (UPN) format.</param>
        public ResourceAccount(string environment, string identifier, string objectId, string tenantId, string username)
        {
            Environment = environment;
            HomeAccountId = new AccountId(identifier, objectId, tenantId);
            Username = username;
        }

        /// <summary>
        /// Gets a string containing the identity provider for this account, e.g. login.microsoftonline.com.
        /// </summary>
        public string Environment { get; }

        /// <summary>
        /// AccountId of the home account for the user. This uniquely identifies the user across AAD tenants.
        /// </summary>
        public AccountId HomeAccountId { get; }

        /// <summary>
        /// Gets a string containing the displayable value in UserPrincipalName (UPN) format, e.g. john.doe@contoso.com. This can be null.
        /// </summary>
        public string Username { get; }
    }
}