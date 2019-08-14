// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.CustomerSubscriptionUpgrades;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// Gets the available upgrade offers for the specified subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscriptionUpgrades"), OutputType(typeof(PSCustomerSubscriptionUpgrades))]
    public class GetCustomerSubscriptionUpgrades : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the subscription.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the subscription.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<Upgrade> upgrades;

            upgrades = Partner.Customers.ById(CustomerId).Subscriptions.ById(SubscriptionId).Upgrades.GetAsync().GetAwaiter().GetResult();
            WriteObject(upgrades.Items.Select(c => new PSCustomerSubscriptionUpgrades(c)), true);
        }
    }
}