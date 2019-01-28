// -----------------------------------------------------------------------
// <copyright file="UtilizationCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Utilization
{
    using System;
    using Extensions;

    /// <summary>
    /// Implements subscription utilization behavior.
    /// </summary>
    internal class UtilizationCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IUtilizationCollection
    {
        private readonly Lazy<IAzureUtilizationCollection> azureUtilizationOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilizationCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <param name="subscriptionId">Identifier for the subscription.</param>
        public UtilizationCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
            : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));

            azureUtilizationOperations = new Lazy<IAzureUtilizationCollection>(
                () => new AzureUtilizationCollectionOperations(
                    rootPartnerOperations, customerId, subscriptionId));
        }

        /// <summary>
        /// Gets Azure subscription utilization behavior.
        /// </summary>
        public IAzureUtilizationCollection Azure => azureUtilizationOperations.Value;
    }
}