// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.New, "PartnerAccessToken")]
    [OutputType(typeof(AuthenticationResult))]
    public class NewPartnerAccessToken : PSCmdlet
    {
        /// <summary>
        /// The name of the access token parameter set.
        /// </summary>
        private const string AccessTokenParameterSet = "AccessToken";

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
        [Parameter(HelpMessage = "The access token for Partner Center.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        [Parameter(ParameterSetName = AccessTokenParameterSet, Mandatory = true, HelpMessage = "Account identifier for access token")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the certificate thumbprint.
        /// </summary>
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = true, HelpMessage = "Certificate Hash (Thumbprint)")]
        public string CertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the service principal credential.
        /// </summary>
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the environment used for authentication.
        /// </summary>
        [Parameter(HelpMessage = "The environment use for authentication.", Mandatory = false)]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets the scopes used for authentication.
        /// </summary>
        [Parameter(HelpMessage = "Scopes requested to access a protected API.", Mandatory = true)]
        public string[] Scopes { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not a service principal is being used.
        /// </summary>
        [Parameter(ParameterSetName = ServicePrincipalParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = ServicePrincipalCertificateParameterSet, Mandatory = false)]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Alias("Domain")]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false, ParameterSetName = UserParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the authorization code flow should be used.
        /// </summary>
        [Alias("AuthCode")]
        [Parameter(HelpMessage = "Use the authorization code flow during authentication.", Mandatory = false)]
        public SwitchParameter UseAuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the device code flow should be used.
        /// </summary>
        [Alias("DeviceCode", "DeviceAuth", "Device")]
        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Use device code authentication instead of a browser control")]
        public SwitchParameter UseDeviceAuthentication { get; set; }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            PartnerAccount account = new PartnerAccount();

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

            if (UseAuthorizationCode.IsPresent)
            {
                account.SetProperty("UseAuthCode", "true");
            }

            if (UseDeviceAuthentication.IsPresent)
            {
                account.SetProperty("UseDeviceAuth", "true");
            }

            account.SetProperty(PartnerAccountPropertyType.Tenant, string.IsNullOrEmpty(TenantId) ? "common" : TenantId);

            AuthenticationToken result = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                account,
                PartnerEnvironment.PublicEnvironments[Environment],
                account.ExtendedProperties[PartnerAccountPropertyType.ServicePrincipalSecret],
                Scopes,
                account.GetProperty(PartnerAccountPropertyType.Tenant));

            WriteObject(result);
        }
    }
}