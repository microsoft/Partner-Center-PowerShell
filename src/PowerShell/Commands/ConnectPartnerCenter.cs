// -----------------------------------------------------------------------
// <copyright file="ConnectPartnerCenter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Reflection;
    using System.Security;
    using System.Text.RegularExpressions;
    using Common;
    using Factories;
    using PartnerCenter.Models.Partners;
    using Profile;
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
        /// The name of the assembly version property.
        /// </summary>
        private const string AssemblyVersionProperty = "AssemblyVersion";

        /// <summary>
        /// The name of the configuration property.
        /// </summary>
        private const string ConfigurationProperty = "Configuration";

        /// <summary>
        /// The value used to identify the client connect to the partner service.
        /// </summary>
        private const string PartnerCenterClient = "Partner Center PowerShell";

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
        /// Gets or sets the date and time when the token for Partner Center expires.
        /// </summary>
        [Parameter(HelpMessage = "The date and time when the token for Partner Center expires.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        public DateTimeOffset AccessTokenExpiresOn { get; set; }

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
        [Parameter(HelpMessage = "User credentials to be used for authentication.", Mandatory = false, ParameterSetName = UserCredentialParameterSet)]
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
            PropertyInfo prop = PartnerService.Instance.GetType().GetProperty(
                ConfigurationProperty,
                BindingFlags.Instance | BindingFlags.NonPublic);

            dynamic configuration = prop.GetValue(PartnerService.Instance);

            // Override the value for the Partner Center client property.
            configuration.PartnerCenterClient = PartnerCenterClient;

            prop = PartnerService.Instance.GetType().GetProperty(
                AssemblyVersionProperty,
                BindingFlags.Instance | BindingFlags.NonPublic);

            // Override the value for the assembly version property.
            prop.SetValue(PartnerService.Instance, typeof(ConnectPartnerCenter).Assembly.GetName().Version.ToString());

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
            IAggregatePartner partnerOperations;
            OrganizationProfile profile;
            SecureString password = null;

            if (ParameterSetName.Equals(AccessTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Properties[AzureAccountPropertyType.AccessToken] = AccessToken;
                account.Properties[AzureAccountPropertyType.AccessTokenExpiration] = AccessTokenExpiresOn.ToString(CultureInfo.CurrentCulture);
                account.Type = AccountType.AccessToken;
            }
            else if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Properties[AzureAccountPropertyType.ServicePrincipalSecret] = Credential.Password.ConvertToString();
                account.Type = AccountType.ServicePrincipal;
            }
            else
            {
                account.Type = AccountType.User;
            }

            if (Credential != null)
            {
                account.Id = Credential.UserName;
                password = Credential.Password;
            }

            account.Properties[AzureAccountPropertyType.Tenant] = string.IsNullOrEmpty(TenantId) ? CommonEndpoint : TenantId;

            PartnerContext context = new PartnerContext
            {
                Account = account,
                ApplicationId = ApplicationId,
                Environment = Environment
            };

            PartnerSession.Instance.AuthenticationFactory.Authenticate(context, password);

            PartnerSession.Instance.Context = context;

            if (context.Account.Type == AccountType.User)
            {
                partnerOperations = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(context);
                profile = partnerOperations.Profiles.OrganizationProfile.Get();

                context.CountryCode = profile.DefaultAddress.Country;
                context.Locale = profile.Culture;
            }

            WriteObject(PartnerSession.Instance.Context);
        }
    }
}