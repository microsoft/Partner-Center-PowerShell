// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Commands
{
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the Get-PartnerOfferCategory cmdlet.
    /// </summary>
    [TestClass]
    public class GetPartnerOfferCategoryTests : TestBase
    {
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