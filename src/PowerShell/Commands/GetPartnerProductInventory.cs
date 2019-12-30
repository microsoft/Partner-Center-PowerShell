// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Products;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Get a product, or a list products, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerProductInventory")]
    [OutputType(typeof(PSInventoryItem))]
    public class GetPartnerProductInventory : PartnerAsyncCmdlet
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
        [ValidateNotNull]
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

                if (Variables == null)
                {
                    Variables = new Hashtable();
                }

                IEnumerable<InventoryItem> item;
                InventoryCheckRequest request;

                request = new InventoryCheckRequest()
                {
                    TargetItems = string.IsNullOrEmpty(SkuId) ? new InventoryItem[] { new InventoryItem { ProductId = ProductId } } : new InventoryItem[] { new InventoryItem { ProductId = ProductId, SkuId = SkuId } },
                };

                foreach (KeyValuePair<string, string> kvp in Variables.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value))
                {
                    request.InventoryContext.Add(kvp.Key, kvp.Value);
                }

                item = await partner.Extensions.Product.ByCountry(countryCode).CheckInventoryAsync(request, CancellationToken).ConfigureAwait(false);

                WriteObject(item.Select(i => new PSInventoryItem(i)), true);
            }, true);
        }
    }
}