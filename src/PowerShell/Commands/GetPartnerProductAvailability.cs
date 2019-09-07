// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Products;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Get a product, or a list products, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerProductAvailability", DefaultParameterSetName = "BySku"), OutputType(typeof(PSProductAvailability))]
    public class GetPartnerProductAvailability : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByAvailabilityId", Mandatory = true, HelpMessage = "A string that identifies the product.")]
        [Parameter(ParameterSetName = "BySku", Mandatory = true, HelpMessage = "A string that identifies the product.")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByAvailabilityId", Mandatory = true, HelpMessage = "A string that identifies the product Sku.")]
        [Parameter(ParameterSetName = "BySku", Mandatory = true, HelpMessage = "A string that identifies the product Sku.")]
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the country code used to obtain product availability.
        /// </summary>
        [Parameter(ParameterSetName = "ByAvailabilityId", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        [Parameter(ParameterSetName = "BySku", Mandatory = false, HelpMessage = "The country ISO2 code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the product catalog.
        /// </summary>
        [Parameter(ParameterSetName = "ByAvailabilityId", Mandatory = true, HelpMessage = "A string that identifies the availability.")]
        public string AvailabilityId { get; set; }

        /// <summary>
        /// Gets or sets the product segment.
        /// </summary>
        [Parameter(ParameterSetName = "BySku", Mandatory = false, HelpMessage = "A string that identifies the product segment.")]
        [ValidateSet("commercial", "education", "government", "nonprofit")]
        public string Segment { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

            if (string.IsNullOrEmpty(AvailabilityId))
            {
                if (!string.IsNullOrEmpty(Segment))
                {
                    GetProductAvailabilityBySku(countryCode, ProductId, SkuId);
                }
                else
                {
                    GetProductAvailabilityBySku(countryCode, ProductId, SkuId, Segment);
                }
            }
            else if (!string.IsNullOrEmpty(AvailabilityId))
            {
                GetProductAvailabilityById(countryCode, ProductId, SkuId, AvailabilityId);
            }
            else
            {
                throw new PSInvalidOperationException("You must specify a ProductId or Catalog.");
            }
        }

        /// <summary>
        /// Gets the specified product availability.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="productId">Identifier for the product.</param>
        /// <param name="skuId">Identifier for the product Sku.</param>
        /// <param name="segment">Identifier for the target segment.</param>
        private void GetProductAvailabilityBySku(string countryCode, string productId, string skuId, string segment = null)
        {
            ResourceCollection<Availability> productAvailability;

            // If segment is specified, get the information using the segment. Otherwise don't
            if (!string.IsNullOrEmpty(segment))
            {
                productAvailability = Partner.Products.ByCountry(countryCode).ById(productId).Skus.ById(skuId).Availabilities.ByTargetSegment(segment).GetAsync().GetAwaiter().GetResult();

                if (productAvailability.TotalCount > 0)
                {
                    WriteObject(productAvailability.Items.Select(pa => new PSProductAvailability(pa)), true);
                }
            }
            else
            {
                productAvailability = Partner.Products.ByCountry(countryCode).ById(productId).Skus.ById(skuId).Availabilities.GetAsync().GetAwaiter().GetResult();

                if (productAvailability.TotalCount > 0)
                {
                    WriteObject(productAvailability.Items.Select(pa => new PSProductAvailability(pa)), true);
                }
            }
        }

        /// <summary>
        /// Gets the specified product availability.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="productId">Identifier for the product.</param>
        /// <param name="skuId">Identifier for the product Sku.</param>
        /// <param name="availabilityId">Identifier for the product availability.</param>
        private void GetProductAvailabilityById(string countryCode, string productId, string skuId, string availabilityId)
        {
            Availability productAvailability = Partner.Products.ByCountry(countryCode).ById(productId).Skus.ById(skuId).Availabilities.ById(availabilityId).GetAsync().GetAwaiter().GetResult();

            if (productAvailability != null)
            {
                WriteObject(new PSProductAvailability(productAvailability));
            }
        }
    }
}