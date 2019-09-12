// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    /// <summary>
    /// Represents an account used when connecting to online services.
    /// </summary>
    public interface IPartnerAccount : IExtensibleModel
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Get or sets the account identifier.
        /// </summary>
        string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name identifier or name.
        /// </summary>
        string Tenant { get; set; }

        /// <summary>
        /// Gets or sets the account type.
        /// </summary>
        AccountType Type { get; set; }
    }
}