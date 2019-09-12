// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;
    using Properties;

    [Cmdlet(VerbsCommunications.Disconnect, "PartnerCenter", SupportsShouldProcess = true)]
    public class DisconnectPartnerCenter : ContextPSCmdlet
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