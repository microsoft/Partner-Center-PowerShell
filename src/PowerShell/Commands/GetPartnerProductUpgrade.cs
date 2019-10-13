// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Usage;
    using PartnerCenter.Models.ProductUpgrades;

    [Cmdlet(VerbsCommon.Get, "PartnerProductUpgradeStatus"), OutputType(typeof(ProductUpgradeStatus))]
    public class GetPartnerProductUpgradeStatus : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or set the product family.
        /// </summary>
        [Parameter(HelpMessage = "The family for the product.", Mandatory = true)]
        [ValidateSet("Azure", IgnoreCase = true)]
        public string ProductFamily { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the product upgrade.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UpgradeId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Partner.ProductUpgrades.ById(UpgradeId).CheckStatusAsync(new ProductUpgradeRequest
            {
                CustomerId = CustomerId,
                ProductFamily = ProductFamily
            }).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}