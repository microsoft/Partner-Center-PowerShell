// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// Gets a list of Azure Plan entitlements for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerAzurePlanEntitlement"), OutputType(typeof(AzureEntitlement))]
    public class GetPartnerCustomerAzurePlanEntitlement : PartnerCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the subscription.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<AzureEntitlement> entitlements = Partner.Customers[CustomerId]
                .Subscriptions[SubscriptionId]
                .GetAzurePlanSubscriptionEntitlementsAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            WriteObject(entitlements, true);
        }
    }
}
