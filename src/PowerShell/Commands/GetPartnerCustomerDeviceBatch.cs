// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.DevicesDeployment;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Gets a colletion of device batches from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerDeviceBatch"), OutputType(typeof(PSDeviceBatch))]
    public class GetPartnerCustomerDeviceBatch : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IEnumerable<DeviceBatch> deviceBatch = Partner.Customers[CustomerId].DeviceBatches.GetAsync().GetAwaiter().GetResult().Items;
            WriteObject(deviceBatch.Select(db => new PSDeviceBatch(db)), true);
        }
    }
}