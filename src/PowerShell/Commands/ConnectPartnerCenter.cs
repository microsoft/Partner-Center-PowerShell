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
    using System.Security;
    using System.Text.RegularExpressions;
    using Common;
    using Factories;
    using IdentityModel.Clients.ActiveDirectory;
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
        /// The common endpoint address.
        /// </summary>
        private const string CommonEndpoint = "common";

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [Parameter(HelpMessage = "The access token for Partner Center.", Mandatory = true, ParameterSetName = "AccessToken")]
        [ValidateNotNullOrEmpty]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the token for Partner Center expires.
        /// </summary>
        [Parameter(HelpMessage = "The date and time when the token for Partner Center expires.", Mandatory = true, ParameterSetName = "AccessToken")]
        public DateTimeOffset AccessTokenExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the application identifier used to access Partner Center.
        /// </summary>
        [Parameter(HelpMessage = "The application identifier used to access Partner Center.", Mandatory = true, ParameterSetName = "AccessToken")]
        [Parameter(HelpMessage = "The application identifier used to access Partner Center.", Mandatory = true, ParameterSetName = "UserCredential")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the optional user credentials to used during the authentication request.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then the user will be prompted for credentials.
        /// </remarks>
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        [Parameter(HelpMessage = "User credentials to be used for authentication.", Mandatory = false, ParameterSetName = "UserCredential")]
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
        [Parameter(HelpMessage = "A flag indiicating that a service principal will be used to authenticate.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the Azure AD domain or tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The Azure AD domain or tenant identifier.", Mandatory = true, ParameterSetName = "AccessToken")]
        [Parameter(HelpMessage = "The Azure AD domain or tenant identifier.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the cache used to lookup cached tokens.
        /// </summary>
        [Parameter(HelpMessage = "The cache used to lookup cached tokens.", Mandatory = false)]
        [ValidateNotNull]
        public TokenCache TokenCache { get; set; }

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
            PartnerService.Instance.ApplicationName = "Partner Center PowerShell";

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

            if (ParameterSetName.Equals("AccessToken", StringComparison.InvariantCultureIgnoreCase))
            {
                account.Properties[AzureAccountPropertyType.AccessToken] = AccessToken;
                account.Properties[AzureAccountPropertyType.AccessTokenExpiration] = AccessTokenExpiresOn.ToString(CultureInfo.CurrentCulture);
                account.Type = AccountType.AccessToken;
            }
            else if (ParameterSetName.Equals("ServicePrincipal", StringComparison.InvariantCultureIgnoreCase))
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
                Environment = Environment,
                TokenCache = TokenCache ?? TokenCache.DefaultShared
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