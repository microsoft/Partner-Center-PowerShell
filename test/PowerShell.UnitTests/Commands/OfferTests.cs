// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Commands
{
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the commands related to offers.
    /// </summary>
    [TestClass]
    public class OfferTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerOffer cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerOffer()
        {
            RunPowerShellTest("Test-GetPartnerOffer");
        }

        /// <summary>
        /// Unit test for the Get-PartnerOffer cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerOfferWithAddOnFlag()
        {
            RunPowerShellTest("Test-GetPartnerOfferWithAddOnFlag");
        }

        /// <summary>
        /// Unit test for the Get-PartnerOffer cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerOfferWithOfferId()
        {
            RunPowerShellTest("Test-GetPartnerOfferWithOfferId");
        }

        /// <summary>
        /// Unit test for the Get-PartnerOfferCategory cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerOfferCategory()
        {
            RunPowerShellTest("Test-GetPartnerOfferCategory");
        }
    }
}