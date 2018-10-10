// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerDeviceBatch.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.DevicesDeployment;
    using PartnerCenter.Models.DevicesDeployment;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerDeviceBatch", SupportsShouldProcess = true), OutputType(typeof(string))]
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
            string deviceBatch;

            try
            {
                if (!ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.NewPartnerCustomerDeviceBatchWhatIf, BatchId)))
                {
                    return;
                }

                request = new DeviceBatchCreationRequest
                {
                    BatchId = BatchId,
                    Devices = Devices.Select(d => new Device
                    {
                        HardwareHash = d.HardwareHash,
                        ModelName = d.ModelName,
                        OemManufacturerName = d.OemManufacturerName,
                        ProductKey = d.ProductKey,
                        SerialNumber = d.SerialNumber
                    })
                };

                deviceBatch = Partner.Customers[CustomerId].DeviceBatches.Create(new DeviceBatchCreationRequest());

                WriteObject(deviceBatch);
            }
            finally
            {
                request = null;
            }
        }
    }
}