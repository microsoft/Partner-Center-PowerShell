// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using PartnerCenter.Models.ProductUpgrades;

    [Cmdlet(VerbsCommon.New, "PartnerProductUpgrade")]
    [OutputType(typeof(ProductUpgradeRequest))]
    public class NewPartnerProductUpgrade : PartnerAsyncCmdlet
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
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                WriteObject(await partner.ProductUpgrades.CreateAsync(new ProductUpgradeRequest
                {
                    CustomerId = CustomerId,
                    ProductFamily = ProductFamily
                }, CancellationToken).ConfigureAwait(false));
            }, true);
        }
    }
}