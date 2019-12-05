// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Metadata information for PowerShell modules where the connection information is known.
    /// </summary>
    public class PowerShellModule
    {
        /// <summary>
        /// The application identifier for the Exchange Online PowerShell module.
        /// </summary>
        private const string ExchangeOnlineApplicationId = "a0c73c16-a7e3-4564-9a95-2bdf47383716";

        /// <summary>
        /// The application identifier used for authentication.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        public ModuleName ModuleName { get; private set; }

        /// <summary>
        /// Gets the scopes used by the module for authentication.
        /// </summary>
        public IEnumerable<string> Scopes { get; private set; }

        /// <summary>
        /// Gets the modules where connection information is known.
        /// </summary>
        public static IDictionary<ModuleName, PowerShellModule> KnownModules { get; } = InitializeModules();

        /// <summary>
        /// Initializes a list of known modules.
        /// </summary>
        /// <returns>A dictionary containing the known modules.</returns>
        private static IDictionary<ModuleName, PowerShellModule> InitializeModules()
        {
            return new ConcurrentDictionary<ModuleName, PowerShellModule>
            {
                [ModuleName.ExchangeOnline] = new PowerShellModule
                {
                    ApplicationId = ExchangeOnlineApplicationId,
                    ModuleName = ModuleName.ExchangeOnline,
                    Scopes = new[] { "https://outlook.office365.com/.default" }
                }
            };
        }
    }
}