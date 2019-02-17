// -----------------------------------------------------------------------
// <copyright file="CustomerOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Agreements;
    using Analytics;
    using ApplicationConsents;
    using Carts;
    using CustomerDirectoryRoles;
    using Customers.Products;
    using CustomerUsers;
    using DevicesDeployment;
    using Entitlements;
    using Extensions;
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
    /// Impelements the available operations for a customer.
    /// </summary>
    internal class CustomerOperations : BasePartnerComponent<string>, ICustomer
    {
        /// <summary>
        /// Provides access to the available agreement operations.
        /// </summary>
        private readonly Lazy<ICustomerAgreementCollection> agreements;

        /// <summary>
        /// Provides access to the customer analytics collection operations.
        /// </summary>
        private readonly Lazy<ICustomerAnalyticsCollection> analytics;

        /// <summary>
        /// Provides access to the application consent collection operations.
        /// </summary>
        private readonly Lazy<IApplicationConsentCollection> applicationConsents;

        /// <summary>
        /// Provides access to the batch status collection operations.
        /// </summary>
        private readonly Lazy<IBatchJobStatusCollection> batchUploadStatus;

        /// <summary>
        /// Provides access to the carts collection operations.
        /// </summary>
        private readonly Lazy<ICartCollection> carts;

        /// <summary>
        /// Provides access to the configuration policies.
        /// </summary>
        private readonly Lazy<IConfigurationPolicyCollection> configurationPolicies;

        /// <summary>
        /// Provides access to the customer qualification operations.
        /// </summary>
        private readonly Lazy<ICustomerQualification> customerQualification;

        /// <summary>
        /// Provides access to the customer relationship collection operations.
        /// </summary>
        private readonly Lazy<ICustomerRelationshipCollection> customerRelationships;

        /// <summary>
        /// Provides access to the customer user collection operations.
        /// </summary>
        private readonly Lazy<ICustomerUserCollection> customerUsers;

        /// <summary>
        /// Provides access to the device batch collection operations.
        /// </summary>
        private readonly Lazy<IDevicesBatchCollection> deviceBatches;

        /// <summary>
        /// Provides access to the device collection operations.
        /// </summary>
        private readonly Lazy<ICustomerDeviceCollection> devices;

        /// <summary>
        /// Provides access to the directory roles collection operations.
        /// </summary>
        private readonly Lazy<IDirectoryRoleCollection> directoryRoles;

        /// <summary>
        /// Provides access to the entitlement collection operations.
        /// </summary>
        private readonly Lazy<IEntitlementCollection> entitlements;

        /// <summary>
        /// Provides access to the managed service collection operations.
        /// </summary>
        private readonly Lazy<IManagedServiceCollection> managedServices;

        /// <summary>
        /// Provides access to the offer category operations.
        /// </summary>
        private readonly Lazy<ICustomerOfferCategoryCollection> offerCategories;

        /// <summary>
        /// Provides access to the available customer offer operations.
        /// </summary>
        private readonly Lazy<ICustomerOfferCollection> offers;

        /// <summary>
        /// Provides access to the order collection operations.
        /// </summary>
        private readonly Lazy<IOrderCollection> orders;

        /// <summary>
        /// Provides access to the product collection operations.
        /// </summary>
        private readonly Lazy<ICustomerProductCollection> products;

        /// <summary>
        /// Provides access to the available customer profile operations.
        /// </summary>
        private readonly Lazy<ICustomerProfileCollection> profiles;

        /// <summary>
        /// Provides access to the available service cost operations.
        /// </summary>
        private readonly Lazy<ICustomerServiceCostsCollection> serviceCosts;

        /// <summary>
        /// Provides access to the available service request operations.
        /// </summary>
        private readonly Lazy<IServiceRequestCollection> serviceRequests;

        /// <summary>
        /// Provides access to the available customer subscribed SKU collection operations.
        /// </summary>
        private readonly Lazy<ICustomerSubscribedSkuCollection> subscribedSkus;

        /// <summary>
        /// Provides access to the available subscription operations.
        /// </summary>
        private readonly Lazy<ISubscriptionCollection> subscriptions;

        /// <summary>
        /// Provides access to the available customer usage spending budget.
        /// </summary>
        private readonly Lazy<ICustomerUsageSpendingBudget> usageBudget;

        /// <summary>
        /// Provides access to the available customer usage summary operations.
        /// </summary>
        private readonly Lazy<ICustomerUsageSummary> usageSummary;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        public CustomerOperations(IPartner rootPartnerOperations, string customerId)
            : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));

            agreements = new Lazy<ICustomerAgreementCollection>(() => new CustomerAgreementCollectionOperations(rootPartnerOperations, customerId));
            analytics = new Lazy<ICustomerAnalyticsCollection>(() => new CustomerAnalyticsCollectionOperations(rootPartnerOperations, customerId));
            applicationConsents = new Lazy<IApplicationConsentCollection>(() => new ApplicationConsentCollectionOperations(rootPartnerOperations, customerId));
            batchUploadStatus = new Lazy<IBatchJobStatusCollection>(() => new BatchJobStatusCollectionOperations(rootPartnerOperations, customerId));
            carts = new Lazy<ICartCollection>(() => new CartCollectionOperations(rootPartnerOperations, customerId));
            configurationPolicies = new Lazy<IConfigurationPolicyCollection>(() => new ConfigurationPolicyCollectionOperations(rootPartnerOperations, customerId));
            customerQualification = new Lazy<ICustomerQualification>(() => new CustomerQualificationOperations(rootPartnerOperations, customerId));
            customerRelationships = new Lazy<ICustomerRelationshipCollection>(() => new CustomerRelationshipCollectionOperations(rootPartnerOperations, customerId));
            customerUsers = new Lazy<ICustomerUserCollection>(() => new CustomerUsersCollectionOperations(rootPartnerOperations, customerId));
            deviceBatches = new Lazy<IDevicesBatchCollection>(() => new DevicesBatchCollectionOperations(rootPartnerOperations, customerId));
            devices = new Lazy<ICustomerDeviceCollection>(() => new CustomerDevicesCollectionOperations(rootPartnerOperations, customerId));
            directoryRoles = new Lazy<IDirectoryRoleCollection>(() => new DirectoryRoleCollectionOperations(rootPartnerOperations, customerId));
            entitlements = new Lazy<IEntitlementCollection>(() => new EntitlementCollectionOperations(rootPartnerOperations, customerId));
            managedServices = new Lazy<IManagedServiceCollection>(() => new ManagedServiceCollectionOperations(rootPartnerOperations, customerId));
            offerCategories = new Lazy<ICustomerOfferCategoryCollection>(() => new CustomerOfferCategoryCollectionOperations(rootPartnerOperations, customerId));
            offers = new Lazy<ICustomerOfferCollection>(() => new CustomerOfferCollectionOperations(rootPartnerOperations, customerId));
            orders = new Lazy<IOrderCollection>(() => new OrderCollectionOperations(rootPartnerOperations, customerId));
            products = new Lazy<ICustomerProductCollection>(() => new CustomerProductCollectionOperations(rootPartnerOperations, customerId));
            profiles = new Lazy<ICustomerProfileCollection>(() => new CustomerProfileCollectionOperations(rootPartnerOperations, customerId));
            serviceCosts = new Lazy<ICustomerServiceCostsCollection>(() => new CustomerServiceCostsCollectionOperations(rootPartnerOperations, customerId));
            serviceRequests = new Lazy<IServiceRequestCollection>(() => new CustomerServiceRequestCollectionOperations(rootPartnerOperations, customerId));
            subscribedSkus = new Lazy<ICustomerSubscribedSkuCollection>(() => new CustomerSubscribedSkuCollectionOperations(rootPartnerOperations, customerId));
            subscriptions = new Lazy<ISubscriptionCollection>(() => new SubscriptionCollectionOperations(rootPartnerOperations, customerId));
            usageBudget = new Lazy<ICustomerUsageSpendingBudget>(() => new CustomerUsageSpendingBudgetOperations(rootPartnerOperations, customerId));
            usageSummary = new Lazy<ICustomerUsageSummary>(() => new CustomerUsageSummaryOperations(rootPartnerOperations, customerId));
        }

        /// <summary>
        /// Gets the agreements behavior for the customer.
        /// </summary>
        public ICustomerAgreementCollection Agreements => agreements.Value;

        /// <summary>
        /// Gets the analytics collection behavior for the customer.
        /// </summary>
        public ICustomerAnalyticsCollection Analytics => analytics.Value;

        /// <summary>
        /// Gets the application consent collection behavior for the customer.
        /// </summary>
        public IApplicationConsentCollection ApplicationConsents => applicationConsents.Value;

        /// <summary>
        /// Gets the devices batch upload status behavior of the customer.
        /// </summary>
        public IBatchJobStatusCollection BatchUploadStatus => batchUploadStatus.Value;

        /// <summary>
        /// Gets the cart collection behavior for the customer.
        /// </summary>
        public ICartCollection Carts => carts.Value;

        /// <summary>
        /// Gets the configuration policies behavior for the customer.
        /// </summary>
        public IConfigurationPolicyCollection ConfigurationPolicies => configurationPolicies.Value;

        /// <summary>
        /// Gets the devices batch behavior of the customer.
        /// </summary>
        public IDevicesBatchCollection DeviceBatches => deviceBatches.Value;

        /// <summary>
        /// Gets the device policy behavior of the customer.
        /// </summary>
        public ICustomerDeviceCollection DevicePolicy => devices.Value;

        /// <summary>
        /// Gets the directory role behavior for the customer.
        /// </summary>
        public IDirectoryRoleCollection DirectoryRoles => directoryRoles.Value;

        /// <summary>
        /// Gets the entitlement collection behavior for the customer.
        /// </summary>
        public IEntitlementCollection Entitlements => entitlements.Value;

        /// <summary>
        /// Gets the managed services behavior for the customer.
        /// </summary>
        public IManagedServiceCollection ManagedServices => managedServices.Value;

        /// <summary>
        /// Gets the Offers behavior for the customer.
        /// </summary>
        public ICustomerOfferCollection Offers => offers.Value;

        /// <summary>
        /// Gets the Offer Categories behavior for the customer.
        /// </summary>
        public ICustomerOfferCategoryCollection OfferCategories => offerCategories.Value;

        /// <summary>
        /// Gets the orders behavior for the customer.
        /// </summary>
        public IOrderCollection Orders => orders.Value;

        /// <summary>
        /// Gets the Products behavior for the customer.
        /// </summary>
        public ICustomerProductCollection Products => products.Value;

        /// <summary>
        /// Gets the profiles behavior for the customer.
        /// </summary>
        public ICustomerProfileCollection Profiles => profiles.Value;

        /// <summary>
        /// Gets the qualification behavior of the customer.
        /// </summary>
        public ICustomerQualification Qualification => customerQualification.Value;

        /// <summary>
        /// Gets the relationship collection behavior for the customer.
        /// </summary>
        public ICustomerRelationshipCollection Relationships => customerRelationships.Value;

        /// <summary>
        /// Gets the service costs behavior for the customer.
        /// </summary>
        public ICustomerServiceCostsCollection ServiceCosts => serviceCosts.Value;

        /// <summary>
        /// Gets the service requests behavior for the customer.
        /// </summary>
        public IServiceRequestCollection ServiceRequests => serviceRequests.Value;

        /// <summary>
        /// Gets the subscribed SKUs collection behavior for the customer.
        /// </summary>
        public ICustomerSubscribedSkuCollection SubscribedSkus => subscribedSkus.Value;

        /// <summary>
        /// Gets the subscriptions behavior for the customer.
        /// </summary>
        public ISubscriptionCollection Subscriptions => subscriptions.Value;

        /// <summary>
        /// Gets the usage spending budget behavior for the customer.
        /// </summary>
        public ICustomerUsageSpendingBudget UsageBudget => usageBudget.Value;

        /// <summary>
        /// Gets the usage summary behavior for the customer.
        /// </summary>
        public ICustomerUsageSummary UsageSummary => usageSummary.Value;

        /// <summary>
        /// Gets the users behavior for the customer.
        /// </summary>
        public ICustomerUserCollection Users => customerUsers.Value;

        /// <summary>
        /// Deletes the customer from a testing in production account. This only works for accounts created in the integration sandbox.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public void Delete(CancellationToken cancellationToken = default(CancellationToken))
        {
            PartnerService.SynchronousExecute(() => DeleteAsync(cancellationToken));
        }

        /// <summary>
        /// Deletes the customer from a testing in production account. This only works for accounts created in the integration sandbox.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Partner.ServiceClient.DeleteAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.DeleteCustomer.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information for the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The information for the customer.</returns>
        public Customer Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the information for the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The information for the customer.</returns>
        public async Task<Customer> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<Customer>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomer.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes Customer Partner relationship when RelationshipToPartner == CustomerPartnerRelationship.None.
        /// </summary>
        /// <param name="customer">A customer with RelationshipToPartner == CustomerPartnerRelationship.None.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer information.</returns>
        public Customer Patch(Customer entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => PatchAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Removes the relationship between the partner and customer when RelationshipToPartner == CustomerPartnerRelationship.None.
        /// </summary>
        /// <param name="customer">A customer with RelationshipToPartner == CustomerPartnerRelationship.None.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer information.</returns>
        public async Task<Customer> PatchAsync(Customer entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<Customer, Customer>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.RemoveCustomerRelationship.Path}",
                        Context),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}