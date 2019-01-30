// -----------------------------------------------------------------------
// <copyright file="UtilizationCollectionEnumeratorContainer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Enumerators
{
    using System;
    using Factories;
    using Models;
    using Models.Utilizations;

    /// <summary>
    /// Utilization collection enumerator container implementation class.
    /// </summary>
    internal class UtilizationCollectionEnumeratorContainer : BasePartnerComponent<string>, IUtilizationCollectionEnumeratorContainer
    {
        /// <summary>
        /// A lazy reference to an Azure utilization record enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<AzureUtilizationRecord, ResourceCollection<AzureUtilizationRecord>>> azureUtilizationRecordEnumeratorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilizationCollectionEnumeratorContainer" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public UtilizationCollectionEnumeratorContainer(IPartner rootPartnerOperations)
          : base(rootPartnerOperations, null)
        {
            azureUtilizationRecordEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<AzureUtilizationRecord, ResourceCollection<AzureUtilizationRecord>>>(() => new IndexBasedCollectionEnumeratorFactory<AzureUtilizationRecord, ResourceCollection<AzureUtilizationRecord>>(Partner));
        }

        /// <summary>
        /// Gets a factory that creates Azure utilization record collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<ResourceCollection<AzureUtilizationRecord>> Azure => azureUtilizationRecordEnumeratorFactory.Value;
    }
}