// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerServiceCostsSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Authentication;
    using Models.ServiceCosts;
    using PartnerCenter.Models.ServiceCosts;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerServiceCostsSummary"), OutputType(typeof(PSServiceCostsSummary))]
    public class GetPartnerCustomerServiceCostsSummary : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the billing period.
        /// </summary>
        [Parameter(HelpMessage = "An indicator that represents the billing period.", Mandatory = true)]
        // TODO -- Remove the Current option because it is not supported by the API
        [ValidateSet(nameof(ServiceCostsBillingPeriod.Current), nameof(ServiceCostsBillingPeriod.MostRecent))]
        public ServiceCostsBillingPeriod BillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
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
            ServiceCostsSummary summary = Partner.Customers[CustomerId].ServiceCosts.ByBillingPeriod(BillingPeriod).Summary.Get();

            WriteObject(new PSServiceCostsSummary(summary));
        }
    }
}