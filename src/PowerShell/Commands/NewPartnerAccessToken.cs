// -----------------------------------------------------------------------
// <copyright file="NewPartnerAccessToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Security;
    using System.Text.RegularExpressions;
    using Common;
    using IdentityModel.Clients.ActiveDirectory;
    using Profile;

    [Cmdlet(VerbsCommon.New, "PartnerAccessToken", DefaultParameterSetName = "UserCredential")]
    [OutputType(typeof(AuthenticationResult))]
    public class NewPartnerAccessToken : PSCmdlet
    {
        /// <summary>
        /// The common endpoint used during authentication.
        /// </summary>
        private const string CommonEndpoint = "common";

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "The application identifier used to access Partner Center.", Mandatory = true, ParameterSetName = "UserCredential")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the credentials.
        /// </summary>
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        [Parameter(HelpMessage = "User credentials to be used for authentication.", Mandatory = false, ParameterSetName = "UserCredential")]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Name of the environment to be used during authentication.")]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that a service principal will be used to authenticate.
        /// </summary
        [Parameter(HelpMessage = "A flag indicating that a service principal will be used to authenticate.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The Azure AD domain or tenant identifier.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the token cache.
        /// </summary>
        [Parameter(HelpMessage = "The token cache to be used when requesting an access token.", Mandatory = false)]
        [ValidateNotNull]
        public TokenCache TokenCache { get; set; }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            AuthenticationResult authResult;
            AzureAccount account = new AzureAccount();
            SecureString password = null;


            if (ParameterSetName.Equals("ServicePrincipal", StringComparison.InvariantCultureIgnoreCase))
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

            authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                ApplicationId,
                account,
                password,
                Environment,
                TokenCache ?? TokenCache.DefaultShared);

            WriteObject(authResult);
        }
    }
}