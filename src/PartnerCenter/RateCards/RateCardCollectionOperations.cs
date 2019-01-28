// -----------------------------------------------------------------------
// <copyright file="PSAzureRateCard.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RateCards
{
    /// <summary>Implements operations that apply to rate cards.</summary>
    internal class RateCardCollectionOperations : BasePartnerComponent<string>, IRateCardCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateCardCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public RateCardCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
            Azure = new AzureRateCardOperations(rootPartnerOperations);
        }

        /// <summary>
        /// Gets the Azure rate card operations.
        /// </summary>
        public IAzureRateCard Azure { get; private set; }
    }
}