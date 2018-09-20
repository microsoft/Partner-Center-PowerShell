﻿// -----------------------------------------------------------------------
// <copyright file="CustomerTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using System;
    using System.Collections.Generic;
    using Authentication;
    using Enumerators;
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.CountryValidationRules;
    using PartnerCenter.Models.Customers;
    using PartnerCenter.Models.DevicesDeployment;
    using PartnerCenter.Models.Entitlements;
    using PartnerCenter.Models.Licenses;
    using PartnerCenter.Models.ManagedServices;
    using PartnerCenter.Models.Query;
    using PartnerCenter.Models.RelationshipRequests;
    using PartnerCenter.Models.Relationships;
    using PartnerCenter.Models.Roles;
    using PartnerCenter.Models.Subscriptions;
    using PartnerCenter.Models.Users;
    using PartnerCenter.Models.Utilizations;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available customer cmdlets.
    /// </summary>
    [TestClass]
    public class CustomerTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerCustomer cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomer");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerEntitlement cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerEntitlementTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerEntitlement");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerSubscription cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerSubscriptionTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerSubscription");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerSubscriptionUtilization cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerSubscriptionUtilizationTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerSubscriptionUtilization");
        }

        /// <summary>
        /// Unit test for the New-PartnerCustomer cmdlet.
        /// </summary>
        [TestMethod]
        public void NewPartnerCustomerTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-NewPartnerCustomer");
        }

        /// <summary>
        /// Unit test for the Set-PartnerCustomer cmdlet.
        /// </summary>
        [TestMethod]
        public void SetPartnerCustomerTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerCustomer");
        }

        /// <summary>
        /// Unit test for the Set-PartnerCustomerUser cmdlet.
        /// </summary>
        [TestMethod]
        public void SetPartnerCustomerUserTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerCustomerUser");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerDevice cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerDeviceTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerDevice");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerDeviceBatch cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerDeviceBatchTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerDeviceBatch");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerSubscribedSku cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerSubscribedSkuTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerSubscribedSku");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerManagedService cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerManagedServiceTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerManagedService");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerUser cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerUserTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerUser");
        }

        /// <summary>
        /// Unit test for the Remove-PartnerCustomerUser cmdlet.
        /// </summary>
        [TestMethod]
        public void RemovePartnerCustomerUserTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-RemovePartnerCustomerUser");
        }

        /// <summary>
        /// Unit test for the Restore-PartnerCustomerUser cmdlet.
        /// </summary>
        [TestMethod]
        public void RestorePartnerCustomerUserTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-RestorePartnerCustomerUser");
        }

        /// <summary>
        /// Unit test for the New-PartnerCustomerUser cmdlet.
        /// </summary>
        [TestMethod]
        public void NewPartnerCustomerUserTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-NewPartnerCustomerUser");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerUserRole cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerUserRoleTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerUserRole");
        }

        /// <summary>
        /// Unit test for the Add-PartnerCustomerUserRoleMember cmdlet.
        /// </summary>
        [TestMethod]
        public void AddPartnerCustomerUserRoleMemberTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-AddPartnerCustomerUserRoleMember");
        }

        /// <summary>
        /// Unit test for the Remove-PartnerCustomerUserRoleMember cmdlet.
        /// </summary>
        [TestMethod]
        public void RemovePartnerCustomerUserRoleMemberTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-RemovePartnerCustomerUserRoleMember");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerConfigurationPolicy cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerConfigurationPolicyTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerCustomerConfigurationPolicy");
        }

        /// <summary>
        /// Unit test for the Remove-PartnerSandboxCustomer cmdlet.
        /// </summary>
        [TestMethod]
        public void RemovePartnerSandboxCustomerTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-RemovePartnerSandboxCustomer");
        }

        /// <summary>
        /// Unit test for the Set-PartnerCustomerConfigurationPolicy cmdlet.
        /// </summary>
        [TestMethod]
        public void SetPartnerCustomerConfigurationPolicyTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerCustomerConfigurationPolicy");
        }

        /// <summary>
        /// Unit test for the New-PartnerCustomerConfigurationPolicy cmdlet.
        /// </summary>
        [TestMethod]
        public void NewPartnerCustomerConfigurationPolicyTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-NewPartnerCustomerConfigurationPolicy");
        }

        /// <summary>
        /// Unit test for the Remove-PartnerCustomerConfigurationPolicy cmdlet.
        /// </summary>
        [TestMethod]
        public void RemovePartnerCustomerConfigurationPolicyTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-RemovePartnerCustomerConfigurationPolicy");
        }

        /// <summary>
        /// Unit test for the Remove-PartnerResellerRelationship cmdlet.
        /// </summary>
        [TestMethod]
        public void RemovePartnerResellerRelationshipTest()
        {
            RunPowerShellTest(CreateResellerPartnerOperations, "Test-RemovePartnerResellerRelationship");
        }

        /// <summary>
        /// Unit test for the Get-PartnerCustomerRelationshipTest cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerCustomerRelationshipTest()
        {
            RunPowerShellTest(CreateResellerPartnerOperations, "Test-GetPartnerCustomerRelationship");
        }

        /// <summary>
        /// Unit test for the Get-PartnerResellerRequestLink cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerResellerRequestLinkTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerResellerRequestLink");
        }

        /// <summary>
        /// Unit test for the Set-PartnerCustomerUserLicense cmdlet.
        /// </summary>
        [TestMethod]
        public void SetPartnerCustomerUserLicenseTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerCustomerUserLicense");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IPartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            // Customer Configuration Policy
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ConfigurationPolicies.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<ConfigurationPolicy>>("GetCustomerConfigurationPolicies"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ConfigurationPolicies.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<ConfigurationPolicy>>("GetCustomerConfigurationPolicies"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ConfigurationPolicies[It.IsAny<string>()].Get()).
                Returns(OperationFactory.Instance.GetResource<ConfigurationPolicy>("GetCustomerConfigurationPolicyById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).ConfigurationPolicies.ById(It.IsAny<string>()).Get()).
                Returns(OperationFactory.Instance.GetResource<ConfigurationPolicy>("GetCustomerConfigurationPolicyById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ConfigurationPolicies[It.IsAny<string>()].Patch(It.IsAny<ConfigurationPolicy>())).
                Returns(OperationFactory.Instance.GetResource<ConfigurationPolicy>("GetCustomerConfigurationPolicyById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).ConfigurationPolicies.ById(It.IsAny<string>()).Patch(It.IsAny<ConfigurationPolicy>())).
                Returns(OperationFactory.Instance.GetResource<ConfigurationPolicy>("GetCustomerConfigurationPolicyById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ConfigurationPolicies.Create(It.IsAny<ConfigurationPolicy>())).
                Returns(OperationFactory.Instance.GetResource<ConfigurationPolicy>("GetCustomerConfigurationPolicyById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).ConfigurationPolicies.Create(It.IsAny<ConfigurationPolicy>())).
                Returns(OperationFactory.Instance.GetResource<ConfigurationPolicy>("GetCustomerConfigurationPolicyById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ConfigurationPolicies[It.IsAny<string>()].Delete());
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).ConfigurationPolicies.ById(It.IsAny<string>()).Delete());

            // Country Valiation Operations
            partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("US").Get())
                .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-US"));

            // Customer Operations
            partnerOperations.Setup(p => p.Customers.Create(It.IsAny<Customer>()))
                .Returns(OperationFactory.Instance.GetNewCustomer());
            partnerOperations.Setup(p => p.Customers.Get()).Returns(OperationFactory.Instance.GetCustomers());
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Get())
                .Returns(OperationFactory.Instance.GetCustomer());
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Get())
                .Returns(OperationFactory.Instance.GetCustomer());
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Profiles.Billing.Update(It.IsAny<CustomerBillingProfile>())).
                Returns(OperationFactory.Instance.GetCustomerBillingProfile());
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Profiles.Billing.Update(It.IsAny<CustomerBillingProfile>())).
                Returns(OperationFactory.Instance.GetCustomerBillingProfile());
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Entitlements.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<Entitlement>>("GetEntitlement"));

            // Customer User Role Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users[It.IsAny<string>()].DirectoryRoles.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<DirectoryRole>>("GetCustomerUserRoleById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.ById(It.IsAny<string>()).DirectoryRoles.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<DirectoryRole>>("GetCustomerUserRoleById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].DirectoryRoles.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<DirectoryRole>>("GetCustomerUserRoleById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).DirectoryRoles.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<DirectoryRole>>("GetCustomerUserRoleById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].DirectoryRoles[It.IsAny<string>()].UserMembers.Create(It.IsAny<UserMember>())).
                Returns(OperationFactory.Instance.GetResource<UserMember>("AddCustomerUserRoleMember"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).DirectoryRoles.ById(It.IsAny<string>()).UserMembers.Create(It.IsAny<UserMember>())).
                Returns(OperationFactory.Instance.GetResource<UserMember>("AddCustomerUserRoleMember"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].DirectoryRoles[It.IsAny<string>()].UserMembers[It.IsAny<string>()].Delete());
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).DirectoryRoles.ById(It.IsAny<string>()).UserMembers.ById(It.IsAny<string>()).Delete());

            // Delete Operations 
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Delete()).Verifiable();

            // Device Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].DeviceBatches.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<DeviceBatch>>("GetCustomerDeviceBatch"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].DeviceBatches[It.IsAny<string>()].Devices.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<Device>>("GetCustomerDevice"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].DeviceBatches.ById(It.IsAny<string>()).Devices.Get())
                .Returns(OperationFactory.Instance.GetResource<ResourceCollection<Device>>("GetCustomerDevice"));

            // Domain Operations
            partnerOperations.Setup(p => p.Domains.ByDomain(It.IsAny<string>()).Exists()).Returns(false);

            // Enumerator Operations
            partnerOperations.Setup(p => p.Enumerators.Customers.Create(It.IsAny<SeekBasedResourceCollection<Customer>>()))
                .Returns(new ResourceCollectionEnumerator<SeekBasedResourceCollection<Customer>>(OperationFactory.Instance.GetCustomers()));
            partnerOperations.Setup(p => p.Enumerators.Utilization.Azure.Create(It.IsAny<SeekBasedResourceCollection<AzureUtilizationRecord>>()))
                .Returns(new ResourceCollectionEnumerator<ResourceCollection<AzureUtilizationRecord>>(
                    OperationFactory.Instance.GetResource<ResourceCollection<AzureUtilizationRecord>>("GetUtilizationRecords")));

            // License Operations
            List<LicenseGroupId> licenseGroupIds = new List<LicenseGroupId>() { LicenseGroupId.Group1 };

            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].SubscribedSkus.Get(licenseGroupIds)).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<SubscribedSku>>("GetCustomerLicenseByGroup"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).SubscribedSkus.Get(licenseGroupIds)).
                 Returns(OperationFactory.Instance.GetResource<ResourceCollection<SubscribedSku>>("GetCustomerLicenseByGroup"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].SubscribedSkus.Get(null)).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<SubscribedSku>>("GetCustomerLicense"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).SubscribedSkus.Get(null)).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<SubscribedSku>>("GetCustomerLicense"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.ById(It.IsAny<string>()).Licenses.Get(null)).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<License>>("GetCustomerLicenseUser"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users[It.IsAny<string>()].Licenses.Get(null)).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<License>>("GetCustomerLicenseUser"));

            // Managed Service Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].ManagedServices.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<ManagedService>>("GetCustomerManagedServices"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).ManagedServices.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<ManagedService>>("GetCustomerManagedServices"));

            // Request Relationship Operations 
            partnerOperations.Setup(p => p.Customers.RelationshipRequest.Get()).Returns(
                OperationFactory.Instance.GetResource<CustomerRelationshipRequest>("GetResellerRelationshipLink"));

            // Subscription Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Subscriptions.Get()).
                Returns(OperationFactory.Instance.GetResource<ResourceCollection<Subscription>>("GetCustomerSubscription"));

            // User Operations
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.Get()).
               Returns(OperationFactory.Instance.GetResource<SeekBasedResourceCollection<CustomerUser>>("GetCustomerUserAll"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users.Get()).
               Returns(OperationFactory.Instance.GetResource<SeekBasedResourceCollection<CustomerUser>>("GetCustomerUserAll"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users.Query(It.IsAny<IQuery>())).
               Returns(OperationFactory.Instance.GetResource<SeekBasedResourceCollection<CustomerUser>>("GetCustomerUserAllDeleted"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.Query(It.IsAny<IQuery>())).
                Returns(OperationFactory.Instance.GetResource<SeekBasedResourceCollection<CustomerUser>>("GetCustomerUserAllDeleted"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users[It.IsAny<string>()].Get()).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.ById(It.IsAny<string>()).Get()).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Enumerators.CustomerUsers.Create(It.IsAny<SeekBasedResourceCollection<CustomerUser>>())).
                Returns(new ResourceCollectionEnumerator<SeekBasedResourceCollection<CustomerUser>>(OperationFactory.Instance.GetResource<SeekBasedResourceCollection<CustomerUser>>("GetCustomerUserAll")));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users[It.IsAny<string>()].Patch(It.IsAny<CustomerUser>())).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.ById(It.IsAny<string>()).Patch(It.IsAny<CustomerUser>())).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users[It.IsAny<string>()].Patch(It.IsAny<CustomerUser>())).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users.Create(It.IsAny<CustomerUser>())).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Users.Create(It.IsAny<CustomerUser>())).
                Returns(OperationFactory.Instance.GetResource<CustomerUser>("GetCustomerUserById"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Users[It.IsAny<string>()].LicenseUpdates.Create(It.IsAny<LicenseUpdate>())).Returns(
                OperationFactory.Instance.GetResource<LicenseUpdate>("UpdateUserLicense"));

            // Utilization Operations 
            partnerOperations.Setup(p => p.Customers.ById(It.IsAny<string>()).Subscriptions.ById(It.IsAny<string>())
                .Utilization.Azure.Query(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<AzureUtilizationGranularity>(),
                    It.IsAny<bool>(),
                    It.IsAny<int>())).Returns(
                        OperationFactory.Instance.GetResource<ResourceCollection<AzureUtilizationRecord>>("GetUtilizationRecords"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Subscriptions[It.IsAny<string>()]
                .Utilization.Azure.Query(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<AzureUtilizationGranularity>(),
                    It.IsAny<bool>(),
                    It.IsAny<int>())).Returns(
                        OperationFactory.Instance.GetResource<ResourceCollection<AzureUtilizationRecord>>("GetUtilizationRecords"));



            // Validation Operations
            partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);

            return partnerOperations.Object;
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IPartner CreateResellerPartnerOperations(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            // Customer Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Patch(It.IsAny<Customer>())).Returns(
                OperationFactory.Instance.GetResource<Customer>("RemoveResellerRelationship"));

            // Relationship Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Relationships.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<PartnerRelationship>>("GetPartnerRelationship"));

            // Subscription Operations
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Subscriptions.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<Subscription>>("GetCustomerSubscription"));
            partnerOperations.Setup(p => p.Customers[It.IsAny<string>()].Subscriptions[It.IsAny<string>()]
                .Patch(It.IsAny<Subscription>())).Returns(OperationFactory.Instance.GetResource<Subscription>("SuspendSubscription"));

            return partnerOperations.Object;
        }
    }
}