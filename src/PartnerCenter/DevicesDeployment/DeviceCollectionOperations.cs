// -----------------------------------------------------------------------
// <copyright file="DeviceCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.DevicesDeployment;
    using Models.JsonConverters;

    /// <summary>
    /// Implements operations that apply to device collections.
    /// </summary>
    internal class DeviceCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IDeviceCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="deviceBatchId">The devices batch identifier.</param>
        public DeviceCollectionOperations(IPartner rootPartnerOperations, string customerId, string deviceBatchId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, deviceBatchId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            deviceBatchId.AssertNotEmpty(nameof(deviceBatchId));
        }

        /// <summary>
        /// Gets the customer's device operations.
        /// </summary>
        /// <param name="id">The device identifier.</param>
        /// <returns>The customer's device operations.</returns>
        public IDevice this[string id] => ById(id);

        /// <summary>
        /// Gets the customer's device operations.
        /// </summary>
        /// <param name="id">The device identifier.</param>
        /// <returns>The customer's device operations.</returns>
        public IDevice ById(string id)
        {
            return new DeviceOperations(Partner, Context.Item1, Context.Item2, id);
        }

        /// <summary>
        /// Adds devices to existing devices batch.
        /// </summary>
        /// <param name="newDevices">The new devices to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status of the create request.</returns>
        public string Create(IEnumerable<Device> newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => CreateAsync(newEntity, cancellationToken));
        }

        /// <summary>
        /// Adds devices to existing devices batch.
        /// </summary>
        /// <param name="newDevices">The new devices to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status of the create request.</returns>
        public async Task<string> CreateAsync(IEnumerable<Device> newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<IEnumerable<Device>, string>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.AddDevicestoDeviceBatch.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the devices associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of devices.</returns>
        public ResourceCollection<Device> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the devices associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of devices.</returns>
        public async Task<ResourceCollection<Device>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Device>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetDevices.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<Device>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}