// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Management.Automation;
    using System.Reflection;
    using Factories;
    using Network;
    using PowerShell.Models.Authentication;

    /// <summary>
    /// Test base for all Partner Center PowerShell commands.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Delegating handler used to intercept partner service client operations.
        /// </summary>
        private static readonly HttpMockHandler httpMockHandler = new HttpMockHandler(HttpMockHandlerMode.Playback);

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase" /> class.
        /// </summary>
        static TestBase()
        {
            IPartnerCredentials credentials = new TestPartnerCredentials();
            PartnerSession.Instance.ClientFactory = new MockClientFactory(httpMockHandler, credentials);

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            PartnerSession.Instance.AuthenticationFactory = new MockAuthenticationFactory();

            PartnerAccount account = new PartnerAccount
            {
                Type = AccountType.User
            };

            PartnerSession.Instance.Context = new PartnerContext
            {
                Account = account,
                CountryCode = "US",
                Environment = PartnerEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                Locale = "en-US",
            };
        }

        /// <summary>
        /// Run the specified test script.
        /// </summary>
        protected Collection<PSObject> RunPowerShellTest(string script)
        {
            Collection<PSObject> output;

            if (string.IsNullOrEmpty(script))
            {
                throw new ArgumentException(nameof(script));
            }

            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("$Error.clear()");
                powershell.AddScript($"Write-Debug \"Current directory: {AppDomain.CurrentDomain.BaseDirectory}\"");
                powershell.AddScript($"Write-Debug \"Current executing assembly: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\"");
                powershell.AddScript($"cd \"{AppDomain.CurrentDomain.BaseDirectory}\"");

                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PartnerCenter.psm1")}\"");
                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScenarioTests\\Common.ps1")}\"");
                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"ScenarioTests\\{GetType().Name}.ps1")}\"");

                string test = GetType().Name;

                powershell.AddScript("$VerbosePreference='Continue'");
                powershell.AddScript("$DebugPreference='Continue'");
                powershell.AddScript("$ErrorActionPreference='Stop'");
                powershell.AddScript(script);

                try
                {
                    powershell.Runspace.Events.Subscribers.Clear();
                    output = powershell.Invoke();

                    if (powershell.Streams.Error.Count > 0)
                    {
                        throw new RuntimeException(
                            $"Test failed due to a non-empty error stream. First error: {FormatErrorRecord(powershell.Streams.Error[0])}{(powershell.Streams.Error.Count > 0 ? "Check the error stream in the test log for additional errors." : "")}");
                    }

                    return output;
                }
                finally
                {
                    powershell.Streams.Error.Clear();
                }
            }
        }

        /// <summary>
        /// Formats an <see cref="ErrorRecord"/> to a detailed string for logging.
        /// </summary>
        internal static string FormatErrorRecord(ErrorRecord record)
        {
            return $"PowerShell Error Record: {record}\nException:{record.Exception}\nDetails:{record.ErrorDetails}\nScript Stack Trace: {record.ScriptStackTrace}\n: Target: {record.TargetObject}\n";
        }
    }
}