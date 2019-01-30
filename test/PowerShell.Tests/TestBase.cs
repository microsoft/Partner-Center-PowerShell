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
    using Factories;
    using PowerShell.Authentication;
    using TestFramework;
    using TestFramework.Network;

    /// <summary>
    /// Test base for all Partner Center PowerShell commands.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Delegating handler used to intercept partner service client operations.
        /// </summary>
        private readonly static HttpMockHandler httpMockHandler = new HttpMockHandler(HttpMockHandlerMode.Playback);

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase" /> class.
        /// </summary>
        static TestBase()
        {
            IPartnerCredentials credentials = new TestPartnerCredentials();
            PartnerSession.Instance.ClientFactory = new MockClientFactory(httpMockHandler, credentials);

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            PartnerSession.Instance.AuthenticationFactory = new MockAuthenticationFactory();

            AzureAccount account = new AzureAccount
            {
                Id = "partner@contoso.com",
                Type = AccountType.User
            };

            account.Properties[AzureAccountPropertyType.Tenant] = "0e47c304-9333-4e49-84de-9cb7868b63bc";
            account.Properties[AzureAccountPropertyType.UserIdentifier] = "cc2f43c3-92c6-4263-8a1c-e214f5b666fd";

            PartnerSession.Instance.Context = new PartnerContext
            {
                Account = account,
                ApplicationId = "427fa6c7-fcf5-473e-8b28-c6d07b842c9e",
                CountryCode = "US",
                Environment = EnvironmentName.GlobalCloud,
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

                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PartnerCenter.NetCore.psd1")}\"");
                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Commands\\Common.ps1")}\"");
                powershell.AddScript($"Import-Module \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Commands\\{GetType().Name}.ps1")}\"");

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