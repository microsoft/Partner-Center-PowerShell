// -----------------------------------------------------------------------
// <copyright file="AuditRecordTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using Factories;
    using Moq;
    using PartnerCenter.Models.RateCards;
    using Profile;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available audit record cmdlets.
    /// </summary>
    [TestClass]
    public class RateCardTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerAzureRateCard cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerAzureRateCardTests()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerAzureRateCard");
        }

        /// <summary>
        /// Unit test for the Get-PartnerAzureRateCard cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerAzureRateCardSharedServiceTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerAzureRateCardSharedServices");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IAggregatePartner> partnerOperations = new Mock<IAggregatePartner>();

            partnerOperations.Setup(p => p.RateCards.Azure.Get(null, null)).Returns(
                OperationFactory.Instance.GetResource<AzureRateCard>("GetAzureRateCard"));

            partnerOperations.Setup(p => p.RateCards.Azure.GetShared(null, null)).Returns(
                OperationFactory.Instance.GetResource<AzureRateCard>("GetAzureRateCardSharedServices"));

            return partnerOperations.Object;
        }
    }
}