// -----------------------------------------------------------------------
// <copyright file="AuditRecordTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using System;
    using System.Management.Automation;
    using Authentication;
    using Enumerators;
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Auditing;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available audit record cmdlets.
    /// </summary>
    [TestClass]
    public class AuditRecordTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerAuditRecord cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerAuditRecordTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerAuditRecord");
        }

        /// <summary>
        /// Unit test for the Get-PartnerAuditRecord cmdlet.
        /// </summary>
        [ExpectedException(typeof(CmdletInvocationException))]
        [TestMethod]
        public void GetPartnerAuditRecordInvalidDateTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerAuditRecordInvalidDateTest");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IPartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IPartner> partnerOperations = new Mock<IPartner>();

            partnerOperations.Setup(p => p.AuditRecords.Query(It.IsAny<DateTime>(), null, null)).Returns(
                OperationFactory.Instance.GetResource<SeekBasedResourceCollection<AuditRecord>>("GetAuditRecord"));

            // Enumerator Operations
            partnerOperations.Setup(p => p.Enumerators.AuditRecords.Create(It.IsAny<SeekBasedResourceCollection<AuditRecord>>()))
                .Returns(
                    new ResourceCollectionEnumerator<SeekBasedResourceCollection<AuditRecord>>(
                        OperationFactory.Instance.GetResource<SeekBasedResourceCollection<AuditRecord>>("GetAuditRecord")));

            return partnerOperations.Object;
        }
    }
}