// -----------------------------------------------------------------------
// <copyright file="PartnerPSCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Exceptions;
    using Profile;
    using Properties;

    /// <summary>
    /// Represents base class for all Partner Center cmdlets.
    /// </summary>
    public abstract class PartnerPSCmdlet : PSCmdlet
    {
        /// <summary>
        /// Gets the parnter's execution context.
        /// </summary>
        /// <exception cref="PSInvalidOperationException">
        /// Connect-PartnerCenter has not been successfully executed.
        /// </exception>
        internal static PartnerContext Context
        {
            get
            {
                if (PartnerSession.Instance.Context == null)
                {
                    throw new PSInvalidOperationException(Resources.RunConnectPartnerCenter);
                }

                return PartnerSession.Instance.Context;
            }
        }

        /// <summary>
        /// Gets the available Partner Center operations.
        /// </summary>
        internal IPartner CorePartner { get; private set; }

        /// <summary>
        /// Gets the available Partner Center operations.
        /// </summary>
        internal PartnerCenter.IPartner Partner { get; private set; }
 

        /// <summary>
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            CorePartner = PartnerSession.Instance.ClientFactory.CreateCorePartnerOperations(Context);
            Partner = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(Context);
        }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

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

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public virtual void ExecuteCmdlet()
        {
        }
    }
}