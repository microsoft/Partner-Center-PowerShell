// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerEntitlements.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
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
        [Parameter(Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the optional order identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier for the order.")]
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

            try
            {
                entitlements = Partner.Customers[customerId].Entitlements.Get().Items.Where(e => e.ReferenceOrder.Id == orderId);

                WriteObject(entitlements.Select(e => new PSEntitlement(e)), true);
            }
            finally
            {
                entitlements = null;
            }
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

            try
            {
                entitlements = Partner.Customers[customerId].Entitlements.Get().Items;

                WriteObject(entitlements.Select(e => new PSEntitlement(e)), true);
            }
            finally
            {
                entitlements = null;
            }
        }
    }
}