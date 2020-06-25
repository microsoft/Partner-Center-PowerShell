// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using Factories;
    using Models.Authentication;
    using Utilities; 

    /// <summary>
    /// Used to perform actions when the module is loaded and unloaded.
    /// </summary>
    public class PartnerModule : IModuleAssemblyInitializer, IModuleAssemblyCleanup
    {
        /// <summary>
        /// The name of the configuration property.
        /// </summary>
        private const string ConfigurationProperty = "Configuration";

        /// <summary>
        /// The value used to identify the client connect to the partner service.
        /// </summary>
        private const string PartnerCenterClient = "Partner Center PowerShell";

        /// <summary>
        /// Contains the assemblies from the preload directory.
        /// </summary>
        private static readonly IList<string> PreloadAssemblies = new List<string>();

        /// <summary>
        /// Gets or sets the path to the preload assembly folder.
        /// </summary>
        private static string PreloadAssemblyFolder { get; set; }

        /// <summary>
        /// Performs the required operations when the module is imported.
        /// </summary>
        public void OnImport()
        {
            PropertyInfo prop = PartnerService.Instance.GetType().GetProperty(
                ConfigurationProperty,
                BindingFlags.Instance | BindingFlags.NonPublic);

            dynamic configuration = prop.GetValue(PartnerService.Instance);

            configuration.PartnerCenterClient = PartnerCenterClient;

            if (PartnerSession.Instance.AuthenticationFactory == null)
            {
                PartnerSession.Instance.AuthenticationFactory = new AuthenticationFactory();
            }

            if (PartnerSession.Instance.ClientFactory == null)
            {
                PartnerSession.Instance.ClientFactory = new ClientFactory();
            }

            if (File.Exists(Path.Combine(SharedUtilities.GetUserRootDirectory(), ".PartnerCenter", "InMemoryTokenCache")))
            {
                PartnerSession.Instance.RegisterComponent(ComponentKey.TokenCache, () => new InMemoryTokenCache());
            }
            else
            {
                PartnerSession.Instance.RegisterComponent(ComponentKey.TokenCache, () => new PersistentTokenCache());
            }

            PreloadAssemblyFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PreloadAssemblies");

            foreach (string file in Directory.GetFiles(PreloadAssemblyFolder, "*.dll"))
            {
                PreloadAssemblies.Add(Path.GetFileNameWithoutExtension(file));
            }

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        /// <summary>
        /// Performs the required operations when the module is unloaded.
        /// </summary>
        /// <param name="psModuleInfo">Information for the module.</param>
        public void OnRemove(PSModuleInfo psModuleInfo)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }

        /// <summary>
        /// Handles the <see cref="AppDomain.AssemblyResolve" />, <see cref="AppDomain.ResourceResolve" />, or <see cref="AppDomain.AssemblyResolve" /> events for app domain.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The arguments for the resolve event.</param>
        /// <returns>The assembly that was resolved.</returns>
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                AssemblyName assembly = new AssemblyName(args.Name);

                if (PreloadAssemblies.Contains(assembly.Name, StringComparer.InvariantCultureIgnoreCase))
                {
                    return Assembly.LoadFrom(Path.Combine(PreloadAssemblyFolder, $"{assembly.Name}.dll"));
                }
            }
            catch
            { }

            return null;
        }
    }
}
