// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Context information used for the execution of various tasks.
    /// </summary>
    public class PartnerContext : IExtensibleModel
    {
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public PartnerAccount Account { get; set; }

        /// <summary>
        /// Gets or sets the ISO2 country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets the environment used for authentication.
        /// </summary>
        public PartnerEnvironment Environment { get; set; }

        /// <summary>
        /// Gets the extended properties.
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        public string Locale { get; set; }
    }
}