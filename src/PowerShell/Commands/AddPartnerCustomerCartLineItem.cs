// -----------------------------------------------------------------------
// <copyright file="AddPartnerCustomerCartLineItem.cs" company="Microsoft">
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

    /// <summary>
    /// Adds a cart line item to the specified cart.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "PartnerCustomerCartLineItem", SupportsShouldProcess = true), OutputType(typeof(PSCart))]
    public class AddPartnerCustomerCartLineItem : PartnerPSCmdlet
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
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the line item to be added.
        /// </summary>
        [Parameter(HelpMessage = "The line item to be added.", Mandatory = true)]
        [ValidateNotNull]
        public PSCartLineItem LineItem { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Cart cart;
            CartLineItem cartLineItem;
            List<CartLineItem> lineItems;

            try
            {
                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.AddPartnerCustomerCartLineItemWhatIf, CartId)))
                {
                    cart = Partner.Customers[CustomerId].Carts[CartId].Get();
                    lineItems = cart.LineItems.ToList();

                    cartLineItem = new CartLineItem();
                    cartLineItem.CopyFrom(LineItem);

                    lineItems.Add(cartLineItem);

                    cart = Partner.Customers[CustomerId].Carts[CartId].Put(cart);

                    WriteObject(new PSCart(cart));
                }
            }
            finally
            {
                cart = null;
                cartLineItem = null;
                lineItems = null;
            }
        }
    }
}