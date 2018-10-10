// -----------------------------------------------------------------------
// <copyright file="OfferTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using System.Collections.Generic;
    using Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories;
    using Moq;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Offers;
    using Profile;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the offer resource cmdlets.
    /// </summary>
    [TestClass]
    public class OfferTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerOffer cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerOfferTests()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerOffer");
        }

        /// <summary>
        /// Unit test for the Get-PartnerOfferAddon cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerOfferAddonTests()
        {
            RunPowerShellTest(CreatePartnerOperations, "Test-GetPartnerOfferAddon");
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        private static IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            Mock<IAggregatePartner> partnerOperations = new Mock<IAggregatePartner>();

            partnerOperations.Setup(p => p.Offers.ByCountry("US").ById("031C9E47-4802-4248-838E-778FB1D2CC05").Get()).Returns(GetOffer());
            partnerOperations.Setup(p => p.Offers.ByCountry("US").Get()).Returns(GetOffers());

            partnerOperations.Setup(p => p.Offers.ByCountry(It.IsAny<string>()).ById(It.IsAny<string>()).AddOns.Get()).Returns(
                OperationFactory.Instance.GetResource<ResourceCollection<Offer>>("GetOfferAddon"));

            return partnerOperations.Object;
        }

        /// <summary>
        /// Gets a list of offers used for unit testing.
        /// </summary>
        /// <returns>A resource collection of offers used for unit testing.</returns>
        private static ResourceCollection<Offer> GetOffers()
        {
            List<Offer> offers = new List<Offer>
            {
                {
                    new Offer
                    {
                        Description = "Microsoft 365 Enterprise is a complete, intelligent solution, including Office 365, Windows 10 Enterprise, and Enterprise Mobility + Security, that empowers everyone to be creative and work together, securely.",
                        Id = "2b3b8d2d-10aa-4be4-b5fd-7f2feb0c3091",
                        IsAddOn = false,
                        IsTrial = false,
                        Name = "Microsoft 365 E3"
                    }
                },
                {
                    new Offer
                    {
                        Description = "The Office suite for PC and Mac with apps for tablets and phones, plus email, instant messaging, HD video conferencing, 1 TB personal file storage and sharing. For organizations with up to 300 users.",
                        Id = "031C9E47-4802-4248-838E-778FB1D2CC05",
                        IsAddOn = false,
                        IsTrial = false,
                        Name = "Office 365 Business Premium"
                    }
                },
                {
                    new Offer
                    {
                        Description = "An integrated product for SMBs to access productivity tools, manage their productivity platform, and protect data across devices. For organizations with up to 300 users.",
                        Id = "0FA9D6B6-5923-4B5D-B16E-B7EF0A69E1B7",
                        IsAddOn = false,
                        IsTrial = true,
                        Name = "Microsoft 365 Business Trial"
                    }
                },
                {
                    new Offer
                    {
                        Description = "Provides rich insights on advanced threats, supports proactive defense against them, and integrates seamlessly with other Office 365 security features.",
                        Id = "EFE1183A-8FA0-4138-BF0A-5AE271AB6E3C",
                        IsAddOn = true,
                        IsTrial = false,
                        Name = "Office 365 Threat Intelligence"
                    }
                }
            };

            return new ResourceCollection<Offer>(offers);
        }

        /// <summary>
        /// Gets an offer for unit testing. 
        /// </summary>
        /// <returns>An offer to be used for unit testing.</returns>
        private static Offer GetOffer()
        {
            return new Offer
            {
                Description = "The Office suite for PC and Mac with apps for tablets and phones, plus email, instant messaging, HD video conferencing, 1 TB personal file storage and sharing. For organizations with up to 300 users.",
                Id = "031C9E47-4802-4248-838E-778FB1D2CC05",
                Name = "Office 365 Business Premium"

            };
        }
    }
}