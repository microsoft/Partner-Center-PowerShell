// -----------------------------------------------------------------------
// <copyright file="ConnectPartnerCenter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
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
    [Cmdlet(VerbsCommunications.Connect, "PartnerCenter", DefaultParameterSetName = "UserCredential")]
    [OutputType(typeof(PartnerContext))]
    public class ConnectPartnerCenter : PSCmdlet, IModuleAssemblyInitializer
    {
        /// <summary>
        /// The name of the access token parameter set.
        /// </summary>
        private const string AccessTokenParameterSet = "AccessToken";

        /// <summary>
        /// The common endpoint address.
        /// </summary>
        private const string CommonEndpoint = "common";

        /// <summary>
        /// The name of the service principal parameter set.
        /// </summary>
        private const string ServicePrincipalParameterSet = "ServicePrincipal";

        /// <summary>
        /// The name of the user credential parameter set.
        /// </summary>
        private const string UserCredentialParameterSet = "UserCredential";

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [Parameter(HelpMessage = "The access token for Partner Center.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the application identifier used to access Partner Center.
        /// </summary>
        [Parameter(HelpMessage = "The application identifier used to access Partner Center.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The application identifier used to access Partner Center.", Mandatory = true, ParameterSetName = UserCredentialParameterSet)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the optional user credentials to used during the authentication request.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then the user will be prompted for credentials.
        /// </remarks>
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the optional envrionment name used during the authentication request.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified the default Global Cloud envrionment will be used.
        /// </remarks>
        [Parameter(Mandatory = false, HelpMessage = "Name of the environment to be used during authentication.")]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that a service principal will be used to authenticate.
        /// </summary
        [Parameter(HelpMessage = "A flag indicating that a service principal will be used to authenticate.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the Azure AD domain or tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The Azure AD domain or tenant identifier.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The Azure AD domain or tenant identifier.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (!PartnerEnvironment.PublicEnvironments.ContainsKey(Environment))
            {
                throw new PSInvalidOperationException(Resources.InvalidEnvironmentException);
            }

            PartnerSession.Instance.Context = null;
        }

        /// <summary>
        /// Operations that are performed when the module is imported.
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
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            AzureAccount account = new AzureAccount();
            IPartner partnerOperations;
            OrganizationProfile profile;

            if (ParameterSetName.Equals(AccessTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Properties[AzureAccountPropertyType.AccessToken] = AccessToken;
                account.Type = AccountType.AccessToken;
            }
            else if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Id = Credential.UserName;
                account.Properties[AzureAccountPropertyType.ServicePrincipalSecret] = Credential.Password.ConvertToString();
                account.Type = AccountType.ServicePrincipal;
            }
            else
            {
                account.Type = AccountType.User;
            }

            account.Properties[AzureAccountPropertyType.Tenant] = string.IsNullOrEmpty(TenantId) ? CommonEndpoint : TenantId;

            PartnerContext context = new PartnerContext
            {
                Account = account,
                ApplicationId = ApplicationId,
                Environment = Environment
            };

            PartnerSession.Instance.AuthenticationFactory.Authenticate(context, d => WriteDebug(d), p => WriteWarning(p));

            PartnerSession.Instance.Context = context;

            if (context.Account.Type == AccountType.User)
            {
                partnerOperations = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(context, d => WriteDebug(d));
                profile = partnerOperations.Profiles.OrganizationProfile.Get();

                context.CountryCode = profile.DefaultAddress.Country;
                context.Locale = profile.Culture;
            }

            WriteObject(PartnerSession.Instance.Context);
        }
    }
}