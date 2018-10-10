// -----------------------------------------------------------------------
// <copyright file="InvoiceTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using Enumerators;
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;
    using Profile;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InvoiceTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerInvoice cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerInvoice()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerInvoice");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IAggregatePartner> partnerOperations = new Mock<IAggregatePartner>();

            // Enumerator Operations
            partnerOperations.Setup(p => p.Enumerators.Invoices.Create(It.IsAny<ResourceCollection<Invoice>>()))
                .Returns(
                    new ResourceCollectionEnumerator<ResourceCollection<Invoice>>(
                        OperationFactory.Instance.GetResource<ResourceCollection<Invoice>>("GetInvoice")));

            // Invoice Operations
            partnerOperations.Setup(p => p.Invoices.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<Invoice>>("GetInvoice"));
            partnerOperations.Setup(p => p.Invoices[It.IsAny<string>()].Get()).Returns(
                OperationFactory.Instance.GetResource<Invoice>("GetInvoiceById"));

            return partnerOperations.Object;
        }
    }
}