// -----------------------------------------------------------------------
// <copyright file="AgreementTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Commands
{
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the commands related to agreements.
    /// </summary>
    [TestClass]
    public class AgreementTests : TestBase
    {
        /// <summary>
        /// Unit test for the Get-PartnerAgreementDetail cmdlet.
        /// </summary>
        [TestMethod]
        public void GetPartnerAgreementDetail()
        {
            RunPowerShellTest("Test-GetPartnerAgreementDetail");
        }
    }
}