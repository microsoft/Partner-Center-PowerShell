// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.DevicesDeployment;
    using PartnerCenter.Models;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Gets a list of devices in the specified device batch for the specified customer.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerDevice")]
    [OutputType(typeof(PSDevice))]
    public class GetPartnerCustomerDevice : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the batch identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Identifier for the device batch.")]
        [ValidateNotNullOrEmpty]
        public string BatchId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<Device> devices = await partner.Customers[CustomerId].DeviceBatches[BatchId].Devices.GetAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(devices.Items.Select(d => new PSDevice(d)), true);
            }, true);
        }
    }
}