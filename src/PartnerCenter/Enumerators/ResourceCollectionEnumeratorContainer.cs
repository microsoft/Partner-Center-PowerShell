// -----------------------------------------------------------------------
// <copyright file="ResourceCollectionEnumeratorContainer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Enumerators
{
    using System;
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
    internal class ResourceCollectionEnumeratorContainer : BasePartnerComponent<string>, IResourceCollectionEnumeratorContainer
    {
        /// <summary>
        /// A lazy reference to an audit record enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<AuditRecord, SeekBasedResourceCollection<AuditRecord>>> auditRecordEnumeratorFactory;

        /// <summary>
        /// A lazy reference to a customer enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<Customer, SeekBasedResourceCollection<Customer>>> customerEnumeratorFactory;

        /// <summary>
        /// A lazy reference to a customer user enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<CustomerUser, SeekBasedResourceCollection<CustomerUser>>> customerUserEnumeratorFactory;

        /// <summary>
        /// A lazy reference to an invoice enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<Invoice, ResourceCollection<Invoice>>> invoiceEnumeratorFactory;

        /// <summary>
        /// A lazy reference to an invoice line enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<InvoiceLineItem, ResourceCollection<InvoiceLineItem>>> invoiceLineItemEnumeratorFactory;

        /// <summary>
        /// A lazy reference to an offer enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<Offer, ResourceCollection<Offer>>> offerEnumeratorFactory;

        /// <summary>
        /// A lazy reference to a product enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<Models.Products.Product, ResourceCollection<Models.Products.Product>>> productEnumeratorFactory;

        /// <summary>
        /// A lazy reference to a service request enumerator factory.
        /// </summary>
        private readonly Lazy<IndexBasedCollectionEnumeratorFactory<ServiceRequest, ResourceCollection<ServiceRequest>>> serviceRequestEnumeratorFactory;

        /// <summary>
        /// A lazy reference to a utilization record enumerator factory.
        /// </summary>
        private readonly Lazy<IUtilizationCollectionEnumeratorContainer> utilizationRecordEnumeratorContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCollectionEnumeratorContainer" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public ResourceCollectionEnumeratorContainer(IPartner rootPartnerOperations)
          : base(rootPartnerOperations, null)
        {
            auditRecordEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<AuditRecord, SeekBasedResourceCollection<AuditRecord>>>(() => new IndexBasedCollectionEnumeratorFactory<AuditRecord, SeekBasedResourceCollection<AuditRecord>>(Partner));
            customerEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<Customer, SeekBasedResourceCollection<Customer>>>(() => new IndexBasedCollectionEnumeratorFactory<Customer, SeekBasedResourceCollection<Customer>>(Partner));
            customerUserEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<CustomerUser, SeekBasedResourceCollection<CustomerUser>>>(() => new IndexBasedCollectionEnumeratorFactory<CustomerUser, SeekBasedResourceCollection<CustomerUser>>(Partner));
            invoiceEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<Invoice, ResourceCollection<Invoice>>>(() => new IndexBasedCollectionEnumeratorFactory<Invoice, ResourceCollection<Invoice>>(Partner));
            invoiceLineItemEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<InvoiceLineItem, ResourceCollection<InvoiceLineItem>>>(() => new IndexBasedCollectionEnumeratorFactory<InvoiceLineItem, ResourceCollection<InvoiceLineItem>>(Partner));
            offerEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<Offer, ResourceCollection<Offer>>>(() => new IndexBasedCollectionEnumeratorFactory<Offer, ResourceCollection<Offer>>(Partner));
            productEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<Models.Products.Product, ResourceCollection<Models.Products.Product>>>(() => new IndexBasedCollectionEnumeratorFactory<Models.Products.Product, ResourceCollection<Models.Products.Product>>(Partner));
            serviceRequestEnumeratorFactory = new Lazy<IndexBasedCollectionEnumeratorFactory<ServiceRequest, ResourceCollection<ServiceRequest>>>(() => new IndexBasedCollectionEnumeratorFactory<ServiceRequest, ResourceCollection<ServiceRequest>>(Partner));
            utilizationRecordEnumeratorContainer = new Lazy<IUtilizationCollectionEnumeratorContainer>(() => new UtilizationCollectionEnumeratorContainer(Partner));
        }

        /// <summary>
        /// Gets a factory that creates audit record collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<SeekBasedResourceCollection<AuditRecord>> AuditRecords => auditRecordEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates customer collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<SeekBasedResourceCollection<Customer>> Customers => customerEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates customer user collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<SeekBasedResourceCollection<CustomerUser>> CustomerUsers => customerUserEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates invoice collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<ResourceCollection<Invoice>> Invoices => invoiceEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates invoice line item collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<ResourceCollection<InvoiceLineItem>> InvoiceLineItems => invoiceLineItemEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates offer collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<ResourceCollection<Offer>> Offers => offerEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates product collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<ResourceCollection<Models.Products.Product>> Products => productEnumeratorFactory.Value;

        /// <summary>
        /// Gets a factory that creates service request collection enumerators.
        /// </summary>
        public IResourceCollectionEnumeratorFactory<ResourceCollection<ServiceRequest>> ServiceRequests => serviceRequestEnumeratorFactory.Value;

        /// <summary>
        /// Gets factories that create enumerators for utilization records for different subscriptions.
        /// </summary>
        public IUtilizationCollectionEnumeratorContainer Utilization => utilizationRecordEnumeratorContainer.Value;
    }
}