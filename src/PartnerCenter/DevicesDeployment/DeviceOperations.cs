// -----------------------------------------------------------------------
// <copyright file="DeviceOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.DevicesDeployment;

    /// <summary>
    /// Implements operations that apply to device.
    /// </summary>
    internal class DeviceOperations : BasePartnerComponent<Tuple<string, string, string>>, IDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="deviceBatchId">The devices batch identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        public DeviceOperations(IPartner rootPartnerOperations, string customerId, string deviceBatchId, string deviceId)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, deviceBatchId, deviceId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            deviceBatchId.AssertNotEmpty(nameof(deviceBatchId));
            deviceId.AssertNotEmpty(nameof(deviceId));
        }

        /// <summary>
        /// Deletes a device associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            await Partner.ServiceClient.DeleteAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.DeleteDevice.Path}",
                        Context.Item1,
                        Context.Item2,
                        Context.Item3),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a device associated to the customer with a configuration policy.
        /// </summary>
        /// <param name="entity">The device that is to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Device that was updated.</returns>
        public async Task<Device> PatchAsync(Device entity, CancellationToken cancellationToken = default)
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PutAsync<Device, Device>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateDevice.Path}",
                        Context.Item1,
                        Context.Item2,
                        Context.Item3),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}