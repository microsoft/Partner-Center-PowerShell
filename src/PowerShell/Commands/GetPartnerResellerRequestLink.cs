// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;
    using Models.CustomerRelationshipRequests;

    /// <summary>
    /// Get the resller relationship request link.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerResellerRequestLink")]
    [OutputType(typeof(PSCustomerRelationshipRequest))]
    public class GetPartnerResellerRequestLink : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                WriteObject(new PSCustomerRelationshipRequest(await partner.Customers.RelationshipRequest.GetAsync(CancellationToken).ConfigureAwait(false)));
            }, true);
        }
    }
}