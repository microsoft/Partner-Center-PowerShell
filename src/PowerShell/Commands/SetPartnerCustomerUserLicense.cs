// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Licenses;
    using PartnerCenter.Models.Licenses;
    using Properties;

    [Cmdlet(VerbsCommon.Set, "PartnerCustomerUserLicense", SupportsShouldProcess = true)]
    [OutputType(typeof(PSLicenseUpdate))]
    public class SetPartnerCustomerUserLicense : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the license update information.
        /// </summary>
        [Parameter(HelpMessage = "The information used to update the license assignments.", Mandatory = true)]
        [ValidateNotNull]
        public PSLicenseUpdate LicenseUpdate { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the user.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(
                CultureInfo.CurrentCulture,
                Resources.SetPartnerCustomerUserLicenseWhatIf,
                UserId)))
            {
                Scheduler.RunTask(async () =>
                {
                    IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                    List<LicenseAssignment> licensesToAssign = new List<LicenseAssignment>();

                    foreach (PSLicenseAssignment licenseAssignment in LicenseUpdate.LicensesToAssign)
                    {
                        licensesToAssign.Add(new LicenseAssignment
                        {
                            ExcludedPlans = licenseAssignment.ExcludedPlans,
                            SkuId = licenseAssignment.SkuId
                        });
                    }

                    LicenseUpdate update = new LicenseUpdate
                    {
                        LicensesToAssign = licensesToAssign,
                        LicensesToRemove = LicenseUpdate.LicensesToRemove
                    };

                    update = await partner.Customers[CustomerId].Users[UserId].LicenseUpdates.CreateAsync(update, CancellationToken).ConfigureAwait(false);

                    WriteObject(new PSLicenseUpdate(update));
                }, true);
            }
        }
    }
}