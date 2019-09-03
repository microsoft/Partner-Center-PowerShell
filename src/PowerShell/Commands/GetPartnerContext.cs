// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.Get, "PartnerContext")]
    [OutputType(typeof(PartnerContext))]
    public class GetPartnerContext : ContextPSCmdlet
    {
        protected override void ProcessRecord()
        {
            if (PartnerSession.Instance.Context == null)
            {
                return;
            }

            WriteObject(PartnerSession.Instance.Context);
        }
    }
}