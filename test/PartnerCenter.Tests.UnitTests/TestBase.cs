// -----------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using TestFramework;
    using TestFramework.Network;

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
        /// Use the partner operations to perform the test.
        /// </summary>
        /// <param name="test">Encapsulates a test to execute.</param>
        /// <param name="identity">Identity of the test being executed.</param>
        /// <returns>
        /// An instance of the <see cref="Task" /> class that represents the asynchronous operation.
        /// </returns>
        public async Task UsePartnerFor(Func<IPartner, Task> test, [CallerMemberName] string identity = null)
        {
            IPartnerCredentials credentials = new TestPartnerCredentials();

            await test(TestPartnerService.CreatePartnerOperations(credentials, httpMockHandler));

            if (httpMockHandler.Mode == HttpMockHandlerMode.Record)
            {
                httpMockHandler.Flush(identity);
            }
        }
    }
}