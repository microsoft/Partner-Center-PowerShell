// -----------------------------------------------------------------------
// <copyright file=GetPartnerCustomerSubscriptionAddOn.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Subscriptions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscriptionAddOn")]
    [OutputType(typeof(PSSubscription))]
    public class GetPartnerCustomerSubscriptionAddOn : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<Subscription> subscripions = await partner.Customers[CustomerId].Subscriptions[SubscriptionId].AddOns.GetAsync().ConfigureAwait(false);

                WriteObject(subscripions.Items.Select(s => new PSSubscription(s)), true);
            }, true);

        }
    }
}