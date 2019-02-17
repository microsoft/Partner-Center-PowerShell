// -----------------------------------------------------------------------
// <copyright file="ICustomer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers
{
    using Agreements;
    using Analytics;
    using ApplicationConsents;
    using Carts;
    using CustomerDirectoryRoles;
    using Customers.Products;
    using CustomerUsers;
    using DevicesDeployment;
    using Entitlements;
    using GenericOperations;
    using ManagedServices;
    using Models.Customers;
    using Offers;
    using Orders;
    using Profiles;
    using Qualification;
    using Relationships;
    using ServiceCosts;
    using ServiceRequests;
    using SubscribedSkus;
    using Subscriptions;
    using Usage;

    /// <summary>
    /// Groups operations that can be performed on a single partner customer.
    /// </summary>
    public interface ICustomer : IPartnerComponent<string>, IEntityGetOperations<Customer>, IEntityDeleteOperations<Customer>, IEntityPatchOperations<Customer>
    {
        /// <summary>
        /// Gets the agreements behavior for the customer.
        /// </summary>
        ICustomerAgreementCollection Agreements { get; }

        /// <summary>
        /// Gets the analytics collection behavior for the customer.
        /// </summary>
        ICustomerAnalyticsCollection Analytics { get; }

        /// <summary>
        /// Gets the application consent collection behavior for the customer.
        /// </summary>
        IApplicationConsentCollection ApplicationConsents { get; }

        /// <summary>
        /// Gets the devices batch upload status behavior of the customer.
        /// </summary>
        IBatchJobStatusCollection BatchUploadStatus { get; }

        /// <summary>
        /// Gets the cart collection behavior for the customer.
        /// </summary>
        ICartCollection Carts { get; }

        /// <summary>
        /// Gets the configuration policies behavior for the customer.
        /// </summary>
        IConfigurationPolicyCollection ConfigurationPolicies { get; }

        /// <summary>
        /// Gets the devices batch behavior of the customer.
        /// </summary>
        IDevicesBatchCollection DeviceBatches { get; }

        /// <summary>
        /// Gets the device policy behavior of the customer.
        /// </summary>
        ICustomerDeviceCollection DevicePolicy { get; }

        /// <summary>
        /// Gets the directory role behavior for the customer.
        /// </summary>
        IDirectoryRoleCollection DirectoryRoles { get; }

        /// <summary>
        /// Gets the entitlement collection behavior for the customer.
        /// </summary>
        IEntitlementCollection Entitlements { get; }

        /// <summary>
        /// Gets the managed services behavior for the customer.
        /// </summary>
        IManagedServiceCollection ManagedServices { get; }

        /// <summary>
        /// Gets the Offers behavior for the customer.
        /// </summary>
        ICustomerOfferCollection Offers { get; }

        /// <summary>
        /// Gets the Offer Categories behavior for the customer.
        /// </summary>
        ICustomerOfferCategoryCollection OfferCategories { get; }

        /// <summary>
        /// Gets the orders behavior for the customer.
        /// </summary>
        IOrderCollection Orders { get; }

        /// <summary>
        /// Gets the Products behavior for the customer.
        /// </summary>
        ICustomerProductCollection Products { get; }

        /// <summary>
        /// Gets the profiles behavior for the customer.
        /// </summary>
        ICustomerProfileCollection Profiles { get; }

        /// <summary>
        /// Gets the qualification behavior of the customer.
        /// </summary>
        ICustomerQualification Qualification { get; }

        /// <summary>
        /// Gets the relationship collection behavior for the customer.
        /// </summary>
        ICustomerRelationshipCollection Relationships { get; }

        /// <summary>
        /// Gets the service costs behavior for the customer.
        /// </summary>
        ICustomerServiceCostsCollection ServiceCosts { get; }

        /// <summary>
        /// Gets the service requests behavior for the customer.
        /// </summary>
        IServiceRequestCollection ServiceRequests { get; }

        /// <summary>
        /// Gets the subscribed SKUs collection behavior for the customer.
        /// </summary>
        ICustomerSubscribedSkuCollection SubscribedSkus { get; }

        /// <summary>
        /// Gets the subscriptions behavior for the customer.
        /// </summary>
        ISubscriptionCollection Subscriptions { get; }

        /// <summary>
        /// Gets the usage spending budget behavior for the customer.
        /// </summary>
        ICustomerUsageSpendingBudget UsageBudget { get; }

        /// <summary>
        /// Gets the usage summary behavior for the customer.
        /// </summary>
        ICustomerUsageSummary UsageSummary { get; }

        /// <summary>
        /// Gets the users behavior for the customer.
        /// </summary>
        ICustomerUserCollection Users { get; }
    }
}