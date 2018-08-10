// -----------------------------------------------------------------------
// <copyright file="ConnectPartnerCenter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Security;
    using Authentication;
    using Factories;
    using Properties;

    /// <summary>
    /// Cmdlet to log into a Partner Center environment.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "PartnerCenter"), OutputType(typeof(PartnerContext))]
    public class ConnectPartnerCenter : PSCmdlet, IModuleAssemblyInitializer
    {
        /// <summary>
        /// Gets or sets the application identifier used to access the Partner Center API.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The application identifier used to access the Partner Center API.")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the optional user credentials to used during the authentication request.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then the user will be prompted for credentials.
        /// </remarks>
        [Parameter(Mandatory = false, ParameterSetName = "UserCredential")]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the optional envrionment name used during the authentication request.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified the default Global Cloud envrionment will be used.
        /// </remarks>
        [Parameter(Mandatory = false, HelpMessage = "Name of the environment containing the account to log into")]
        [Alias("EnvironmentName")]
        [ValidateNotNullOrEmpty]
        public EnvironmentName Environment { get; set; }

        /// <summary>
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (!PartnerEnvironment.PublicEnvironments.ContainsKey(Environment))
            {
                throw new PSInvalidOperationException(Resources.InvalidEnvironmentException);
            }
        }

        /// <summary>
        /// Operations that are performed when the Partner Center module is imported.
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
            SecureString password = null;
            string username = string.Empty;

            if (Credential != null)
            {
                password = Credential.Password;
                username = Credential.UserName;
            }

            PartnerProfile.Instance.Context = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                ApplicationId,
                Environment,
                username,
                password,
                "common");

            WriteObject(PartnerProfile.Instance.Context);
        }
    }
}