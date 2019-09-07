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
    [Cmdlet(VerbsCommon.Get, "PartnerProduct", DefaultParameterSetName = "ByCatalog"), OutputType(typeof(PSProduct))]
    public class GetPartnerProduct : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the country code used to obtain products.
        /// </summary>
        [Parameter(ParameterSetName = "ByProductId", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        [Parameter(ParameterSetName = "ByCatalog", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByProductId", Mandatory = true, HelpMessage = "A string that identifies the product.")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product catalog.
        /// </summary>
        [Parameter(ParameterSetName = "ByCatalog", Mandatory = true, HelpMessage = "A string that the product catalog.")]
        [ValidateSet("Azure", "AzureReservations", "AzureReservationsVM", "AzureReservationsSQL", "AzureReservationsCosmosDb", "OnlineServices", "Software", "SoftwareSUSELinux", "SoftwarePerpetual", "SoftwareSubscriptions")]
        public string Catalog { get; set; }

        /// <summary>
        /// Gets or sets the product segment.
        /// </summary>
        [Parameter(ParameterSetName = "ByCatalog", Mandatory = false, HelpMessage = "A string that the product segment.")]
        [ValidateSet("commercial", "education", "government", "nonprofit")]
        public string Segment { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string countryCode = string.IsNullOrEmpty(CountryCode) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

            if (!string.IsNullOrEmpty(ProductId))
            {
                GetProduct(countryCode, ProductId);
            }
            else if (!string.IsNullOrEmpty(Catalog))
            {
                if (!string.IsNullOrEmpty(Segment))
                {
                    GetProductsBySegment(countryCode, Catalog, Segment);
                }
                else
                {
                    GetProductsByCatalog(countryCode, Catalog);
                }
            }
            else
            {
                throw new PSInvalidOperationException("You must specify a ProductId or Catalog.");
            }
        }

        /// <summary>
        /// Gets the specified product.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="productId">Identifier for the product.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="productId"/> is empty or null.
        /// </exception>
        private void GetProduct(string countryCode, string productId)
        {
            countryCode.AssertNotEmpty(nameof(countryCode));
            productId.AssertNotEmpty(nameof(productId));

            Product product = Partner.Products.ByCountry(countryCode).ById(productId).GetAsync().GetAwaiter().GetResult();

            if (product != null)
            {
                WriteObject(new PSProduct(product));
            }

        }

        /// <summary>
        /// Gets a list of products by country and category.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offers.</param>
        /// <param name="targetView">Identifies the target view of the catalog.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="targetView"/> is empty or null.
        /// </exception>
        private void GetProductsByCatalog(string countryCode, string targetView)
        {
            countryCode.AssertNotEmpty(nameof(countryCode));
            targetView.AssertNotEmpty(nameof(targetView));

            ResourceCollection<Product> products = Partner.Products.ByCountry(countryCode).ByTargetView(targetView).GetAsync().GetAwaiter().GetResult();

            if (products.TotalCount > 0)
            {
                WriteObject(products.Items.Select(p => new PSProduct(p)), true);
            }
        }

        /// <summary>
        /// Gets a list of products by country, category and segment.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offers.</param>
        /// <param name="targetView">Identifies the target view of the catalog.</param>
        /// <param name="targetSegment">Identifies the target segment.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="targetView"/> is empty or null.
        /// or
        /// <paramref name="targetSegment"/> is empty or null.
        /// </exception>
        private void GetProductsBySegment(string countryCode, string targetView, string targetSegment)
        {
            ResourceCollection<Product> products;

            countryCode.AssertNotEmpty(nameof(countryCode));
            targetView.AssertNotEmpty(nameof(targetView));
            targetSegment.AssertNotEmpty(nameof(targetSegment));

            products = Partner.Products.ByCountry(countryCode).ByTargetView(targetView).ByTargetSegment(targetSegment).GetAsync().GetAwaiter().GetResult();

            if (products.TotalCount > 0)
            {
                WriteObject(products.Items.Select(p => new PSProduct(p)), true);
            }
        }
    }
}