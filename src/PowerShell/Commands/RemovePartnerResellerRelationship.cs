// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Microsoft.Store.PartnerCenter.Models.Customers;
    using Models.Authentication;
    using Models.Customers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;
    using Properties;

    /// <summary>
    /// Removes the relationship between the specified customer and the partner.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerResellerRelationship", ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true)]
    [OutputType(typeof(PSCustomer))]
    public class RemovePartnerResellerRelationship : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RemovePartnerResellerRelationshipWhatIf, CustomerId)))
                {
                    IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                    Customer customer;
                    ResourceCollection<Subscription> subscriptions = await partner.Customers[CustomerId].Subscriptions.GetAsync(CancellationToken).ConfigureAwait(false);

                    foreach (Subscription subscription in subscriptions.Items.Where(s => s.Status == SubscriptionStatus.Active))
                    {
                        subscription.Status = SubscriptionStatus.Suspended;
                        await partner.Customers[CustomerId].Subscriptions[subscription.Id].PatchAsync(subscription, CancellationToken).ConfigureAwait(false);
                    }

                    customer = await partner.Customers[CustomerId].PatchAsync(
                        new Customer
                        {
                            RelationshipToPartner = CustomerPartnerRelationship.None
                        }, CancellationToken).ConfigureAwait(false);

                    WriteObject(new PSCustomer(customer));
                }
            }, true);
        }
    }
}