// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.IO;
    using System.Management.Automation;
    using Models.Authentication;
    using Utilities;

    [Cmdlet(VerbsLifecycle.Register, "PartnerTokenCache", DefaultParameterSetName = ByPersistentParameterSet)]
    public class RegisterPartnerTokenCache : PartnerPSCmdlet
    {
        /// <summary>
        /// The name of the in-membory parameter set.
        /// </summary>
        private const string ByInMemoryParameterSet = "ByInMemory";

        /// <summary>
        /// The name of the persisent parameter set.
        /// </summary>
        private const string ByPersistentParameterSet = "ByPersistent";

        /// <summary>
        /// Gets or sets a flag indicating that the in-memory token cache should be registered.
        /// </summary>
        [Parameter(HelpMessage = "A flag indicating that the in-memory token cache should be registered.", Mandatory = true, ParameterSetName = ByInMemoryParameterSet)]
        public SwitchParameter InMemory { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that the persistent token cache should be registered.
        /// </summary>
        [Parameter(HelpMessage = "A flag indicating that the persistent token cache should be registered.", Mandatory = true, ParameterSetName = ByPersistentParameterSet)]
        public SwitchParameter Persistent { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string inMemoryControlFilePath = Path.Combine(SharedUtilities.GetUserRootDirectory(), ".PartnerCenter", "InMemoryTokenCache");

            // TODO - Need to clone the cache if already connected; otherwise, the user will need to connect.

            if (InMemory.IsPresent && InMemory.ToBool())
            {
                if (!File.Exists(inMemoryControlFilePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(inMemoryControlFilePath));
                    File.Create(inMemoryControlFilePath).Dispose();
                }

                PartnerSession.Instance.RegisterComponent(ComponentKey.TokenCache, () => new InMemoryTokenCache(), true);
            }

            if (Persistent.IsPresent && Persistent.ToBool())
            {
                if (File.Exists(inMemoryControlFilePath))
                {
                    File.Delete(inMemoryControlFilePath);
                }

                PartnerSession.Instance.RegisterComponent(ComponentKey.TokenCache, () => new PersistentTokenCache());
            }
        }
    }
}