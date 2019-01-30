// -----------------------------------------------------------------------
// <copyright file="AgreementTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Models.Agreements;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for operations involving agreements.
    /// </summary>
    [TestClass]
    public class AgreementTests : TestBase
    {
        /// <summary>
        /// Test that varifies the get agreement details operation.
        /// </summary>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetAgreementDetails()
        {
            ResourceCollection<AgreementMetaData> details = await PartnerOperations.AgreementDetails.GetAsync().ConfigureAwait(false);

            Assert.IsNotNull(details);
            Assert.IsNotNull(details.Items);
            Assert.IsTrue(details.Items.Any());
        }
    }
}