// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerDevice.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.DevicesDeployment;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Return a list of devices in the specified device batch for the specified customer.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerDevice"), OutputType(typeof(PSDevice))]
    public class GetPartnerCustomerDevice : PartnerPSCmdlet
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
            IEnumerable<Device> devices = Partner.Customers[CustomerId].DeviceBatches[BatchId].Devices.GetAsync().GetAwaiter().GetResult().Items;
            WriteObject(devices.Select(d => new PSDevice(d)), true);
        }
    }
}