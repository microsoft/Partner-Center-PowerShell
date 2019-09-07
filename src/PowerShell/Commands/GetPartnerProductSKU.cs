// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Extensions;
    using Models.Authentication;
    using Models.Products;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Get a product, or a list products, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerProductSku", DefaultParameterSetName = "ByProductId"), OutputType(typeof(PSSku))]
    public class GetPartnerProductSku : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the country code used to obtain product skus.
        /// </summary>
        [Parameter(ParameterSetName = "ByProductId", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        [Parameter(ParameterSetName = "BySkuId", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        [Parameter(ParameterSetName = "BySegment", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByProductId", Mandatory = true, HelpMessage = "A string that identifies the product.")]
        [Parameter(ParameterSetName = "BySkuId", Mandatory = true, HelpMessage = "A string that identifies the product.")]
        [Parameter(ParameterSetName = "BySegment", Mandatory = true, HelpMessage = "A string that identifies the product.")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the sku identifier.
        /// </summary>
        [Parameter(ParameterSetName = "BySkuId", Mandatory = true, HelpMessage = "A string that identifies the sku.")]
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the product segment.
        /// </summary>
        [Parameter(ParameterSetName = "BySegment", Mandatory = false, HelpMessage = "A string that the product segment.")]
        [ValidateSet("commercial", "education", "government", "nonprofit")]
        public string Segment { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

            ProductId.AssertNotEmpty(nameof(ProductId));

            if (!string.IsNullOrEmpty(SkuId))
            {
                GetProductSku(countryCode, ProductId, SkuId);
            }
            else
            {
                GetProductSkus(countryCode, ProductId, Segment);
            }
        }

        /// <summary>
        /// Gets the specified product sku.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="productId">Identifier for the product.</param>
        /// <param name="skuId">Identifier for the SKU.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="productId"/> is empty or null.
        /// or
        /// <paramref name="skuId"/> is empty or null.
        /// </exception>
        private void GetProductSku(string countryCode, string productId, string skuId)
        {
            countryCode.AssertNotEmpty(nameof(countryCode));
            productId.AssertNotEmpty(nameof(productId));

            Sku sku = Partner.Products.ByCountry(countryCode).ById(productId).Skus.ById(skuId).GetAsync().GetAwaiter().GetResult();

            if (sku != null)
            {
                WriteObject(new PSSku(sku));
            }

        }

        /// <summary>
        /// Gets the specified product skus.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="productId">Identifier for the product.</param>
        /// <param name="segment">Identifier for the product.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="productId"/> is empty or null.
        /// </exception>
        private void GetProductSkus(string countryCode, string productId, string segment)
        {
            ResourceCollection<Sku> skus;

            countryCode.AssertNotEmpty(nameof(countryCode));
            productId.AssertNotEmpty(nameof(productId));

            if (string.IsNullOrEmpty(segment))
            {
                skus = Partner.Products.ByCountry(countryCode).ById(productId).Skus.GetAsync().GetAwaiter().GetResult();
            }
            else
            {
                skus = Partner.Products.ByCountry(countryCode).ById(productId).Skus.ByTargetSegment(segment).GetAsync().GetAwaiter().GetResult();
            }

            if (skus.TotalCount > 0)
            {
                WriteObject(skus.Items.Select(s => new PSSku(s)), true);
            }
        }
    }
}