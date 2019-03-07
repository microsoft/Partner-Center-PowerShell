// -----------------------------------------------------------------------
// <copyright file="OfferTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Models.Offers;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for operations involving agreements.
    /// </summary>
    [TestClass]
    public class OfferTests : TestBase
    {
        /// <summary>
        /// Test that varifies the get offer categories operation.
        /// </summary>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetOfferCategories()
        {
            await UsePartnerFor(async partnerOperations =>
            {
                ResourceCollection<OfferCategory> offerCategories = await partnerOperations.OfferCategories.ByCountry(TestConstants.UsCountryCode).GetAsync().ConfigureAwait(false);

                Assert.IsNotNull(offerCategories);
                Assert.IsNotNull(offerCategories.Attributes);
                Assert.IsNotNull(offerCategories.Items);
                Assert.IsNotNull(offerCategories.Links);

                Assert.IsNotNull(offerCategories.Items.SingleOrDefault(c => c.Id.Equals(TestConstants.EnterpriseOfferCategoryId, StringComparison.InvariantCultureIgnoreCase)));

                Assert.IsTrue(offerCategories.Items.Any());
                Assert.IsTrue(offerCategories.TotalCount > 0);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Test that varifies the get offers operation.
        /// </summary>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetOffers()
        {
            await UsePartnerFor(async partnerOperations =>
            {
                ResourceCollection<Offer> offers = await partnerOperations.Offers.ByCountry(TestConstants.UsCountryCode).GetAsync().ConfigureAwait(false);

                Assert.IsNotNull(offers);
                Assert.IsNotNull(offers.Attributes);
                Assert.IsNotNull(offers.Items);
                Assert.IsNotNull(offers.Links);

                Assert.IsNotNull(offers.Items.SingleOrDefault(o => o.Id.Equals(TestConstants.Microsoft365E5OfferId, StringComparison.InvariantCultureIgnoreCase)));

                Assert.IsTrue(offers.Items.Any());
                Assert.IsTrue(offers.TotalCount > 0);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Test that varifies the get offer by the identifier operation.
        /// </summary>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetOfferById()
        {
            await UsePartnerFor(async partnerOperations =>
            {
                Offer offer = await partnerOperations.Offers.ByCountry(TestConstants.UsCountryCode).ById(TestConstants.Microsoft365E5OfferId).GetAsync().ConfigureAwait(false);

                Assert.IsNotNull(offer);
                Assert.IsNotNull(offer.Attributes);
                Assert.IsNotNull(offer.Links);

                Assert.IsFalse(string.IsNullOrEmpty(offer.Id));
            }).ConfigureAwait(false);
        }
    }
}