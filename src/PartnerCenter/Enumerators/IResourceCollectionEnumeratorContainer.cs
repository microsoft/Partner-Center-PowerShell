// -----------------------------------------------------------------------
// <copyright file="IResourceCollectionEnumeratorContainer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Enumerators
{
    using Factories;
    using Models;
    using Models.Auditing;
    using Models.Customers;
    using Models.Invoices;
    using Models.Offers;
    using Models.ServiceRequests;
    using Models.Users;

    /// <summary>
    /// Contains supported resource collection enumerators.
    /// </summary>
    public interface IResourceCollectionEnumeratorContainer : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets a factory that creates audit record collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<SeekBasedResourceCollection<AuditRecord>> AuditRecords { get; }

        /// <summary>
        /// Gets a factory that creates customer collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<SeekBasedResourceCollection<Customer>> Customers { get; }

        /// <summary>
        /// Gets a factory that creates customer user collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<SeekBasedResourceCollection<CustomerUser>> CustomerUsers { get; }

        /// <summary>
        /// Gets a factory that creates invoice collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<ResourceCollection<Invoice>> Invoices { get; }

        /// <summary>
        /// Gets a factory that creates invoice line item collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<ResourceCollection<InvoiceLineItem>> InvoiceLineItems { get; }


        /// <summary>
        /// Gets a factory that creates offer collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<ResourceCollection<Offer>> Offers { get; }

        /// <summary>
        /// Gets a factory that creates product collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<ResourceCollection<Models.Products.Product>> Products { get; }

        /// <summary>
        /// Gets a factory that creates service request collection enumerators.
        /// </summary>
        IResourceCollectionEnumeratorFactory<ResourceCollection<ServiceRequest>> ServiceRequests { get; }

        /// <summary>
        /// Gets factories that create enumerators for utilization records for different subscriptions.
        /// </summary>
        IUtilizationCollectionEnumeratorContainer Utilization { get; }
    }
}