// -----------------------------------------------------------------------
// <copyright file="IndirectTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using Authentication;
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Relationships;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndirectTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerInvoice cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerIndirectReseller()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerIndirectReseller");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IPartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            partnerOperations.Setup(p => p.Relationships.Get(PartnerRelationshipType.IsIndirectCloudSolutionProviderOf)).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<PartnerRelationship>>("GetIndirectResellers"));

            return partnerOperations.Object;
        }
    }
}