// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Authentication;
    using Common;
    using Factories;
    using PartnerCenter.Models.Partners;
    using Properties;

    /// <summary>
    /// Cmdlet to log into a Partner Center environment.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "PartnerCenter", DefaultParameterSetName = UserParameterSet)]
    [OutputType(typeof(PartnerContext))]
    public class ConnectPartnerCenter : PSCmdlet, IModuleAssemblyInitializer
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
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the Azure AD application.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD application.", Mandatory = false, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD application.", Mandatory = true, ParameterSetName = UserParameterSet)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the service principal credential.
        /// </summary>
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
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
        [Parameter(HelpMessage = "The environment use for authentication.", Mandatory = false)]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false, ParameterSetName = UserParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Performs the required operations when the module is imported.
        /// </summary>
        public void OnImport()
        {
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
            AzureAccount account = new AzureAccount();
            IPartner partnerOperations;
            OrganizationProfile profile;

            WriteDebug(string.Format(CultureInfo.CurrentCulture, Resources.ConnectPartnerCenterBeginProcess, ParameterSetName));

            PartnerService.Instance.EnforceMfa = (EnforceMFA.IsPresent && EnforceMFA.ToBool());

            if (ParameterSetName.Equals(AccessTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Id = ApplicationId;
                account.Properties[AzureAccountPropertyType.AccessToken] = AccessToken;
                account.Type = AccountType.AccessToken;
            }
            else if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Id = string.IsNullOrEmpty(ApplicationId) ? Credential.UserName : ApplicationId;
                account.Properties[AzureAccountPropertyType.ServicePrincipalSecret] = Credential.Password.ConvertToString();
                account.Type = AccountType.ServicePrincipal;
            }
            else
            {
                account.Type = AccountType.User;
            }

            account.Properties[AzureAccountPropertyType.Tenant] = string.IsNullOrEmpty(TenantId) ? AuthenticationConstants.CommonEndpoint : TenantId;

            PartnerSession.Instance.Context = new PartnerContext
            {
                Account = account,
                ApplicationId = ApplicationId,
                Environment = Environment
            };

            PartnerSession.Instance.AuthenticationFactory.Authenticate(
                PartnerSession.Instance.Context,
                d => WriteDebug(d),
                w => WriteWarning(w));

            if (PartnerSession.Instance.Context.AuthenticationType == AuthenticationTypes.AppPlusUser)
            {
                partnerOperations = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(d => WriteDebug(d));
                profile = partnerOperations.Profiles.OrganizationProfile.GetAsync().GetAwaiter().GetResult();

                PartnerSession.Instance.Context.CountryCode = profile.DefaultAddress.Country;
                PartnerSession.Instance.Context.Locale = profile.Culture;
            }

            WriteObject(PartnerSession.Instance.Context);
        }
    }
}