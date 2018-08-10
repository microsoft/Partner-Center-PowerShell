// -----------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Management.Automation;
    using System.Reflection;
    using Authentication;
    using Factories;

    /// <summary>
    /// Base class for Microsoft Partner Center PowerShell cmdlets unit tests.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase" /> class.
        /// </summary>
        protected TestBase()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            PartnerSession.Instance.AuthenticationFactory = new MockAuthenticationFactory();
            PartnerProfile.Instance.Context = new PartnerContext
            {
                CountryCode = "US",
                Environment = EnvironmentName.GlobalCloud,
                Locale = "en-US",
                TenantId = "0e47c304-9333-4e49-84de-9cb7868b63bc",
                Username = "bill@contoso.com"
            };
        }

        /// <summary>
        /// Run the specified test scripts.
        /// </summary>
        /// <param name="initializeFunc">Function used to initialize the partner operations.</param>
        /// <param name="functions">An array of functions to be invoked.</param>
        protected Collection<PSObject> RunPowerShellTest(Func<PartnerContext, IPartner> initializeFunc, params string[] functions)
        {
            Collection<PSObject> output = null;

            PartnerSession.Instance.ClientFactory = new MockClientFactory(initializeFunc);

            using (PowerShell powershell = PowerShell.Create(RunspaceMode.NewRunspace))
            {
                powershell.AddScript("$Error.clear()");
                powershell.AddScript($"Write-Debug \"Current directory: {AppDomain.CurrentDomain.BaseDirectory}\"");
                powershell.AddScript($"Write-Debug \"Current executing assembly: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\"");
                powershell.AddScript($"cd \"{AppDomain.CurrentDomain.BaseDirectory}\"");

                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PartnerCenter.psd1")}\"");
                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Commands\\Common.ps1")}\"");
                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Commands\\{GetType().Name}.ps1")}\"");

                powershell.AddScript("$VerbosePreference='Continue'");
                powershell.AddScript("$DebugPreference='Continue'");
                powershell.AddScript("$ErrorActionPreference='Stop'");

                foreach (string function in functions)
                {
                    powershell.AddScript(function);
                }

                try
                {
                    powershell.Runspace.Events.Subscribers.Clear();
                    output = powershell.Invoke();

                    if (powershell.Streams.Error.Count > 0)
                    {
                        throw new RuntimeException(
                            $"Test failed due to a non-empty error stream. First error: {PowerShellExtensions.FormatErrorRecord(powershell.Streams.Error[0])}{(powershell.Streams.Error.Count > 0 ? "Check the error stream in the test log for additional errors." : "")}");
                    }

                    return output;
                }
                finally
                {
                    powershell.Streams.Error.Clear();
                }
            }
        }
    }
}