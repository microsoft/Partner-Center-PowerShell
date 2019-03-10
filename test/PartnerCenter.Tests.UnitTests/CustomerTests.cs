// -----------------------------------------------------------------------
// <copyright file="CustomerTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests.UnitTests
{
    using System.Threading.Tasks;
    using Models.Customers;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for operations involving customers.
    /// </summary>
    [TestClass]
    public class CustomerTests : TestBase
    {
        /// <summary>
        /// Test that varifies the get customer qualification operation.
        /// </summary>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetCustomerQualification()
        {
            await UsePartnerFor(async partnerOperations =>
            {
                CustomerQualification qualification = await partnerOperations.Customers[""].Qualification.GetAsync().ConfigureAwait(false);

                Assert.AreEqual(CustomerQualification.None, qualification);
            }).ConfigureAwait(false);
        }
    }
}