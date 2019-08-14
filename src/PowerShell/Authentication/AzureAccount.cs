// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class AzureAccount
    {
        /// <summary>
        /// Get or sets the account identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the account properties.
        /// </summary>
        public IDictionary<AzureAccountPropertyType, string> Properties { get; } = new ConcurrentDictionary<AzureAccountPropertyType, string>();

        /// <summary>
        /// Gets or sets the account type.
        /// </summary>
        public AccountType Type { get; set; }
    }
}