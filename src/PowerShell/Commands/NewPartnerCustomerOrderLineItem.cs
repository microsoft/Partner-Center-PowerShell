// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerOrderLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PartnerCenter.PowerShell.Models.Orders;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerOrderLineItem", SupportsShouldProcess = true), OutputType(typeof(PSOrderLineItem))]
    public class NewPartnerCustomerOrderLineItem : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the friendly name for the result contract (subscription).
        /// </summary>
        [Parameter(HelpMessage = "The friendly name for the result contract (subscription).", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the line item number.
        /// </summary>
        [Parameter(HelpMessage = "The line item number.", Mandatory = true)]
        [ValidateNotNull]
        public int LineItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The offer identifier.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier on record.
        /// </summary>
        [Parameter(HelpMessage = "The partner identifier on record.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PartnerIdOnRecord { get; set; }

        /// <summary>
        /// Gets or sets the parent subscription identifier.
        /// </summary>
        /// <remarks>
        /// This parameter should only be set for add-on offer purchase. This applies to Order updates only.
        /// </remarks>
        [Parameter(HelpMessage = "The parent subscription identifier.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ParentSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the provisioning context for the offer.
        /// </summary>
        [Parameter(HelpMessage = "The provisioning context for the offer.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Hashtable ProvisioningContext { get; set; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        [Parameter(HelpMessage = "The product quantity.", Mandatory = true)]
        [ValidateNotNull]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the resulting subscription identifier.
        /// </summary>
        [Parameter(HelpMessage = "The resulting subscription identifier.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PSOrderLineItem orderLineItem;

            try
            {
                if (!ShouldProcess(Resources.NewPartnerCustomerOrderLineItemWhatIf))
                {
                    return;
                }

                orderLineItem = new PSOrderLineItem
                {
                    FriendlyName = FriendlyName,
                    LineItemNumber = LineItemNumber,
                    OfferId = OfferId,
                    ParentSubscriptionId = ParentSubscriptionId,
                    PartnerIdOnRecord = PartnerIdOnRecord,
                    Quantity = Quantity,
                    SubscriptionId = SubscriptionId
                };

                if (ProvisioningContext != null)
                {
                    foreach (KeyValuePair<object, object> value in ProvisioningContext.Cast<DictionaryEntry>()
                        .ToDictionary(d => d.Key, d => d.Value))
                    {
                        orderLineItem.ProvisioningContext.Add(value.Key.ToString(), value.Value.ToString());
                    }
                }

                WriteObject(orderLineItem);
            }
            finally
            {
                orderLineItem = null;
            }
        }
    }
}