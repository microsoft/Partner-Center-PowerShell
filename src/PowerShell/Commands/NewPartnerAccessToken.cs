// -----------------------------------------------------------------------
// <copyright file="NewPartnerAccessToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using System.Web;
    using Common;
    using Models.Authentication;
    using Network;
    using Platform;
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
        /// The value for the redirect URI.
        /// </summary>
        private const string redirectUriValue = "urn:ietf:wg:oauth:2.0:oob";

        /// <summary>
        /// The redirect URI used when requesting an access token.
        /// </summary>
        private readonly Uri redirectUri = new Uri(redirectUriValue);

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "The application identifier used to access Partner Center.", Mandatory = true, ParameterSetName = "UserCredential")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that the intention is to perform the partner consent process.
        /// </summary>
        [Parameter(HelpMessage = "A flag that indicates that the intention is to perform the partner consent process.", Mandatory = false)]
        public SwitchParameter Consent { get; set; }

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
        /// Gets or sets the refresh token to use in the refresh flow.
        /// </summary>
        [Parameter(HelpMessage = "The refresh token to use in the refresh flow.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the target resource that is the recipient of the requested token.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the target resource that is the recipient of the requested token.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Resource { get; set; } = "https://api.partnercenter.microsoft.com"

        /// <summary>
        /// Gets or sets a flag indicating that a service principal will be used to authenticate.
        /// </summary
        [Parameter(HelpMessage = "A flag indicating that a service principal will be used to authenticate.", Mandatory = true, ParameterSetName = "ServicePrincipal")]
        public SwitchParameter ServicePrincipal { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The Azure AD domain or tenant identifier.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            AuthenticationResult authResult;
            AzureAccount account = new AzureAccount();
            IPartnerServiceClient client;
            PartnerEnvironment environment;
            AuthorizationResult authorizationResult;
            string authority;
            string clientId; 

            if (ParameterSetName.Equals("ServicePrincipal", StringComparison.InvariantCultureIgnoreCase))
            {
                account.Properties[AzureAccountPropertyType.ServicePrincipalSecret] = Credential.Password.ConvertToString();
                account.Type = AccountType.ServicePrincipal;
            }
            else
            {
                account.Type = AccountType.User;
            }

            account.Properties[AzureAccountPropertyType.Tenant] = string.IsNullOrEmpty(TenantId) ? CommonEndpoint : TenantId;
            environment = PartnerEnvironment.PublicEnvironments[Environment];

            client = new PartnerServiceClient(new Uri(environment.PartnerCenterEndpoint));
            authority = $"{environment.ActiveDirectoryAuthority}{account.Properties[AzureAccountPropertyType.Tenant]}/oauth2/token";

            clientId = account.Type == AccountType.ServicePrincipal ? Credential.UserName : ApplicationId;

            if (!string.IsNullOrEmpty(RefreshToken))
            {
                authResult = client.RefreshAccessTokenAsync(
                    authority,
                    Resource,
                    RefreshToken,
                    clientId,
                    Credential?.Password.ConvertToString()).GetAwaiter().GetResult();
            }
            else if (account.Type == AccountType.ServicePrincipal && !Consent.IsPresent || Consent.ToBool() == false)
            {
                authResult = client.AcquireTokenAsync(
                    authority,
                    Resource,
                    clientId,
                    Credential.Password.ConvertToString()).GetAwaiter().GetResult();
            }
            else
            {
                using (WindowsFormsWebAuthenticationDialog dialog = new WindowsFormsWebAuthenticationDialog(null))
                {
                    authorizationResult = dialog.AuthenticateAAD(
                        new Uri($"{environment.ActiveDirectoryAuthority}{account.Properties[AzureAccountPropertyType.Tenant]}/oauth2/authorize?resource={HttpUtility.UrlEncode(Resource)}&client_id={clientId}&response_type=code&haschrome=1&redirect_uri={HttpUtility.UrlEncode(redirectUriValue)}&response_mode=form_post&prompt=login"),
                        redirectUri);
                }

                authResult = client.AcquireTokenByAuthorizationCodeAsync(
                    authority,
                    Resource,
                    redirectUri,
                    authorizationResult.Code,
                    clientId,
                    Credential?.Password.ConvertToString()).GetAwaiter().GetResult();
            }

            WriteObject(authResult);
        }
    }
}
