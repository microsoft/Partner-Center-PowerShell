// -----------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests
{
    using TestFramework;
    using TestFramework.Network;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test base for all partner service tests.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Delegating handler used to intercept partner service client operations.
        /// </summary>
        private readonly static HttpMockHandler httpMockHandler = new HttpMockHandler(HttpMockHandlerMode.Playback);

        /// <summary>
        /// Gets the operations available to a partner.
        /// </summary>
        public IPartner PartnerOperations { get; private set; }

        /// <summary>
        /// Performs the test initialization operations.
        /// </summary>
        [TestInitialize]
        public void SetupTest()
        {
            PartnerOperations = TestPartnerService.CreatePartnerOperations(
                new TestPartnerCredentials(),
                httpMockHandler);
        }

    }
}