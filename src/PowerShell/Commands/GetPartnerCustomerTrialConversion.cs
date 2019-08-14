// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.CustomerTrialConversion;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerTrialConversion"), OutputType(typeof(PSCustomerTrialConversion))]
    public class GetPartnerTrialConversion : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the subscription.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<Conversion> conversions = Partner.Customers.ById(CustomerId).Subscriptions.ById(SubscriptionId).Conversions.GetAsync().GetAwaiter().GetResult();
            WriteObject(conversions.Items.Select(c => new PSCustomerTrialConversion(c)), true);
        }
    }
}