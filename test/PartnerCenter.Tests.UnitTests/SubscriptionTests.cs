// -----------------------------------------------------------------------
// <copyright file="SubscriptionTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests.UnitTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Models.Subscriptions;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for operations involving subscriptions.
    /// </summary>
    [TestClass]
    public class SubscriptionTests : TestBase
    {
        /// <summary>
        /// Test that verifies the get subscription add on operation.
        /// </summary>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetSubscriptionAddOns()
        {
            await UsePartnerForAsync(async partnerOperations =>
            {
                ResourceCollection<Subscription> addons = await partnerOperations.Customers[TestConstants.CustomerId].Subscriptions[TestConstants.SubscriptionId].AddOns.GetAsync().ConfigureAwait(false);

                Assert.IsNotNull(addons);
                Assert.IsNotNull(addons.Attributes);
                Assert.IsNotNull(addons.Items);
                Assert.IsNotNull(addons.Links);

                Assert.IsTrue(addons.Items.Any());
                Assert.IsTrue(addons.TotalCount > 0);
            }).ConfigureAwait(false);
        }
    }
}