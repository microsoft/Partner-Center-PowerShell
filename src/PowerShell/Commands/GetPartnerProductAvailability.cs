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
    [Cmdlet(VerbsCommon.Get, "PartnerProductAvailability", DefaultParameterSetName = "BySku")]
    [OutputType(typeof(PSProductAvailability))]
    public class GetPartnerProductAvailability : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

                if (string.IsNullOrEmpty(AvailabilityId))
                {
                    ResourceCollection<Availability> productAvailability;

                    if (!string.IsNullOrEmpty(Segment))
                    {
                        productAvailability = await partner.Products.ByCountry(countryCode).ById(ProductId).Skus.ById(SkuId).Availabilities.ByTargetSegment(Segment).GetAsync(CancellationToken).ConfigureAwait(false);

                        if (productAvailability.TotalCount > 0)
                        {
                            WriteObject(productAvailability.Items.Select(pa => new PSProductAvailability(pa)), true);
                        }
                    }
                    else
                    {
                        productAvailability = await partner.Products.ByCountry(countryCode).ById(ProductId).Skus.ById(SkuId).Availabilities.GetAsync(CancellationToken).ConfigureAwait(false);

                        if (productAvailability.TotalCount > 0)
                        {
                            WriteObject(productAvailability.Items.Select(pa => new PSProductAvailability(pa)), true);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(AvailabilityId))
                {
                    Availability availability = await partner.Products.ByCountry(countryCode).ById(ProductId).Skus.ById(SkuId).Availabilities.ById(AvailabilityId).GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteObject(availability);
                }
                else
                {
                    throw new PSInvalidOperationException("You must specify a ProductId or Catalog.");
                }
            }, true);
        }
    }
}