// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Licenses;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Licenses;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscribedSku")]
    [OutputType(typeof(PSSubscribedSku))]
    public class GetPartnerCustomerSubscribedSku : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the license group identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the license group.", Mandatory = false)]
        [ValidateSet(nameof(LicenseGroupId.Group1), nameof(LicenseGroupId.Group2))]
        public LicenseGroupId[] LicenseGroup { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<SubscribedSku> subscribedSkus = await partner.Customers[CustomerId].SubscribedSkus.GetAsync(LicenseGroup?.Select(item => item).ToList(), CancellationToken).ConfigureAwait(false);

                WriteObject(subscribedSkus.Items.Select(s => new PSSubscribedSku(s)), true);
            }, true);

        }
    }
}