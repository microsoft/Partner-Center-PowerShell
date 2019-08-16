// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
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
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
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
            CartLineItem lineItem;
            List<CartLineItem> lineItems;

            if (!ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.NewCartWhatIf, CustomerId)))
            {
                return;
            }

            lineItems = new List<CartLineItem>();

            foreach (PSCartLineItem item in LineItems)
            {
                lineItem = new CartLineItem
                {
                    BillingCycle = item.BillingCycle,
                    CatalogItemId = item.CatalogItemId,
                    CurrencyCode = item.CurrencyCode,
                    Error = item.Error,
                    FriendlyName = item.FriendlyName,
                    Id = item.Id,
                    OrderGroup = item.OrderGroup,
                    Participants = item.Participants,
                    Quantity = item.Quantity
                };

                foreach (KeyValuePair<string, string> kvp in item.ProvisioningContext?.Cast<DictionaryEntry>().ToDictionary(entry => (string)entry.Key, entry => (string)entry.Value))
                {
                    lineItem.ProvisioningContext.Add(kvp.Key, kvp.Value);
                }

                lineItems.Add(lineItem);
            }

            cart = new Cart
            {
                LineItems = lineItems
            };

            cart = Partner.Customers[CustomerId].Carts.CreateAsync(cart).GetAwaiter().GetResult();

            WriteObject(new PSCart(cart));
        }
    }
}