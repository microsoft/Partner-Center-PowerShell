﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Reflection;
    using Extensions;
    using Factories;
    using Microsoft.Store.PartnerCenter.Exceptions;
    using Models;
    using Models.Authentication;
    using PartnerCenter.Models.Partners;
    using Properties;

    /// <summary>
    /// Cmdlet to log into a Partner Center environment.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "PartnerCenter", DefaultParameterSetName = UserParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PartnerContext))]
    public class ConnectPartnerCenter : PSCmdlet, IModuleAssemblyInitializer
    {
        /// <summary>
        /// The name of the access token parameter set.
        /// </summary>
        private const string AccessTokenParameterSet = "AccessToken";

        /// <summary>
        /// The name of the configuration property.
        /// </summary>
        private const string ConfigurationProperty = "Configuration";

        /// <summary>
        /// The value used to identify the client connect to the partner service.
        /// </summary>
        private const string PartnerCenterClient = "Partner Center PowerShell";

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
        /// Event handle for the write warning event.
        /// </summary>
        private event EventHandler<StreamEventArgs> writeWarningEvent;

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [Parameter(HelpMessage = "The access token for Partner Center.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "SPN")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the certificate thumbprint.
        /// </summary>
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        public string CertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the service principal credential.
        /// </summary>
        [Parameter(HelpMessage = "Application identifier and secret for service principal credentials.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "Application identifier and secret for service principal credentials.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not multi-factor authentication is enforced.
        /// </summary>
        [Parameter(HelpMessage = "A flag indicating whether or not multi-factor authentication is enforced. The is only configurable while the Partner Center API is not requiring multi-factor authentication.", Mandatory = false)]
        public SwitchParameter EnforceMFA { get; set; }

        /// <summary>
        /// Gets or sets the environment used for authentication.
        /// </summary>
        [Parameter(HelpMessage = "Environment containing the account to log into.", Mandatory = false)]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not a service principal is being used.
        /// </summary>
        [Parameter(HelpMessage = "Indicates that this account authenticates by providing service principal credentials.", ParameterSetName = ServicePrincipalParameterSet, Mandatory = true)]
        [Parameter(HelpMessage = "Indicates that this account authenticates by providing service principal credentials", ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = false)]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Alias("Domain", "TenantId")]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false, ParameterSetName = UserParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether not the device code flow should be used.
        /// </summary>
        [Alias("DeviceCode", "DeviceAuth", "Device")]
        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Use device code authentication instead of a browser control")]
        public SwitchParameter UseDeviceAuthentication { get; set; }

        protected override void BeginProcessing()
        {
            writeWarningEvent -= WriteWarningSender;
            writeWarningEvent += WriteWarningSender;

            PartnerSession.Instance.RegisterComponent("WriteWarning", () => writeWarningEvent);
        }

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
        }

        /// <summary>
        /// Performs the operations associated with the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            PartnerAccount account = new PartnerAccount();
            IPartner partnerOperations;
            OrganizationProfile profile;

            WriteDebug(string.Format(CultureInfo.CurrentCulture, Resources.ConnectPartnerCenterBeginProcess, ParameterSetName));

            PartnerService.Instance.EnforceMfa = (EnforceMFA.IsPresent && EnforceMFA.ToBool());

            if (ParameterSetName.Equals(AccessTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.ExtendedProperties[PartnerAccountPropertyType.AccessToken] = AccessToken;
                account.Type = AccountType.AccessToken;
            }
            else if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Id = Credential.UserName;
                account.ExtendedProperties[PartnerAccountPropertyType.ServicePrincipalSecret] = Credential.Password.ConvertToString();
                account.Type = AccountType.ServicePrincipal;
            }
            else
            {
                account.Type = AccountType.User;
            }

            if (!string.IsNullOrEmpty(ApplicationId))
            {
                account.Id = ApplicationId;
            }

            if (UseDeviceAuthentication.IsPresent)
            {
                account.SetProperty("UseDeviceAuth", "true");
            }

            account.SetProperty(PartnerAccountPropertyType.Tenant, string.IsNullOrEmpty(Tenant) ? "common" : Tenant);

            PartnerSession.Instance.Context = new PartnerContext
            {
                Account = account,
                Environment = PartnerEnvironment.PublicEnvironments[Environment]
            };

            account.SetProperty(
                PartnerAccountPropertyType.Scope, 
                ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase) ?
                    $"{PartnerSession.Instance.Context.Environment.AzureAdGraphEndpoint}/.default" :
                    $"{PartnerSession.Instance.Context.Environment.PartnerCenterEndpoint}/user_impersonation");

            PartnerSession.Instance.AuthenticationFactory.Authenticate(
                account,
                PartnerSession.Instance.Context.Environment,
                account.GetProperty(PartnerAccountPropertyType.ServicePrincipalSecret),
                new[] { account.GetProperty(PartnerAccountPropertyType.Scope) },
                account.GetProperty(PartnerAccountPropertyType.Tenant));

            try
            {
                partnerOperations = PartnerSession.Instance.ClientFactory.CreatePartnerOperations();
                profile = partnerOperations.Profiles.OrganizationProfile.GetAsync().GetAwaiter().GetResult();

                PartnerSession.Instance.Context.CountryCode = profile.DefaultAddress.Country;
                PartnerSession.Instance.Context.Locale = profile.Culture;
            }
            catch (PartnerException ex)
            {
                /* 
                 * This exception can occurr if authenticatiing using a service principal because 
                 * these operations do not support app only authentication
                 */

                WriteDebug(ex.Message);
            }

            WriteObject(PartnerSession.Instance.Context);
        }

        private void WriteWarningSender(object sender, StreamEventArgs args)
        {
            WriteWarning(args.Message);
        }
    }
}