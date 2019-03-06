// -----------------------------------------------------------------------
// <copyright file="IReceiptStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    /// <summary>
    /// Represents the available receipt operations.
    /// </summary>
    internal class ReceiptCollectionOperations : BasePartnerComponent<string>, IReceiptCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptCollectionOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="invoiceId">The invoice id.</param>
        public ReceiptCollectionOperations(IPartner rootPartnerOperations, string invoiceId)
            : base(rootPartnerOperations, invoiceId)
        {
        }

        /// <summary>
        /// Retrieves a specific Invoice receipt behavior.
        /// </summary>
        /// <param name="id">The receipt identifier.</param>
        /// <returns>The available receipt operations.</returns>
        public IReceipt this[string id] => ById(id);

        /// <summary>
        /// Retrieves a specific Invoice receipt behavior.
        /// </summary>
        /// <param name="id">The receipt identifier.</param>
        /// <returns>The available receipt operations.</returns>
        public IReceipt ById(string id)
        {
            return new ReceiptOperations(Partner, Context, id);
        }
    }
}