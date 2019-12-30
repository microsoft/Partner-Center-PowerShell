// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Entitlements;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Entitlements;

    /// <summary>
    /// Gets a list of entitlements for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerEntitlement")]
    [OutputType(typeof(PSEntitlement))]
    public class GetPartnerCustomerEntitlement : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a flag to indicate if the expiry date is required to be returned along with the entitlement (if applicable).
        /// </summary>
        [Parameter(HelpMessage = "A flag to indicate if the expiry date is required to be returned along with the entitlement (if applicable).", Mandatory = false)]
        public SwitchParameter ShowExpiry { get; set; }

        /// <summary>
        /// Gets or sets the optional order identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the order.", Mandatory = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<Entitlement> entitlements = await partner.Customers[CustomerId].Entitlements.GetAsync(ShowExpiry.ToBool(), CancellationToken).ConfigureAwait(false);

                if (string.IsNullOrEmpty(OrderId))
                {
                    WriteObject(entitlements.Items.Select(e => new PSEntitlement(e)), true);
                }
                else
                {
                    WriteObject(entitlements.Items.Where(e => e.ReferenceOrder.Id == OrderId).Select(e => new PSEntitlement(e)), true);
                }
            }, true);
        }
    }
}