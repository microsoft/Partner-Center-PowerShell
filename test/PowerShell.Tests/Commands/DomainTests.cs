// -----------------------------------------------------------------------
// <copyright file="DomainTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using Moq;
    using Profile;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available audit record cmdlets.
    /// </summary>
    [TestClass]
    public class DomainTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerAuditRecord cmdlet.
        /// </summary>
        [TestMethod]
        public void TestPartnerDomainAvailabilityTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-TestPartnerDomainAvailability");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IAggregatePartner> partnerOperations = new Mock<IAggregatePartner>();

            partnerOperations.Setup(p => p.Domains.ByDomain(It.IsAny<string>()).Exists()).Returns(true);

            return partnerOperations.Object;
        }
    }
}