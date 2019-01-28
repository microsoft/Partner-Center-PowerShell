// -----------------------------------------------------------------------
// <copyright file="DevicesBatchOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using Extensions;

    /// <summary>
    /// Represents the operations that apply to devices batch of the customer.
    /// </summary>
    internal class DevicesBatchOperations : BasePartnerComponent<Tuple<string, string>>, IDevicesBatch
    {
        /// <summary>
        /// Provides the customer device collection operations.
        /// </summary>
        private readonly Lazy<IDeviceCollection> devices;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesBatchOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="deviceBatchId">The devices batch identifier.</param>
        public DevicesBatchOperations(IPartner rootPartnerOperations, string customerId, string deviceBatchId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, deviceBatchId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            deviceBatchId.AssertNotEmpty(nameof(deviceBatchId));

            devices = new Lazy<IDeviceCollection>(() => new DeviceCollectionOperations(Partner, Context.Item1, Context.Item2));
        }

        /// <summary>
        /// Gets the device collection operations for the customer.
        /// </summary>
        public IDeviceCollection Devices => devices.Value;
    }
}
