// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Subscriptions;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// Retrieves the registration status for the specified subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscriptionRegistrationStatus"), OutputType(typeof(PSSubscriptionRegistrationStatus))]
    public class GetPartnerCustomerSubscriptionRegistrationStatus : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the offer category.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the subscription.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            SubscriptionRegistrationStatus status = Partner.Customers[CustomerId].Subscriptions[SubscriptionId].RegistrationStatus.GetAsync().GetAwaiter().GetResult();

            WriteObject(new PSSubscriptionRegistrationStatus(status));
        }
    }
}