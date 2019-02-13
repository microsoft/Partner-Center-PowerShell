// -----------------------------------------------------------------------
// <copyright file="DisconnectPartnerCenter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Authentication;
    using Properties;

    [Cmdlet(VerbsCommunications.Disconnect, "PartnerCenter", SupportsShouldProcess = true)]
    public class DisconnectPartnerCenter : PSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (ShouldProcess(Resources.DisconnectWhatIf))
            {
                PartnerSession.Instance.Context = null;
                PartnerService.Instance.EnforceMfa = false;
            }
        }
    }
}