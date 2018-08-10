// -----------------------------------------------------------------------
// <copyright file="AddressValidatorTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Validations
{
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.CountryValidationRules;
    using PowerShell.Validations;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddressValidatorTests
    {
        /// <summary>
        /// Unit test for an invalid address value.
        /// </summary>
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void InvalidAddressValueTest()
        {
            Address address;
            AddressValidator validator;
            Mock<IPartner> partnerOperations;

            try
            {
                partnerOperations = new Mock<IPartner>();
                partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("US").Get())
                    .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-US"));
                partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(false);

                validator = new AddressValidator(partnerOperations.Object);

                address = new Address
                {
                    AddressLine1 = "1 Microsoft Way",
                    City = "Redmond",
                    Country = "USA",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "425-55-5555",
                    PostalCode = "98052",
                    State = "Washington"
                };

                Assert.AreEqual(true, validator.IsValid(address));
            }
            finally
            {
                address = null;
                partnerOperations = null;
                validator = null;
            }
        }

        /// <summary>
        /// Unit test to validate an address.
        /// </summary>
        [TestMethod]
        public void IsValidCNAddress()
        {
            Address address;
            AddressValidator validator;
            Mock<IPartner> partnerOperations;

            try
            {
                partnerOperations = new Mock<IPartner>();
                partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("CN").Get())
                    .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-CN"));
                partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);

                validator = new AddressValidator(partnerOperations.Object);

                address = new Address
                {
                    AddressLine1 = "5 Danling Street",
                    City = "Haidian District",
                    Country = "CN",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "(86-10) 5917-0101",
                    PostalCode = "100080",
                    State = "BJ"
                };

                Assert.AreEqual(true, validator.IsValid(address));
            }
            finally
            {
                address = null;
                partnerOperations = null;
                validator = null;
            }
        }

        /// <summary>
        /// Unit test to validate an address.
        /// </summary>
        [TestMethod]
        public void IsValidGBAddress()
        {
            Address address;
            AddressValidator validator;
            Mock<IPartner> partnerOperations;

            try
            {
                partnerOperations = new Mock<IPartner>();
                partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("GB").Get())
                    .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-GB"));
                partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);

                validator = new AddressValidator(partnerOperations.Object);

                address = new Address
                {
                    AddressLine1 = "Manchester Business Park 3000 Aviator Way",
                    City = "Manchester",
                    Country = "GB",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "0344 800 2400",
                    PostalCode = "M22 5TG"
                };

                Assert.AreEqual(true, validator.IsValid(address));
            }
            finally
            {
                address = null;
                partnerOperations = null;
                validator = null;
            }
        }

        /// <summary>
        /// Unit test to validate an address.
        /// </summary>
        [TestMethod]
        public void IsValidDEAddress()
        {
            Address address;
            AddressValidator validator;
            Mock<IPartner> partnerOperations;

            try
            {
                partnerOperations = new Mock<IPartner>();
                partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("DE").Get())
                    .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-DE"));
                partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);

                validator = new AddressValidator(partnerOperations.Object);

                address = new Address
                {
                    AddressLine1 = "Walter-Gropius-Str. 5",
                    City = "München",
                    Country = "DE",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "49 (89) 3176 4900",
                    PostalCode = "80807"
                };

                Assert.AreEqual(true, validator.IsValid(address));
            }
            finally
            {
                address = null;
                partnerOperations = null;
                validator = null;
            }
        }

        /// <summary>
        /// Unit test to validate an address.
        /// </summary>
        [TestMethod]
        public void IsValidUSAddressTest()
        {
            Address address;
            AddressValidator validator;
            Mock<IPartner> partnerOperations;

            try
            {
                partnerOperations = new Mock<IPartner>();
                partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("US").Get())
                    .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-US"));
                partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);

                validator = new AddressValidator(partnerOperations.Object);

                address = new Address
                {
                    AddressLine1 = "1 Microsoft Way",
                    City = "Redmond",
                    Country = "US",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "425-555-5555",
                    PostalCode = "98052",
                    State = "WA"
                };

                Assert.AreEqual(true, validator.IsValid(address));
            }
            finally
            {
                address = null;
                partnerOperations = null;
                validator = null;
            }
        }
    }
}