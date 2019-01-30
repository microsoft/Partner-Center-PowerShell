// -----------------------------------------------------------------------
// <copyright file="CustomerProductCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Products
{
    using Extensions;
    using PartnerCenter.Products;

    /// <summary>
    /// Product operations by customer id implementation class.
    /// </summary>
    internal class CustomerProductCollectionOperations : BasePartnerComponent<string>, ICustomerProductCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProductCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerProductCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets the operations tied with a specific product for a given customer.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product by customer identifier.</returns>
        public IProduct this[string id] => ById(id);

        /// <summary>
        /// Gets the operations tied with a specific product for a given customer.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product by customer identifier.</returns>
        public IProduct ById(string id)
        {
            return new CustomerProductOperations(Partner, Context, id);
        }

        /// <summary>
        /// Gets the operations that can be applied on products in a given catalog view and that apply to a given customer.
        /// </summary>
        /// <param name="targetView">The product target view.</param>
        /// <returns>The catalog view operations by customer id and by target view.</returns>
        public ICustomerProductCollectionByTargetView ByTargetView(string targetView)
        {
            return new CustomerProductCollectionByTargetViewOperations(Partner, Context, targetView);
        }
    }
}