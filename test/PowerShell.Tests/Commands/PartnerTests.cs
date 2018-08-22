// -----------------------------------------------------------------------
// <copyright file="PartnerTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using System.Management.Automation;
    using Authentication;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.CountryValidationRules;
    using PartnerCenter.Models.Partners;
    using PartnerCenter.PowerShell.Tests.Factories;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available partner cmdlets.
    /// </summary>
    [TestClass]
    public class PartnerTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerBillingProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerBillingProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerBillingProfile");
        }        

        /// <summary>
        /// Unit test for the Get-PartnerLegalProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerLegalProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerLegalProfile");
        }

        /// <summary>
        /// Unit test for the Get-PartnerMpnProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerMpnProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerMpnProfile");
        }

        /// <summary>
        /// Unit test for the Get-PartnerSupportProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerSupportProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerSupportProfile");
        }

        /// <summary>
        /// Unit test for the Set-PartnerBillingProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void SetBillingProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerBillingProfile");
        }

        /// <summary>
        /// Unit test for the Set-PartnerBillingPorifle cmdlet that expects the <see cref="CmdletInvocationException" /> exception to be thrown. 
        /// </summary>
        [ExpectedException(typeof(CmdletInvocationException))]
        [TestMethod]
        public void SetBillingProfileWithInvalidAddressTest()
        {
            RunPowerShellTest(CreatePartnerOperationsWithInvalidAddress, "Test-SetPartnerBillingProfile");
        }

        /// <summary>
        /// Unit test for the Set-SetPartnerLegalProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void SetPartnerLegalProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerLegalProfile");
        }

        /// <summary>
        /// Unit test for the Set-SetPartnerSupportProfile cmdlet.
        /// </summary>
        [TestMethod]
        public void SetPartnerSupportProfileTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-SetPartnerSupportProfile");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public IPartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            // Billing Profile 
            partnerOperations.Setup(p => p.Profiles.BillingProfile.Get()).Returns(GetPartnerBillingProfile());
            partnerOperations.Setup(p => p.Profiles.BillingProfile.Update(It.IsAny<BillingProfile>())).Returns(GetPartnerBillingProfileUpdated());

            // Country Validation Rules
            partnerOperations.Setup(p => p.CountryValidationRules.ByCountry(It.IsAny<string>()).Get()).Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-US"));

            // Legal Profile 
            partnerOperations.Setup(p => p.Profiles.LegalBusinessProfile.Get(VettingVersion.Current)).Returns(
                OperationFactory.Instance.GetResource<LegalBusinessProfile>("GetPartnerLegalProfile"));
            partnerOperations.Setup(p => p.Profiles.LegalBusinessProfile.Update(It.IsAny<LegalBusinessProfile>())).Returns(
                OperationFactory.Instance.GetResource<LegalBusinessProfile>("UpdatePartnerLegalProfile"));

            // MPN Profile
            partnerOperations.Setup(p => p.Profiles.MpnProfile.Get()).Returns(
                OperationFactory.Instance.GetResource<MpnProfile>("GetMpnProfile"));

            // Support Profile
            partnerOperations.Setup(p => p.Profiles.SupportProfile.Get()).Returns(
                OperationFactory.Instance.GetResource<SupportProfile>("GetPartnerSupportProfile"));
            partnerOperations.Setup(p => p.Profiles.SupportProfile.Get()).Returns(
                OperationFactory.Instance.GetResource<SupportProfile>("UpdatePartnerSupportProfile"));

            // Validations
            partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);
            partnerOperations.Setup(p => p.CountryValidationRules.ByCountry(It.IsAny<string>()).Get()).Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-US"));

            return partnerOperations.Object;
        }

        /// <summary>
        /// Creates an instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private IPartner CreatePartnerOperationsWithInvalidAddress(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            partnerOperations.Setup(p => p.Profiles.BillingProfile.Get()).Returns(GetPartnerBillingProfile());
            partnerOperations.Setup(p => p.Profiles.BillingProfile.Update(It.IsAny<BillingProfile>())).Returns(GetPartnerBillingProfileUpdated());
            partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(false);

            return partnerOperations.Object;
        }

        /// <summary>
        /// Gets an instance of the <see cref="BillingProfile" /> class used for testing purposees.
        /// </summary>
        /// <returns>
        /// An instance of the <see cref="BillingProfile" /> class used for testing purposes.
        /// </returns>
        private BillingProfile GetPartnerBillingProfile()
        {
            return new BillingProfile
            {
                Address = new Address
                {
                    AddressLine1 = "1 Microsoft Way",
                    City = "Redmond",
                    Country = "US",
                    PostalCode = "98052",
                    State = "WA"
                },
                BillingCurrency = "USD",
                BillingDay = 1,
                CompanyName = "Contoso",
                PrimaryContact = new Contact
                {
                    Email = "john@contoso.com",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "555-555-5555"
                },
                PurchaseOrderNumber = "1234",
                TaxId = "5678"
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="BillingProfile" /> class used for unit testing.
        /// </summary>
        /// <returns>
        /// An instance of the <see cref="BillingProfile" /> class used for testing purposes.
        /// </returns>
        private BillingProfile GetPartnerBillingProfileUpdated()
        {
            return new BillingProfile
            {
                Address = new Address
                {
                    AddressLine1 = "700 Bellevue Way NE",
                    City = "Bellevue",
                    Country = "US",
                    PostalCode = "98004",
                    State = "WA"
                },
                BillingCurrency = "USD",
                BillingDay = 1,
                CompanyName = "Contoso",
                PrimaryContact = new Contact
                {
                    Email = "jdoe@contoso.com",
                    FirstName = "Jonathan",
                    LastName = "Doe",
                    PhoneNumber = "425-555-5555"
                },
                PurchaseOrderNumber = "1234",
                TaxId = "0123"
            };
        }
    }
}