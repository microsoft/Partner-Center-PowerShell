// -----------------------------------------------------------------------
// <copyright file="PartnerPSCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using Authentication;
    using Exceptions;
    using Properties;

    /// <summary>
    /// Represents base class for the Partner Center cmdlets.
    /// </summary>
    public abstract class PartnerPSCmdlet : PSCmdlet
    {
        /// <summary>
        /// Gets the available Partner Center operations.
        /// </summary>
        internal IPartner Partner { get; private set; }

        /// <summary>
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public virtual AuthenticationTypes SupportedAuthentication => AuthenticationTypes.Both;

        /// <summary>
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (PartnerSession.Instance.Context == null)
            {
                throw new PSInvalidOperationException(Resources.RunConnectPartnerCenter);
            }

            Partner = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(d => WriteDebug(d));
        }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (SupportedAuthentication.HasFlag(PartnerSession.Instance.Context.AuthenticationType))
            {
                try
                {
                    ExecuteCmdlet();
                }
                catch (PartnerCenter.Exceptions.PartnerException ex)
                {
                    if (ex.ServiceErrorPayload != null)
                    {
                        throw new PartnerPSException($"{ex.ServiceErrorPayload.ErrorCode} {ex.ServiceErrorPayload.ErrorMessage}");
                    }

                    throw;
                }
            }
            else
            {
                throw new PSPartnerException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticationTypeNotSupportedException,
                        PartnerSession.Instance.Context.AuthenticationType.ToString(),
                        SupportedAuthentication.ToString()));
            }
        }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public virtual void ExecuteCmdlet()
        {
        }
    }
}