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
    using Products;

    /// <summary>
    /// Get a product SKU, or a list product SKUs, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerProductSku", DefaultParameterSetName = ByProductIdParameterSetName), OutputType(typeof(PSSku))]
    public class GetPartnerProductSku : PartnerAsyncCmdlet
    {
        /// <summary>
        /// The name of the by product identifier parameter set.
        /// </summary>
        private const string ByProductIdParameterSetName = "ByProductId";

        /// <summary>
        /// The name of the by SKU identifier parameter set.
        /// </summary>
        private const string BySkuIdParameterSetName = "BySkuId";

        /// <summary>
        /// The name of the by segment parameter set.
        /// </summary>
        private const string BySegmentParameterSetName = "BySegment";

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [Parameter(HelpMessage = "The country on which to base the product.", Mandatory = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the product.", Mandatory = true, ParameterSetName = ByProductIdParameterSetName)]
        [Parameter(HelpMessage = "The identifier for the product.", Mandatory = true, ParameterSetName = BySkuIdParameterSetName)]
        [Parameter(HelpMessage = "The identifier for the product.", Mandatory = true, ParameterSetName = BySegmentParameterSetName)]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the reservation scope.
        /// </summary>
        [Parameter(HelpMessage = "The reservation scope used for filtering.", Mandatory = false)]
        public string ReservationScope { get; set; }

        /// <summary>
        /// Gets or sets the target segment.
        /// </summary>
        [Parameter(HelpMessage = "The segment used for filtering.", Mandatory = true, ParameterSetName = BySegmentParameterSetName)]
        [ValidateSet("commercial", "education", "government", "nonprofit")]
        public string Segment { get; set; }

        /// <summary>
        /// Gets or sets the SKU identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the SKU.", Mandatory = true, ParameterSetName = BySkuIdParameterSetName)]
        public string SkuId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                IProductCollectionByCountry operations = partner.Products.ByCountry(string.IsNullOrEmpty(CountryCode) ? PartnerSession.Instance.Context.CountryCode : CountryCode);

                if (ParameterSetName == ByProductIdParameterSetName)
                {
                    ResourceCollection<Sku> skus;

                    if (string.IsNullOrEmpty(ReservationScope))
                    {
                        skus = await operations.ById(ProductId).Skus.GetAsync(CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        skus = await operations.ById(ProductId).Skus.ByReservationScope(ReservationScope).GetAsync(CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(skus.Items.Select(s => new PSSku(s)), true);
                }
                else if (ParameterSetName == BySkuIdParameterSetName)
                {
                    Sku sku;

                    if (string.IsNullOrEmpty(ReservationScope))
                    {
                        sku = await operations.ById(ProductId).Skus.ById(SkuId).GetAsync(CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        sku = await operations.ById(ProductId).Skus.ById(SkuId).ByReservationScope(ReservationScope).GetAsync(CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(new PSSku(sku));

                }
                else if (ParameterSetName == BySegmentParameterSetName)
                {
                    ResourceCollection<Sku> skus;

                    if (string.IsNullOrEmpty(ReservationScope))
                    {
                        skus = await operations.ById(ProductId).Skus.ByTargetSegment(Segment).GetAsync(CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        skus = await operations.ById(ProductId).Skus.ByTargetSegment(Segment).ByReservationScope(ReservationScope).GetAsync(CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(skus.Items.Select(s => new PSSku(s)), true);
                }
            }, true);
        }
    }
}