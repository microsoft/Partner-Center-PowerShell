// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Security.Claims;
    using Extensions;
    using Identity.Client;
    using IdentityModel.JsonWebTokens;
    using Models.Authentication;

    [Cmdlet(VerbsDiagnostic.Test, "PartnerSecurityRequirement")]
    public class TestPartnerSecurityRequirement : PSCmdlet
    {
        /// <summary>
        /// The message written to the console.
        /// </summary>
        private const string Message = "We have launched a browser for you to login. For the old experience with device code flow, please run 'Test-PartnerSecurityRequirement -UseDeviceAuthentication'.";

        /// <summary>
        /// The default application identifier value used when generating an access tokne.
        /// </summary>
        private const string PowerShellApplicationId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        /// <summary>
        /// Gets or sets the environment used for authentication.
        /// </summary>
        [Parameter(HelpMessage = "The environment use for authentication.", Mandatory = false)]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the device code flow should be used.
        /// </summary>
        [Alias("DeviceCode", "DeviceAuth", "Device")]
        [Parameter(Mandatory = false, HelpMessage = "Use device code authentication instead of a browser control.")]
        public SwitchParameter UseDeviceAuthentication { get; set; }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            string result = "pass";

            PartnerAccount account = new PartnerAccount
            {
                Tenant = "common",
                Type = AccountType.User
            };

            PartnerEnvironment environment = PartnerEnvironment.PublicEnvironments[Environment];

            if (UseDeviceAuthentication.IsPresent)
            {
                account.SetProperty("UseDeviceAuth", "true");
            }
            else
            {
                account.SetProperty("UseAuthCode", "true");
            }

            account.SetProperty(PartnerAccountPropertyType.ApplicationId, PowerShellApplicationId);

            AuthenticationResult authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                account,
                environment,
                new[] { $"{environment.PartnerCenterEndpoint}/user_impersonation" },
                Message);


            JsonWebToken jwt = new JsonWebToken(authResult.AccessToken);

            WriteDebug("Checking if the access token contains the MFA claim...");

            /*
             * Obtain the authentication method reference (AMR) claim. This claim contains the methods used
             * during authenitcation. See https://tools.ietf.org/html/rfc8176 for more information.
             */

            if (jwt.TryGetClaim("amr", out Claim claim))
            {
                if (!claim.Value.Contains("mfa"))
                {
                    WriteWarning("Unable to determine if the account authenticated using MFA. See https://aka.ms/partnercenterps-psr-warning for more information.");
                    result = "fail";
                }
            }
            else
            {
                WriteWarning("Unable to find the AMR claim, which means the ability to verify the MFA challenge happened will not be possible. See https://aka.ms/partnercenterps-psr-warning for more information.");
                result = "fail";
            }

            WriteObject(result);
        }
    }
}
