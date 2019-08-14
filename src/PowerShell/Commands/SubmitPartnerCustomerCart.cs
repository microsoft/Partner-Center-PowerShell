// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Carts;
    using PartnerCenter.Models.Carts;
    using Properties;

    /// <summary>
    /// Checks out the specified cart.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Submit, "PartnerCustomerCart", SupportsShouldProcess = true), OutputType(typeof(PSCartCheckoutResult))]
    public class SubmitPartnerCustomerCart : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required cart identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the cart.", Mandatory = true)]
        [ValidateNotNull]
        public string CartId { get; set; }

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
            CartCheckoutResult checkoutResult;

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.CheckoutPartnerCustomerCartWhatIf, CartId)))
            {
                checkoutResult = Partner.Customers[CustomerId].Carts[CartId].CheckoutAsync().GetAwaiter().GetResult();
                WriteObject(new PSCartCheckoutResult(checkoutResult));
            }
        }
    }
}
