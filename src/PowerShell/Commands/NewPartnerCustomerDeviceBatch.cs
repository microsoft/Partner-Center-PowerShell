// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using System.Threading;
    using Models.DevicesDeployment;
    using PartnerCenter.Models;
    using PartnerCenter.Models.DevicesDeployment;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerDeviceBatch", SupportsShouldProcess = true), OutputType(typeof(PSBatchUploadDetails))]
    public class NewPartnerCustomerDeviceBatch : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier for the device batch.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the batch.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BatchId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the devices for the device batch.
        /// </summary>
        [Parameter(HelpMessage = "The devices to be included in the device batch.", Mandatory = true)]
        [ValidateNotNull]
        public PSDevice[] Devices { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            DeviceBatchCreationRequest request;
            ResourceCollection<DeviceBatch> batches;
            IEnumerable<Device> devices;
            BatchUploadDetails status;
            string location;

            if (!ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.NewPartnerCustomerDeviceBatchWhatIf, BatchId)))
            {
                return;
            }

            batches = Partner.Customers[CustomerId].DeviceBatches.GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            devices = Devices.Select(d => new Device
            {
                HardwareHash = d.HardwareHash,
                ModelName = d.ModelName,
                OemManufacturerName = d.OemManufacturerName,
                Policies = d.Policies,
                ProductKey = d.ProductKey,
                SerialNumber = d.SerialNumber
            });

            if (batches.Items.SingleOrDefault(b => b.Id.Equals(BatchId, StringComparison.InvariantCultureIgnoreCase)) != null)
            {
                location = Partner.Customers[CustomerId].DeviceBatches[BatchId].Devices.CreateAsync(Devices.Select(d => new Device
                {
                    HardwareHash = d.HardwareHash,
                    ModelName = d.ModelName,
                    OemManufacturerName = d.OemManufacturerName,
                    Policies = d.Policies,
                    ProductKey = d.ProductKey,
                    SerialNumber = d.SerialNumber
                })).GetAwaiter().GetResult();
            }
            else
            {
                request = new DeviceBatchCreationRequest
                {
                    BatchId = BatchId,
                    Devices = devices
                };

                location = Partner.Customers[CustomerId].DeviceBatches.CreateAsync(request).GetAwaiter().GetResult();
            }

            status = Partner.Customers[CustomerId].BatchUploadStatus.ById(location.Split('/')[4]).GetAsync().GetAwaiter().GetResult();

            while (status.Status == DeviceUploadStatusType.Processing || status.Status == DeviceUploadStatusType.Queued)
            {
                Thread.Sleep(5000);

                status = Partner.Customers[CustomerId].BatchUploadStatus.ById(location.Split('/')[4]).GetAsync().GetAwaiter().GetResult();
            }

            WriteObject(new PSBatchUploadDetails(status));
        }
    }
}