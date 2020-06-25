﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Authentication;
    using PartnerCenter.Exceptions;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Cmdlet to login to a Partner Center environment.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "PartnerCenter", DefaultParameterSetName = UserParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PartnerContext))]
    public class ConnectPartnerCenter : PartnerAsyncCmdlet
    {
        /// <summary>
        /// The name of the access token parameter set.
        /// </summary>
        private const string AccessTokenParameterSet = "AccessToken";

        /// <summary>
        /// The message written to the console.
        /// </summary>
        private const string Message = "We have launched a browser for you to login. For the old experience with device code flow, please run 'Connect-PartnerCenter -UseDeviceAuthentication'.";

        /// <summary>
        /// The default application identifier value used when generating an access tokne.
        /// </summary>
        private const string PowerShellApplicationId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        /// <summary>
        /// The name of the refresh token parameter set.
        /// </summary>
        private const string RefreshTokenParameterSet = "RefreshToken";

        /// <summary>
        /// The name of the service principal parameter set.
        /// </summary>
        private const string ServicePrincipalParameterSet = "ServicePrincipal";

        /// <summary>
        /// The name of the service principal certificate parameter set.
        /// </summary>
        private const string ServicePrincipalCertificateParameterSet = "ServicePrincipalCertificate";

        /// <summary>
        /// The name of the user parameter set.
        /// </summary>
        private const string UserParameterSet = "User";

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [Parameter(HelpMessage = "Access token used to connect to Partner Center.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "Identifier of the application used to connect to Partner Center.", Mandatory = true, ParameterSetName = RefreshTokenParameterSet)]
        [Parameter(HelpMessage = "Identifier of the application used to connect to Partner Center.", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the certificate thumbprint.
        /// </summary>
        [Parameter(HelpMessage = "Certificate thumbprint of a digital public key X.509 certificate.", Mandatory = false, ParameterSetName = RefreshTokenParameterSet)]
        [Parameter(HelpMessage = "Certificate thumbprint of a digital public key X.509 certificate.", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the service principal credential.
        /// </summary>
        [Parameter(HelpMessage = "Provides the application identifier and secret for service principal credentials.", Mandatory = false, ParameterSetName = RefreshTokenParameterSet)]
        [Parameter(HelpMessage = "Provides the application identifier and secret for service principal credentials.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the Partner Center environment name.
        /// </summary>
        [Parameter(HelpMessage = "Environment containing the account to login to.", Mandatory = false)]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        [Parameter(HelpMessage = "Refresh token used to connect to Partner Center.", Mandatory = true, ParameterSetName = RefreshTokenParameterSet)]
        [ValidateNotNull]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that a service principal is being used.
        /// </summary>
        [Parameter(HelpMessage = "Indicates that this account authenticates by providing service principal credentials.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "Indicates that this account authenticates by providing service principal credentials.", Mandatory = false, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Alias("Domain", "TenantId")]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = false, ParameterSetName = RefreshTokenParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = false, ParameterSetName = UserParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that device code authentication should be used.
        /// </summary>
        [Alias("Device", "DeviceAuth", "DeviceCode")]
        [Parameter(HelpMessage = "Use device code authentication instead of a browser control.", Mandatory = false, ParameterSetName = UserParameterSet)]
        public SwitchParameter UseDeviceAuthentication { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partnerOperations;
                OrganizationProfile profile;
                PartnerAccount account = new PartnerAccount();
                PartnerEnvironment environment = PartnerEnvironment.PublicEnvironments[Environment];

                if (!string.IsNullOrEmpty(CertificateThumbprint))
                {
                    account.SetProperty(PartnerAccountPropertyType.CertificateThumbprint, CertificateThumbprint);
                }

                if (!string.IsNullOrEmpty(RefreshToken))
                {
                    account.SetProperty(PartnerAccountPropertyType.RefreshToken, RefreshToken);
                }

                account.SetProperty(PartnerAccountPropertyType.ApplicationId, string.IsNullOrEmpty(ApplicationId) ? PowerShellApplicationId : ApplicationId);

                if (ParameterSetName.Equals(AccessTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    account.SetProperty(PartnerAccountPropertyType.AccessToken, AccessToken);
                    account.Type = AccountType.AccessToken;
                }
                else if (ParameterSetName.Equals(RefreshTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Credential != null)
                    {
                        account.ObjectId = Credential.UserName;
                        account.SetProperty(PartnerAccountPropertyType.ApplicationId, Credential.UserName);
                        account.SetProperty(PartnerAccountPropertyType.ServicePrincipalSecret, Credential.Password.ConvertToString());
                    }
                }
                else if (ParameterSetName.Equals(ServicePrincipalCertificateParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    account.SetProperty(PartnerAccountPropertyType.ApplicationId, ApplicationId);
                    account.Type = AccountType.Certificate;
                }
                else if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    account.ObjectId = Credential.UserName;
                    account.Type = AccountType.ServicePrincipal;

                    account.SetProperty(PartnerAccountPropertyType.ApplicationId, Credential.UserName);
                    account.SetProperty(PartnerAccountPropertyType.ServicePrincipalSecret, Credential.Password.ConvertToString());
                }
                else
                {
                    account.Type = AccountType.User;
                }

                if (UseDeviceAuthentication.IsPresent)
                {
                    account.SetProperty("UseDeviceAuth", "true");
                }

                account.SetProperty(
                    PartnerAccountPropertyType.Scope,
                    ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase) ?
                        $"{environment.AzureAdGraphEndpoint}/.default" :
                        $"{environment.PartnerCenterEndpoint}/user_impersonation");

                account.Tenant = string.IsNullOrEmpty(Tenant) ? "organizations" : Tenant;

                await PartnerSession.Instance.AuthenticationFactory.AuthenticateAsync(
                    account,
                    environment,
                    new[] { account.GetProperty(PartnerAccountPropertyType.Scope) },
                    Message,
                    CancellationToken).ConfigureAwait(false);

                PartnerSession.Instance.Context = new PartnerContext
                {
                    Account = account,
                    Environment = environment
                };

                try
                {
                    partnerOperations = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId).ConfigureAwait(false);
                    profile = await partnerOperations.Profiles.OrganizationProfile.GetAsync().ConfigureAwait(false);

                    PartnerSession.Instance.Context.CountryCode = profile.DefaultAddress.Country;
                    PartnerSession.Instance.Context.Locale = profile.Culture;
                }
                catch (PartnerException)
                {
                    /* This error can safely be ignored */
                }

                WriteObject(PartnerSession.Instance.Context);
            });
        }
    }
}