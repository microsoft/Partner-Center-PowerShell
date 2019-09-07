// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Extensions;
    using Models.Authentication;
    using Models.Products;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Get a product, or a list products, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerProductInventory"), OutputType(typeof(PSInventoryItem))]
    public class GetPartnerProductInventory : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the country code used to obtain product skus.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The country ISO2 code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "A string that identifies the product.")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the optional sku identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A string that identifies the sku.")]
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the inventory context.
        /// </summary>
        /// <remarks>
        /// The supported values are: 
        /// CustomerId - The ID of the customerthat the purchase would be for.
        /// AzureSubscriptionId - The ID of the Azure Subscription that would be used for an Azure Reserved VM Instance purchase.
        /// </remarks>
        [Parameter(Mandatory = false, HelpMessage = "A hashtable of inventory variables for the product.")]
        public Hashtable Variables { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ProductId.AssertNotEmpty(nameof(ProductId));

            string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

            if (Variables == null)
            {
                Variables = new Hashtable();
            }

            GetProductInventory(countryCode, ProductId, SkuId, Variables);
        }

        /// <summary>
        /// Gets the specified product SKU.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="productId">Identifier for the product.</param>
        /// <param name="context">The list of variables needed to execute an inventory check on this item.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="productId"/> is empty or null.
        /// or
        /// <paramref name="context"/> is empty or null.
        /// </exception>
        private void GetProductInventory(string countryCode, string productId, string skuId, Hashtable context)
        {
            IEnumerable<InventoryItem> item;
            InventoryCheckRequest request;

            countryCode.AssertNotEmpty(nameof(countryCode));
            productId.AssertNotEmpty(nameof(productId));

            request = new InventoryCheckRequest()
            {
                TargetItems = string.IsNullOrEmpty(skuId) ? new InventoryItem[] { new InventoryItem { ProductId = productId } } : new InventoryItem[] { new InventoryItem { ProductId = productId, SkuId = skuId } },
            };

            foreach (KeyValuePair<string, string> kvp in context.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value))
            {
                request.InventoryContext.Add(kvp.Key, kvp.Value);
            }

            item = Partner.Extensions.Product.ByCountry(countryCode).CheckInventoryAsync(request).GetAwaiter().GetResult();

            WriteObject(item.Select(i => new PSInventoryItem(i)), true);
        }
    }
}