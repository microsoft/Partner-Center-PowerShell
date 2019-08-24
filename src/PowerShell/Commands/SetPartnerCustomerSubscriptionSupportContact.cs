// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Subscriptions;
    using PartnerCenter.Models.Subscriptions;
    using Properties;

    [Cmdlet(VerbsCommon.Set, "PartnerCustomerSubscriptionSupportContact", SupportsShouldProcess = true), OutputType(typeof(PSSupportContact))]
    public class SetPartnerCustomerSubscriptionSupportContact : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(HelpMessage = "The name of the support contact.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the required subscription identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the subscription.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the support MPN identifier.
        /// </summary>
        [Parameter(HelpMessage = "The MPN identifier of the support contact.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SupportMpnId { get; set; }

        /// <summary>
        /// Gets or sets the support tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The tenant identifier of the support contact.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SupportTenantId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            SupportContact contact;

            if (ShouldProcess(string.Format(
                CultureInfo.CurrentCulture,
                Resources.SetPartnerCustomerSubscriptionSupportContactWhatIf,
                SubscriptionId)))
            {
                contact = new SupportContact
                {
                    Name = Name,
                    SupportMpnId = SupportMpnId,
                    SupportTenantId = SupportTenantId
                };

                contact = Partner.Customers[CustomerId].Subscriptions[SubscriptionId].SupportContact.UpdateAsync(contact).GetAwaiter().GetResult();
                WriteObject(new PSSupportContact(contact));
            }
        }
    }
}