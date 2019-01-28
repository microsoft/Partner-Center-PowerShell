// -----------------------------------------------------------------------
// <copyright file="BatchJobStatusCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using Extensions;

    /// <summary>
    /// Implements operations that apply to devices batch upload status collection.
    /// </summary>
    internal class BatchJobStatusCollectionOperations : BasePartnerComponent<string>, IBatchJobStatusCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchJobStatusCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public BatchJobStatusCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a specific customer's devices batch upload status operations.
        /// </summary>
        /// <param name="id">The device collection upload tracking identifier.</param>
        /// <returns>The customer's devices batch upload status operations.</returns>
        public IBatchJobStatus this[string id] => ById(id);

        /// <summary>
        /// Gets a specific customer's devices batch upload status operations.
        /// </summary>
        /// <param name="id">The device collection upload tracking identifier.</param>
        /// <returns>The customer's devices batch upload status operations.</returns>
        public IBatchJobStatus ById(string id)
        {
            return new BatchJobStatusOperations(Partner, Context, id);
        }
    }
}