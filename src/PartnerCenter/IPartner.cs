// -----------------------------------------------------------------------
// <copyright file="IPartner.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter
{
    using Agreements;
    using Analytics;
    using Auditing;
    using CountryValidationRules;
    using Customers;
    using Domains;
    using Enumerators;
    using Extensions;
    using GenericOperations;
    using Invoices;
    using Network;
    using Offers;
    using Products;
    using Profiles;
    using RateCards;
    using Relationships;
    using RequestContext;
    using ServiceIncidents;
    using ServiceRequests;
    using Usage;
    using Validations;

    /// <summary>
    /// The main entry point into using the Partner Center SDK functionality. Represents a partner and encapsulates all the behavior attached to partners.
    /// Use this interface to get to the partner's customers, profiles, and customer orders, profiles and subscriptions and more.
    /// </summary>
    public interface IPartner
    {
        /// <summary>
        /// Gets the agreement details operations available.
        /// </summary>
        IAgreementDetailsCollection AgreementDetails { get; }

        /// <summary>
        /// Gets the analytics collection operations available to the partner.
        /// </summary>
        IPartnerAnalyticsCollection Analytics { get; }

        /// <summary>
        /// Gets the audit records operations available to the partner.
        /// </summary>
        IAuditRecordsCollection AuditRecords { get; }

        /// <summary>
        /// Gets the country validation rules collection operations available to the partner.
        /// </summary>
        ICountryValidationRulesCollection CountryValidationRules { get; }

        /// <summary>
        /// Gets the partner credentials.
        /// </summary>
        IPartnerCredentials Credentials { get; }

        /// <summary>
        /// Gets the the available customer operations. 
        /// </summary>
        ICustomerCollection Customers { get; }

        /// <summary>
        /// Gets the domains operations available to the partner.
        /// </summary>
        IDomainCollection Domains { get; }

        /// <summary>
        /// Gets the collection enumerators available for traversing through results.
        /// </summary>
        IResourceCollectionEnumeratorContainer Enumerators { get; }

        /// <summary>
        /// Gets the extensions operations available to the partner.
        /// </summary>
        IExtensions Extensions { get; }

        /// <summary>
        /// Gets the partner's invoices operations.
        /// </summary>
        IInvoiceCollection Invoices { get; }

        /// <summary>
        /// Gets the offer categories operations available to the partner.
        /// </summary>
        ICountrySelector<IOfferCategoryCollection> OfferCategories { get; }

        /// <summary>
        /// Gets the offer operations available to the partner.
        /// </summary>
        ICountrySelector<IOfferCollection> Offers { get; }

        /// <summary>
        /// Gets the product operations available to the partner.
        /// </summary>
        IProductCollection Products { get; }

        /// <summary>
        /// Gets the profiles operations available to the partner.
        /// </summary>
        IPartnerProfileCollection Profiles { get; }

        /// <summary>
        /// Gets the rate card operations available to the partner.
        /// </summary>
        IRateCardCollection RateCards { get; }

        /// <summary>
        /// Gets the relationship collection operations available to the partner.
        /// </summary>
        IRelationshipCollection Relationships { get; }

        /// <summary>
        /// Gets the partner context.
        /// </summary>
        IRequestContext RequestContext { get; }

        /// <summary>
        /// Gets the partner service client.
        /// </summary>
        IPartnerServiceClient ServiceClient { get; }

        /// <summary>
        /// Gets the service health operations that can be performed on a partner's subscribed services.
        /// </summary>
        IServiceIncidentCollection ServiceIncidents { get; }

        /// <summary>
        /// Gets the operations that can be performed on a partners' service requests.
        /// </summary>
        IPartnerServiceRequestCollection ServiceRequests { get; }

        /// <summary>
        /// Gets the usage summary operations available to the partner.
        /// </summary>
        IPartnerUsageSummary UsageSummary { get; }

        /// <summary>
        /// Gets the validation operations available to the partner.
        /// </summary>
        IValidations Validations { get; }
    }
}