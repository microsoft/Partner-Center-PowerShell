// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Products;
    using Products;

    /// <summary>
    /// Get a product, or a list products, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerProduct", DefaultParameterSetName = ByTargetViewParameterSetName), OutputType(typeof(PSProduct))]
    public class GetPartnerProduct : PartnerCmdlet
    {
        /// <summary>
        /// The name of the by product identifier parameter set.
        /// </summary>
        private const string ByProductIdParameterSetName = "ByProductId";

        /// <summary>
        /// The name of the by reservation scope parameter set.
        /// </summary>
        private const string ByReservationScopeParameterSetName = "ByReservationScope";

        /// <summary>
        /// The name of the by target view parameter set.
        /// </summary>
        private const string ByTargetViewParameterSetName = "ByTargetView";

        /// <summary>
        /// Gets or sets the catalog view.
        /// </summary>
        [Parameter(HelpMessage = "The catalog used for filtering the product.", Mandatory = true, ParameterSetName = ByTargetViewParameterSetName)]
        [ValidateSet("Azure", "AzureReservations", "AzureReservationsVM", "AzureReservationsSQL", "AzureReservationsCosmosDb", "OnlineServices", "Software", "SoftwareSUSELinux", "SoftwarePerpetual", "SoftwareSubscriptions")]
        public string Catalog { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [Parameter(HelpMessage = "The country on which to base the product.", Mandatory = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the product.", Mandatory = true, ParameterSetName = ByProductIdParameterSetName)]
        [Parameter(HelpMessage = "The identifier for the product.", Mandatory = true, ParameterSetName = ByReservationScopeParameterSetName)]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the reservation scope.
        /// </summary>
        [Parameter(HelpMessage = "The reservation scope used for filtering.", Mandatory = true, ParameterSetName = ByReservationScopeParameterSetName)]
        public string ReservationScope { get; set; }

        /// <summary>
        /// Gets or sets the target segment.
        /// </summary>
        [Parameter(HelpMessage = "The segment used for filtering.", Mandatory = false, ParameterSetName = ByTargetViewParameterSetName)]
        [ValidateSet("commercial", "education", "government", "nonprofit")]
        public string Segment { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IProductCollectionByCountry operations = Partner.Products.ByCountry(string.IsNullOrEmpty(CountryCode) ? PartnerSession.Instance.Context.CountryCode : CountryCode);

            if (ParameterSetName == ByProductIdParameterSetName)
            {
                WriteObject(new PSProduct(operations.ById(ProductId).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult()));
            }
            else if (ParameterSetName == ByReservationScopeParameterSetName)
            {
                WriteObject(
                    new PSProduct(
                        operations.ById(ProductId).ByReservationScope(ReservationScope).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult()));
            }
            else if (ParameterSetName == ByTargetViewParameterSetName)
            {
                if (string.IsNullOrEmpty(Segment))
                {
                    WriteObject(
                        operations.ByTargetView(Catalog).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult()
                            .Items.Select(p => new PSProduct(p)), true);
                }
                else
                {
                    WriteObject(
                        operations.ByTargetView(Catalog).ByTargetSegment(Segment).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult()
                            .Items.Select(p => new PSProduct(p)), true);
                }
            }
        }
    }
}