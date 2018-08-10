// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerCartLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Carts;
    using PartnerCenter.Models.Carts;
    using PartnerCenter.Models.Products;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerCartLineItem", SupportsShouldProcess = true), OutputType(typeof(PSCartLineItem))]
    public class NewPartnerCustomerCartLineItem : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the type of billing cycle set for the current period.
        /// </summary>
        [Parameter(HelpMessage = "The type of billing cycle set for the current period.", Mandatory = true)]
        [ValidateSet(nameof(BillingCycleType.Annual), nameof(BillingCycleType.Monthly), nameof(BillingCycleType.None), nameof(BillingCycleType.OneTime))]
        public BillingCycleType BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the required catalog item identifier 
        /// </summary>
        [Parameter(HelpMessage = "The catalog item identifier.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CatalogItemId { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        [Parameter(HelpMessage = "The currency code used when this line item is invoiced.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the item defined by the partner to help disambiguate.
        /// </summary>
        [Parameter(HelpMessage = "The friendly name for the item defined by the partner to help disambiguate.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets a group to indicate which items can be placed together.
        /// </summary>
        [Parameter(HelpMessage = "A group to indicate which items can be placed together.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrderGroup { get; set; }

        /// <summary>
        /// Gets or sets a context used for provisioning of offer.
        /// </summary>
        [Parameter(HelpMessage = "A context used for provisioning of offer.", Mandatory = false)]
        [ValidateNotNull]
        public Hashtable ProvisioningContext { get; set; }

        /// <summary>
        /// Gets or sets the number of licenses or instances.
        /// </summary>
        [Parameter(HelpMessage = "The number of licenses or instances.", Mandatory = false)]
        [ValidateNotNull]
        public int Quantity { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CartLineItem lineItem;

            try
            {
                if (!ShouldProcess(Resources.NewPartnerCustomerCartLineItemWhatIf))
                {
                    return;
                }

                lineItem = new CartLineItem
                {
                    CatalogItemId = CatalogItemId,
                    BillingCycle = BillingCycle,
                    CurrencyCode = CurrencyCode,
                    FriendlyName = FriendlyName,
                    OrderGroup = OrderGroup,
                    ProvisioningContext = new Dictionary<string, string>(),
                    Quantity = Quantity
                };

                if (ProvisioningContext != null)
                {
                    foreach (KeyValuePair<object, object> value in ProvisioningContext.Cast<DictionaryEntry>()
                        .ToDictionary(d => d.Key, d => d.Value))
                    {
                        lineItem.ProvisioningContext.Add(value.Key.ToString(), value.Value.ToString());
                    }
                }

                WriteObject(new PSCartLineItem(lineItem));
            }
            finally
            {
                lineItem = null;
            }
        }
    }
}