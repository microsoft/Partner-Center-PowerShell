// -----------------------------------------------------------------------
// <copyright file="PartnerOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter
{
    using System;
    using System.Net.Http;
    using Agreements;
    using Analytics;
    using Auditing;
    using Customers;
    using Domains;
    using Enumerators;
    using Extensions;
    using GenericOperations;
    using Incidents;
    using Invoices;
    using Network;
    using Offers;
    using Products;
    using Profiles;
    using RateCards;
    using Relationships;
    using RequestContext;
    using ServiceRequests;
    using Usage;
    using ValidationRules;
    using Validations;

    /// <summary>
    /// Implementation of the partner operations.
    /// </summary>
    internal class PartnerOperations : IPartner
    {
        /// <summary>
        /// Provides access to the agreement details operations.
        /// </summary>
        private readonly Lazy<IAgreementDetailsCollection> agreementDetails;

        /// <summary>
        /// Provides access to the partner analytics collection operations.
        /// </summary>
        private readonly Lazy<IPartnerAnalyticsCollection> analytics;

        /// <summary>
        /// Provides access to the audit records collection operations.
        /// </summary>
        private readonly Lazy<IAuditRecordsCollection> auditRecords;

        /// <summary>
        /// Provides access to the country validation rules collection operations.
        /// </summary>
        private readonly Lazy<ICountryValidationRulesCollection> countryValidationRules;

        /// <summary>
        /// Provides access to the available customer operations.
        /// </summary>
        private readonly Lazy<ICustomerCollection> customers;

        /// <summary>
        /// Provides access to the available domain collection operations.
        /// </summary>
        private readonly Lazy<IDomainCollection> domains;

        /// <summary>
        /// Provides access to the resource collection enumerator container.
        /// </summary>
        private readonly Lazy<IResourceCollectionEnumeratorContainer> enumeratorContainer;

        /// <summary>
        /// Provides access ot the extension operations.
        /// </summary>
        private readonly Lazy<IExtensions> extensions;

        /// <summary>
        /// Provides access to the invoice collection operations.
        /// </summary>
        private readonly Lazy<IInvoiceCollection> invoices;

        /// <summary>
        /// Provides access to the offer category collection operations.
        /// </summary>
        private readonly Lazy<ICountrySelector<IOfferCategoryCollection>> offerCategories;

        /// <summary>
        /// Provides access to the offer collection operations.
        /// </summary>
        private readonly Lazy<ICountrySelector<IOfferCollection>> offers;

        /// <summary>
        /// Provides access to the product collection operations.
        /// </summary>
        private readonly Lazy<IProductCollection> products;

        /// <summary>
        /// Provides access to the partner profile collection operations.
        /// </summary>
        private readonly Lazy<IPartnerProfileCollection> profiles;

        /// <summary>
        /// Provides access to the rate cards collection operations.
        /// </summary>
        private readonly Lazy<IRateCardCollection> rateCards;

        /// <summary>
        /// Provides access to the relationship collection operations.
        /// </summary>
        private readonly Lazy<IRelationshipCollection> relationships;

        /// <summary>
        /// Provides access to the service incident collection operations.
        /// </summary>
        private readonly Lazy<IServiceIncidentCollection> serviceIncidents;

        /// <summary>
        /// Provides access to the service request collection operations.
        /// </summary>
        private readonly Lazy<IPartnerServiceRequestCollection> serviceRequests;

        /// <summary>
        /// Provides access to the partner usage summary operations.
        /// </summary>
        private readonly Lazy<IPartnerUsageSummary> usage;

        /// <summary>
        /// Provides access to the validation operations.
        /// </summary>
        private readonly Lazy<IValidations> validations;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        private PartnerOperations()
        {
            agreementDetails = new Lazy<IAgreementDetailsCollection>(() => new AgreementDetailsCollectionOperations(this));
            analytics = new Lazy<IPartnerAnalyticsCollection>(() => new PartnerAnalyticsCollectionOperations(this));
            auditRecords = new Lazy<IAuditRecordsCollection>(() => new AuditRecordCollectionOperations(this));
            countryValidationRules = new Lazy<ICountryValidationRulesCollection>(() => new CountryValidationRulesCollectionOperations(this));
            customers = new Lazy<ICustomerCollection>(() => new CustomerCollectionOperations(this));
            domains = new Lazy<IDomainCollection>(() => new DomainCollectionOperations(this));
            enumeratorContainer = new Lazy<IResourceCollectionEnumeratorContainer>(() => new ResourceCollectionEnumeratorContainer(this));
            extensions = new Lazy<IExtensions>(() => new ExtensionsOperations(this));
            invoices = new Lazy<IInvoiceCollection>(() => new InvoiceCollectionOperations(this));
            offerCategories = new Lazy<ICountrySelector<IOfferCategoryCollection>>(() => new OfferCountrySelector(this));
            offers = new Lazy<ICountrySelector<IOfferCollection>>(() => new OfferCountrySelector(this));
            products = new Lazy<IProductCollection>(() => new ProductCollectionOperations(this));
            profiles = new Lazy<IPartnerProfileCollection>(() => new PartnerProfileCollectionOperations(this));
            rateCards = new Lazy<IRateCardCollection>(() => new RateCardCollectionOperations(this));
            relationships = new Lazy<IRelationshipCollection>(() => new RelationshipCollectionOperations(this));
            serviceIncidents = new Lazy<IServiceIncidentCollection>(() => new ServiceIncidentCollectionOperations(this));
            serviceRequests = new Lazy<IPartnerServiceRequestCollection>(() => new PartnerServiceRequestCollectionOperations(this));
            usage = new Lazy<IPartnerUsageSummary>(() => new PartnerUsageSummaryOperations(this));
            validations = new Lazy<IValidations>(() => new ValidationOperations(this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        /// <param name="credentials">Credentials to be used when accessing resources.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        public PartnerOperations(IPartnerCredentials credentials, IRequestContext context) : this()
        {
            Credentials = credentials;
            RequestContext = context;

            ServiceClient = new PartnerServiceClient(this, PartnerService.Instance.ApiRootUrl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        /// <param name="credentials">Credentials to be used when accessing resources.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        public PartnerOperations(IPartnerCredentials credentials, IRequestContext requestContext, params DelegatingHandler[] handlers)
            : this()
        {
            Credentials = credentials;
            RequestContext = requestContext;

            ServiceClient = new PartnerServiceClient(
                this,
                PartnerService.Instance.ApiRootUrl,
                handlers);
        }

        /// <summary>
        /// Initializes a instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        /// <param name="credentials">Credentials to be used when accessing resources.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="httpClient">Client used to send HTTP requests.</param>
        public PartnerOperations(IPartnerCredentials credentials, IRequestContext requestContext, HttpClient httpClient)
            : this()
        {
            Credentials = credentials;
            RequestContext = requestContext;

            ServiceClient = new PartnerServiceClient(
                this,
                PartnerService.Instance.ApiRootUrl,
                httpClient);
        }

        /// <summary>
        /// Gets the agreement details operations available.
        /// </summary>
        public IAgreementDetailsCollection AgreementDetails => agreementDetails.Value;

        /// <summary>
        /// Gets the analytics collection operations available to the partner.
        /// </summary>
        public IPartnerAnalyticsCollection Analytics => analytics.Value;

        /// <summary>
        /// Gets the audit records operations available to the partner.
        /// </summary>
        public IAuditRecordsCollection AuditRecords => auditRecords.Value;

        /// <summary>
        /// Gets the country validation rules collection operations available to the partner.
        /// </summary>
        public ICountryValidationRulesCollection CountryValidationRules => countryValidationRules.Value;

        /// <summary>
        /// Gets the partner credentials.
        /// </summary>
        public IPartnerCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the the available customer operations. 
        /// </summary>
        public ICustomerCollection Customers => customers.Value;

        /// <summary>
        /// Gets the domains operations available to the partner.
        /// </summary>
        public IDomainCollection Domains => domains.Value;

        /// <summary>
        /// Gets the collection enumerators available for traversing through results.
        /// </summary>
        public IResourceCollectionEnumeratorContainer Enumerators => enumeratorContainer.Value;

        /// <summary>
        /// Gets the extensions operations available to the partner.
        /// </summary>
        public IExtensions Extensions => extensions.Value;

        /// <summary>
        /// Gets the partner's invoices operations.
        /// </summary>
        public IInvoiceCollection Invoices => invoices.Value;

        /// <summary>
        /// Gets the offer categories operations available to the partner.
        /// </summary>
        public ICountrySelector<IOfferCategoryCollection> OfferCategories => offerCategories.Value;

        /// <summary>
        /// Gets the offer operations available to the partner.
        /// </summary>
        public ICountrySelector<IOfferCollection> Offers => offers.Value;

        /// <summary>
        /// Gets the product operations available to the partner.
        /// </summary>
        public IProductCollection Products => products.Value;

        /// <summary>
        /// Gets the profiles operations available to the partner.
        /// </summary>
        public IPartnerProfileCollection Profiles => profiles.Value;

        /// <summary>
        /// Gets the rate card operations available to the partner.
        /// </summary>
        public IRateCardCollection RateCards => rateCards.Value;

        /// <summary>
        /// Gets the relationship collection operations available to the partner.
        /// </summary>
        public IRelationshipCollection Relationships => relationships.Value;

        /// <summary>
        /// Gets the partner context.
        /// </summary>
        public IRequestContext RequestContext { get; private set; }

        /// <summary>
        /// Gets the partner service client.
        /// </summary>
        public IPartnerServiceClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the service health operations that can be performed on a partner's subscribed services.
        /// </summary>
        public IServiceIncidentCollection ServiceIncidents => serviceIncidents.Value;

        /// <summary>
        /// Gets the operations that can be performed on a partners' service requests.
        /// </summary>
        public IPartnerServiceRequestCollection ServiceRequests => serviceRequests.Value;

        /// <summary>
        /// Gets the usage summary operations available to the partner.
        /// </summary>
        public IPartnerUsageSummary UsageSummary => usage.Value;

        /// <summary>
        /// Gets the validation operations available to the partner.
        /// </summary>
        public IValidations Validations => validations.Value;
    }
}