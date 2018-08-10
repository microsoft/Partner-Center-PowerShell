// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerCart.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Models.Carts;
    using PartnerCenter.Models.Carts;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerCart", SupportsShouldProcess = true), OutputType(typeof(PSCart))]
    public class NewPartnerCustomerCart : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a collection of cart line items.
        /// </summary>
        [Parameter(HelpMessage = "A list of cart line items.", Mandatory = true)]
        [ValidateNotNull]
        public PSCartLineItem[] LineItems { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Cart cart;
            CartLineItem cartLineItem;
            List<CartLineItem> cartLineItems;

            try
            {
                if (!ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.NewCartWhatIf, CustomerId)))
                {
                    return;
                }

                cartLineItems = new List<CartLineItem>();

                foreach (PSCartLineItem item in LineItems)
                {
                    cartLineItem = new CartLineItem();
                    cartLineItem.CopyFrom(item);

                    cartLineItems.Add(cartLineItem);
                }

                cart = new Cart
                {
                    LineItems = cartLineItems
                };

                cart = Partner.Customers[CustomerId].Carts.Create(cart);

                WriteObject(new PSCart(cart));
            }
            finally
            {
                cart = null;
                cartLineItem = null;
                cartLineItems = null;
            }
        }
    }
}