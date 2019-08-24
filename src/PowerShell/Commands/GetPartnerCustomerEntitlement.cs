// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Entitlements;
    using PartnerCenter.Models.Entitlements;

    /// <summary>
    /// Gets a list of entitlements for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerEntitlement"), OutputType(typeof(PSEntitlement))]
    public class GetPartnerCustomerEntitlement : PartnerPSCmdlet
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
            if (string.IsNullOrEmpty(OrderId))
            {
                GetEntitlements(CustomerId);
            }
            else
            {
                GetEntitlements(CustomerId, OrderId);
            }
        }

        /// <summary>
        /// Gets a list of entitlements from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="orderId">Identifier of the order.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetEntitlements(string customerId, string orderId)
        {
            IEnumerable<Entitlement> entitlements;

            customerId.AssertNotEmpty(nameof(customerId));

            entitlements = Partner.Customers[customerId].Entitlements.GetAsync(ShowExpiry.ToBool()).GetAwaiter().GetResult().Items.Where(e => e.ReferenceOrder.Id == orderId);

            WriteObject(entitlements.Select(e => new PSEntitlement(e)), true);
        }

        /// <summary>
        /// Gets a list of customers from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetEntitlements(string customerId)
        {
            IEnumerable<Entitlement> entitlements;

            customerId.AssertNotEmpty(nameof(customerId));

            entitlements = Partner.Customers[customerId].Entitlements.GetAsync(ShowExpiry.ToBool()).GetAwaiter().GetResult().Items;

            WriteObject(entitlements.Select(e => new PSEntitlement(e)), true);
        }
    }
}