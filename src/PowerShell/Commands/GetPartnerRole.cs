// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Roles;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// Get a list of partner roles.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerRole")]
    [OutputType(typeof(PSRole))]
    public class GetPartnerRole : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                SeekBasedResourceCollection<Role> roles = await partner.Roles.GetAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(roles.Items.Select(r => new PSRole(r)), true);
            }, true);
        }
    }
}