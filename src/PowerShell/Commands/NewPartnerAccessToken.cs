// -----------------------------------------------------------------------
// <copyright file="NewPartnerAccessToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Net.Http;
    using System.Text.RegularExpressions;
#if !NETSTANDARD
    using System.Web;
#endif
    using Authentication;
    using Extensions;
    using Network;
    using PartnerCenter.Models.Authentication;
#if !NETSTANDARD
    using Platforms;
#endif

    [Cmdlet(VerbsCommon.New, "PartnerAccessToken", DefaultParameterSetName = UserParameterSet)]
    [OutputType(typeof(AuthenticationResult))]
    public class NewPartnerAccessToken : PSCmdlet
    {
        /// <summary>
        /// The name of the service principal parameter set.
        /// </summary>
        private const string ServicePrincipalParameterSet = "ServicePrincipal";

        /// <summary>
        /// The name of the user parameter set.
        /// </summary>
        private const string UserParameterSet = "User";

        /// <summary>
        /// The client used to perform HTTP operations.
        /// </summary>
        private readonly static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the Azure AD application.", Mandatory = false, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The identifier for the Azure AD application.", Mandatory = true, ParameterSetName = UserParameterSet)]
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
        [Parameter(HelpMessage = "Credentials that represents the service principal.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
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
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The identifier of the Azure AD tenant.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            AuthenticationResult authResult;
            AzureAccount account = new AzureAccount();
#if NETSTANDARD
            DeviceCodeResult deviceCodeResult;
#else
            AuthorizationResult authorizationResult;
#endif
            IPartnerServiceClient client;
            PartnerEnvironment environment;
            Uri authority;
            string clientId;
            string resource;

            if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                account.Properties[AzureAccountPropertyType.ServicePrincipalSecret] = Credential.Password.ConvertToString();
                account.Type = AccountType.ServicePrincipal;
                clientId = string.IsNullOrEmpty(ApplicationId) ? Credential.UserName : ApplicationId;
            }
            else
            {
                account.Type = AccountType.User;
                clientId = ApplicationId;
            }

            account.Properties[AzureAccountPropertyType.Tenant] = string.IsNullOrEmpty(TenantId) ? AuthenticationConstants.CommonEndpoint : TenantId;
            environment = PartnerEnvironment.PublicEnvironments[Environment];

            client = new PartnerServiceClient(httpClient);
            authority = new Uri($"{environment.ActiveDirectoryAuthority}{account.Properties[AzureAccountPropertyType.Tenant]}");

            resource = string.IsNullOrEmpty(Resource) ? environment.PartnerCenterEndpoint : Resource;

            if (!string.IsNullOrEmpty(RefreshToken))
            {
                authResult = client.RefreshAccessTokenAsync(
                    authority,
                    resource,
                    RefreshToken,
                    clientId,
                    Credential?.Password.ConvertToString()).GetAwaiter().GetResult();
            }
            else if (account.Type == AccountType.ServicePrincipal && !Consent.ToBool())
            {
                authResult = client.AcquireTokenAsync(
                    authority,
                    resource,
                    clientId,
                    Credential.Password.ConvertToString()).GetAwaiter().GetResult();
            }
#if NETSTANDARD
            else
            {
                deviceCodeResult = client.AcquireDeviceCodeAsync(
                    authority,
                    resource,
                    clientId,
                    Credential?.Password.ConvertToString()).GetAwaiter().GetResult();

                WriteWarning(deviceCodeResult.Message);

                authResult = client.AcquireTokenByDeviceCodeAsync(
                    authority,
                    deviceCodeResult,
                    Credential?.Password.ConvertToString()).GetAwaiter().GetResult();
            }
#else
            else
            {
                using (WindowsFormsWebAuthenticationDialog dialog = new WindowsFormsWebAuthenticationDialog(null))
                {
                    authorizationResult = dialog.AuthenticateAAD(
                        new Uri($"{environment.ActiveDirectoryAuthority}{account.Properties[AzureAccountPropertyType.Tenant]}/oauth2/authorize?resource={HttpUtility.UrlEncode(Resource)}&client_id={clientId}&response_type=code&haschrome=1&redirect_uri={HttpUtility.UrlEncode(AuthenticationConstants.RedirectUriValue)}&response_mode=form_post&prompt=login"),
                        new Uri(AuthenticationConstants.RedirectUriValue));
                }

                authResult = client.AcquireTokenByAuthorizationCodeAsync(
                    authority,
                    resource,
                    new Uri(AuthenticationConstants.RedirectUriValue),
                    authorizationResult.Code,
                    clientId,
                    Credential?.Password.ConvertToString()).GetAwaiter().GetResult();
            }
#endif

            WriteObject(authResult);
        }
    }
}