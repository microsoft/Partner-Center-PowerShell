// -----------------------------------------------------------------------
// <copyright file="DevicesBatchCollectionOperations.cs" company="Microsoft">
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
    using Models;
    using Models.DevicesDeployment;
    using Models.JsonConverters;

    /// <summary>
    /// Implements operations that apply to devices batch collection.
    /// </summary>
    internal class DevicesBatchCollectionOperations : BasePartnerComponent<string>, IDevicesBatchCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesBatchCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public DevicesBatchCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a specific customer's devices batch behavior.
        /// </summary>
        /// <param name="id">The devices batch identifier.</param>
        /// <returns>The customer devices batch operations.</returns>
        public IDevicesBatch this[string id] => ById(id);

        /// <summary>
        /// Gets a specific customer's devices batch behavior.
        /// </summary>
        /// <param name="id">The devices batch identifier.</param>
        /// <returns>The customer devices batch operations.</returns>
        public IDevicesBatch ById(string id)
        {
            return new DevicesBatchOperations(Partner, Context, id);
        }

        /// <summary>
        /// Creates a new devices batch along with the devices.
        /// </summary>
        /// <param name="newEntity">The new devices batch.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location to track the status of the create.</returns>
        public string Create(DeviceBatchCreationRequest newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => CreateAsync(newEntity, cancellationToken));
        }

        /// <summary>
        /// Creates a new devices batch along with the devices.
        /// </summary>
        /// <param name="newEntity">The new devices batch.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location to track the status of the create.</returns>
        public async Task<string> CreateAsync(DeviceBatchCreationRequest newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<DeviceBatchCreationRequest, string>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateDeviceBatch.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets devices batches associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of devices batches.</returns>
        public ResourceCollection<DeviceBatch> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets devices batches associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of devices batches.</returns>
        public async Task<ResourceCollection<DeviceBatch>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<DeviceBatch>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetDeviceBatches.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<DeviceBatch>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}