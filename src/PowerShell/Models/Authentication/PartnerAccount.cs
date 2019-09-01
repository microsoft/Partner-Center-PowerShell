// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an account used when connecting to online services.
    /// </summary>
    public class PartnerAccount : IPartnerAccount
    {
        /// <summary>
        /// Gets or sets the extended properties for the account.
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets or sets the unique identifier for the account.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Get or sets the account object identifier.
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the account type.
        /// </summary>
        public AccountType Type { get; set; }

    }
}