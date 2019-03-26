// -----------------------------------------------------------------------
// <copyright file="EstimateCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    /// <summary>
    /// Defines the operations available for estimate collection.
    /// </summary>
    internal class EstimateCollectionOperations : BasePartnerComponent<string>, IEstimateCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateCollectionOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public EstimateCollectionOperations(IPartner rootPartnerOperations)
            : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets the estimate links of the reconciliation line items.
        /// </summary>
        public IEstimateLink Links => new EstimateLinkOperations(Partner);
    }
}