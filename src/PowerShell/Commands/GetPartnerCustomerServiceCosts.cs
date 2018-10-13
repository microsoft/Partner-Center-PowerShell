﻿// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerServiceCosts.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.ServiceCosts;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ServiceCosts;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerServiceCosts"), OutputType(typeof(PSServiceCostLineItem))]
    public class GetPartnerCustomerServiceCosts : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the billing period.
        /// </summary>
        [Parameter(HelpMessage = "An indicator that represents the billing period.", Mandatory = true)]
        [ValidateSet(nameof(ServiceCostsBillingPeriod.Current), nameof(ServiceCostsBillingPeriod.MostRecent))]
        public ServiceCostsBillingPeriod BillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<ServiceCostLineItem> lineItems;

            try
            {
                lineItems = Partner.Customers[CustomerId].ServiceCosts.ByBillingPeriod(BillingPeriod).LineItems.Get();

                WriteObject(lineItems.Items.Select(i => new PSServiceCostLineItem(i)), true);
            }
            finally
            {
                lineItems = null;
            }
        }
    }
}