// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;
    using Newtonsoft.Json.Linq;
    using Utilities;

    [Cmdlet(VerbsCommon.New, "PartnerAccessToken")]
    [OutputType(typeof(AuthResult))]
    public class NewPartnerAccessToken : PartnerAsyncCmdlet
    {
        /// <summary>
        /// The name of the access token parameter set.
        /// </summary>
        private const string AccessTokenParameterSet = "AccessToken";

        /// <summary>
        /// The name of the by module parameter set.
        /// </summary>
        private const string ByModuleParameterSet = "ByModule";

        /// <summary>
        /// The message written to the console.
        /// </summary>
        private const string Message = "We have launched a browser for you to login. For the old experience with device code flow, please run 'New-PartnerAccessToken -UseDeviceAuthentication'.";

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
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "The application identifier to be used during authentication.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "The application identifier to be used during authentication.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "The application identifier to be used during authentication.", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        [Parameter(HelpMessage = "The application identifier to be used during authentication.", Mandatory = true, ParameterSetName = UserParameterSet)]
        [Alias("ClientId")]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the certificate thumbprint.
        /// </summary>
        [Parameter(HelpMessage = "Certificate Hash (Thumbprint)", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
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
        /// Gets or sets the module that an access token is being generated.
        /// </summary>
        [Parameter(HelpMessage = "The module that an access token is being generated.", Mandatory = true, ParameterSetName = ByModuleParameterSet)]
        [Alias("ModuleName")]
        [ValidateSet(nameof(ModuleName.ExchangeOnline))]
        public ModuleName Module { get; set; }

        /// <summary>
        /// Gets or sets the refresh token to use during authentication.
        /// </summary>
        [Parameter(HelpMessage = "The refresh token to use during authentication.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the scopes used for authentication.
        /// </summary>
        [Parameter(HelpMessage = "Scopes requested to access a protected API.", Mandatory = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(HelpMessage = "Scopes requested to access a protected API.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "Scopes requested to access a protected API.", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        [Parameter(HelpMessage = "Scopes requested to access a protected API.", Mandatory = true, ParameterSetName = UserParameterSet)]
        public string[] Scopes { get; set; }

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
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = false, ParameterSetName = ByModuleParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = true, ParameterSetName = ServicePrincipalCertificateParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(HelpMessage = "Identifier or name for the tenant.", Mandatory = false, ParameterSetName = UserParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

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
        [Parameter(ParameterSetName = UserParameterSet, Mandatory = false, HelpMessage = "Use device code authentication instead of a browser control.")]
        public SwitchParameter UseDeviceAuthentication { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                PartnerAccount account = new PartnerAccount();
                string applicationId;

                if (ParameterSetName.Equals(AccessTokenParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    account.SetProperty(PartnerAccountPropertyType.AccessToken, AccessToken);
                    account.Type = AccountType.AccessToken;
                    applicationId = ApplicationId;
                }
                else if (ParameterSetName.Equals(ByModuleParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    account.SetProperty(PartnerAccountPropertyType.UseDeviceAuth, "true");
                    account.Type = AccountType.User;
                    applicationId = PowerShellModule.KnownModules[Module].ApplicationId;

                    Scopes = PowerShellModule.KnownModules[Module].Scopes.ToArray();
                }
                else if (ParameterSetName.Equals(ServicePrincipalParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    account.ObjectId = Credential.UserName;
                    account.SetProperty(PartnerAccountPropertyType.ServicePrincipalSecret, Credential.Password.ConvertToString());
                    account.Type = AccountType.ServicePrincipal;
                    applicationId = ApplicationId;
                }
                else
                {
                    account.Type = AccountType.User;
                    applicationId = ApplicationId;
                }

                if (!ParameterSetName.Equals(ByModuleParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (UseAuthorizationCode.IsPresent)
                    {
                        account.SetProperty(PartnerAccountPropertyType.UseAuthCode, "true");
                    }

                    if (UseDeviceAuthentication.IsPresent)
                    {
                        account.SetProperty(PartnerAccountPropertyType.UseDeviceAuth, "true");
                    }
                }

                if (!string.IsNullOrEmpty(RefreshToken))
                {
                    account.SetProperty(PartnerAccountPropertyType.RefreshToken, RefreshToken);
                }

                account.SetProperty(PartnerAccountPropertyType.ApplicationId, applicationId);
                account.Tenant = string.IsNullOrEmpty(Tenant) ? "organizations" : Tenant;

                AuthenticationResult authResult = await PartnerSession.Instance.AuthenticationFactory.AuthenticateAsync(
                    account,
                    PartnerEnvironment.PublicEnvironments[Environment],
                    Scopes,
                    Message,
                    CancellationToken).ConfigureAwait(false);

                AuthResult result = new AuthResult(
                    authResult.AccessToken,
                    authResult.IsExtendedLifeTimeToken,
                    authResult.UniqueId,
                    authResult.ExpiresOn,
                    authResult.ExtendedExpiresOn,
                    authResult.TenantId,
                    authResult.Account,
                    authResult.IdToken,
                    authResult.Scopes,
                    authResult.CorrelationId);

                byte[] cacheData = null;

                if (PartnerSession.Instance.TryGetComponent(ComponentKey.TokenCache, out IPartnerTokenCache tokenCache))
                {
                    cacheData = tokenCache.GetCacheData();

                    if (cacheData?.Length > 0)
                    {
                        IEnumerable<string> knownPropertyNames = new[] { "AccessToken", "RefreshToken", "IdToken", "Account", "AppMetadata" };

                        JObject root = JObject.Parse(Encoding.UTF8.GetString(cacheData, 0, cacheData.Length));

                        IDictionary<string, JToken> known = (root as IDictionary<string, JToken>)
                            .Where(kvp => knownPropertyNames.Any(p => string.Equals(kvp.Key, p, StringComparison.OrdinalIgnoreCase)))
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                        IDictionary<string, TokenCacheItem> tokens = new Dictionary<string, TokenCacheItem>();

                        if (known.ContainsKey("RefreshToken"))
                        {
                            foreach (JToken token in root["RefreshToken"].Values())
                            {
                                if (token is JObject j)
                                {
                                    TokenCacheItem item = new TokenCacheItem
                                    {
                                        ClientId = ExtractExistingOrEmptyString(j, "client_id"),
                                        CredentialType = ExtractExistingOrEmptyString(j, "credential_type"),
                                        Environment = ExtractExistingOrEmptyString(j, "environment"),
                                        HomeAccountId = ExtractExistingOrEmptyString(j, "home_account_id"),
                                        RawClientInfo = ExtractExistingOrEmptyString(j, "client_info"),
                                        Secret = ExtractExistingOrEmptyString(j, "secret")
                                    };

                                    tokens.Add($"{item.HomeAccountId}-{item.Environment}-RefreshToken-{item.ClientId}--", item);
                                }
                            }
                        }

                        if (authResult.Account != null)
                        {
                            string key = tokenCache.GetCacheKey(authResult);

                            if (tokens.ContainsKey(key))
                            {
                                result.RefreshToken = tokens[key].Secret;
                            }
                        }
                    }
                    else
                    {
                        WriteDebug("There was not any data in the token cache, so a refresh token could not be retrieved.");
                    }
                }
                else
                {
                    WriteDebug("Unable to find a registered token cache.");
                }

                WriteObject(result);
            });
        }

        private static string ExtractExistingOrEmptyString(JObject json, string key)
        {
            if (json.TryGetValue(key, out JToken val))
            {
                json.Remove(key);
                return val.ToObject<string>(); ;
            }

            return string.Empty;
        }
    }
}