// -----------------------------------------------------------------------
// <copyright file="ProductTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using System.Collections.Generic;
    using Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Products;
    using Profile;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the available partner cmdlets.
    /// </summary>
    [TestClass]
    public class ProductTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerProduct cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerProductTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerProduct");
        }

        /// <summary>
        /// Unit test for the Get-PartnerProductAvailability cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerProductAvailabilityTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerProductAvailability");
        }

        /// <summary>
        /// Unit test for the Get-PartnerProductInventory cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerProductInventoryTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerProductInventory");
        }

        /// <summary>
        /// Unit test for the Get-PartnerProductSku cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerProductSkuTest()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerProductSku");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IAggregatePartner> partnerOperations = new Mock<IAggregatePartner>();

            //  Product
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ByTargetView(It.IsAny<string>()).Get())
                .Returns(OperationFactory.Instance.GetResource<ResourceCollection<Product>>("GetProduct"));

            // Product Availability
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).Skus.ById(It.IsAny<string>()).Availabilities.ByTargetSegment(It.IsAny<string>()).Get())
                .Returns(OperationFactory.Instance.GetResource<ResourceCollection<Availability>>("GetProductAvailability"));
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).Skus.ById(It.IsAny<string>()).Availabilities.Get())
                .Returns(OperationFactory.Instance.GetResource<ResourceCollection<Availability>>("GetProductAvailability"));
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).Skus.ById(It.IsAny<string>()).Availabilities.ById(It.IsAny<string>()).Get())
                .Returns(OperationFactory.Instance.GetResource<Availability>("GetProductAvailabilityById"));

            // Product Inventory
            partnerOperations.Setup(p => p.Extensions.Product.ByCountry(It.IsAny<string>()).CheckInventory(It.IsAny<InventoryCheckRequest>())).Returns(
                OperationFactory.Instance.GetResource<IEnumerable<InventoryItem>>("GetProductInventory"));

            // Product SKUs
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).Skus.ById(It.IsAny<string>()).Get())
                .Returns(OperationFactory.Instance.GetResource<Sku>("GetProductSku"));
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).Skus.Get())
                .Returns(OperationFactory.Instance.GetResource<ResourceCollection<Sku>>("GetProductSku"));
            partnerOperations.Setup(p => p.Products.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).Skus.ByTargetSegment(It.IsAny<string>()).Get())
                .Returns(OperationFactory.Instance.GetResource<ResourceCollection<Sku>>("GetProductSku"));


            return partnerOperations.Object;
        }
    }
}