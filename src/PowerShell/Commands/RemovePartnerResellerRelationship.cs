﻿// -----------------------------------------------------------------------
// <copyright file="RemovePartnerResellerRelationship.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Authentication;
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
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PartnerCenter.Models.Customers.Customer customer;
            ResourceCollection<Subscription> subscriptions;

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RemovePartnerResellerRelationshipWhatIf, CustomerId)))
            {
                subscriptions = Partner.Customers[CustomerId].Subscriptions.Get();

                foreach (Subscription subscription in subscriptions.Items.Where(s => s.Status == SubscriptionStatus.Active))
                {
                    subscription.Status = SubscriptionStatus.Suspended;
                    Partner.Customers[CustomerId].Subscriptions[subscription.Id].Patch(subscription);
                }

                customer = Partner.Customers[CustomerId].Patch(
                    new PartnerCenter.Models.Customers.Customer
                    {
                        RelationshipToPartner = PartnerCenter.Models.Customers.CustomerPartnerRelationship.None
                    });

                WriteObject(new PSCustomer(customer));
            }
        }
    }
}