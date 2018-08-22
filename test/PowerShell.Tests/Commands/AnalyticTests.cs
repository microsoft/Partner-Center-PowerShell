// -----------------------------------------------------------------------
// <copyright file="AuditRecordTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using Microsoft.Store.PartnerCenter.Models;
    using Microsoft.Store.PartnerCenter.Models.Analytics;
    using Microsoft.Store.PartnerCenter.PowerShell.Authentication;
    using Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories;
    using Moq;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnalyticTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerLicenseDeploymentInformation cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerLicenseDeploymentInformationTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerLicenseDeploymentInfo");
        }

        /// <summary>
        /// Unit test for the Get-GetPartnerLicenseUsageInformation cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerLicenseUsageInformationTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerLicenseUsageInfo");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IPartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            partnerOperations.Setup(p => p.Analytics.Licenses.Deployment.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<PartnerLicensesDeploymentInsights>>("GetPartnerLicenseDeploymentInsights"));

            partnerOperations.Setup(p => p.Analytics.Licenses.Usage.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<PartnerLicensesUsageInsights>>("GetPartnerLicensesUsageInsights"));

            return partnerOperations.Object;
        }
    }
}