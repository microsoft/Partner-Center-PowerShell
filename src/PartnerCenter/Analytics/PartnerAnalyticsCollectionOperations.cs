// -----------------------------------------------------------------------
// <copyright file="PartnerAnalyticsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    /// <summary>
    /// Implements the operations on partner analytics collection.
    /// </summary>
    internal class PartnerAnalyticsCollectionOperations : BasePartnerComponent<string>, IPartnerAnalyticsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerAnalyticsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public PartnerAnalyticsCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
            Licenses = new PartnerLicensesAnalyticsCollectionOperations(rootPartnerOperations);
        }

        /// <summary>
        /// Gets the operations on partner's licenses' analytics collection.
        /// </summary>
        public IPartnerLicensesAnalyticsCollection Licenses { get; }
    }
}