// -----------------------------------------------------------------------
// <copyright file="ValidationTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.CountryValidationRules;
    using Profile;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available validation cmdlets.
    /// </summary>
    [TestClass]
    public class ValidationTests : TestBase
    {
        /// <summary>
        /// Unit test for the Test-PartnerAddress cmdlet.
        /// </summary>
        [TestMethod]
        public void TestPartnerAddressTests()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-TestPartnerAddress");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IAggregatePartner> partnerOperations = new Mock<IAggregatePartner>();

            // Country Valiation Operations
            partnerOperations.Setup(p => p.CountryValidationRules.ByCountry("US").Get())
                .Returns(OperationFactory.Instance.GetResource<CountryValidationRules>("GetCountryValidationRules-US"));

            // Validations 
            partnerOperations.Setup(p => p.Validations.IsAddressValid(It.IsAny<Address>())).Returns(true);

            return partnerOperations.Object;
        }
    }
}