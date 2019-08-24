// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Customers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;
    using Properties;

    /// <summary>
    /// Removes the relationship between the specified customer and the partner.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerResellerRelationship", ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true), OutputType(typeof(PSCustomer))]
    public class RemovePartnerResellerRelationship : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PartnerCenter.Models.Customers.Customer customer;
            ResourceCollection<Subscription> subscriptions;

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RemovePartnerResellerRelationshipWhatIf, CustomerId)))
            {
                subscriptions = Partner.Customers[CustomerId].Subscriptions.GetAsync().GetAwaiter().GetResult();

                foreach (Subscription subscription in subscriptions.Items.Where(s => s.Status == SubscriptionStatus.Active))
                {
                    subscription.Status = SubscriptionStatus.Suspended;
                    Partner.Customers[CustomerId].Subscriptions[subscription.Id].PatchAsync(subscription).GetAwaiter().GetResult();
                }

                customer = Partner.Customers[CustomerId].PatchAsync(
                    new PartnerCenter.Models.Customers.Customer
                    {
                        RelationshipToPartner = PartnerCenter.Models.Customers.CustomerPartnerRelationship.None
                    }).GetAwaiter().GetResult();

                WriteObject(new PSCustomer(customer));
            }
        }
    }
}