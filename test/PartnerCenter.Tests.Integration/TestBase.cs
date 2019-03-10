// -----------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Tests.Integration
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models.Authentication;
    using Network;

    /// <summary>
    /// Test base for all partner service tests.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// The client used to perform the HTTP operations.
        /// </summary>
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// The authentication token used when accessing the partner service.
        /// </summary>
        private static readonly AuthenticationToken token;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase" /> class.
        /// </summary>
        static TestBase()
        {
            AuthenticationResult authResult;
            IPartnerServiceClient client = new PartnerServiceClient(httpClient);

            authResult = client.RefreshAccessTokenAsync(
                new Uri(Environment.GetEnvironmentVariable("Authority")),
                Environment.GetEnvironmentVariable("PartnerCenterEndpoint"),
                Environment.GetEnvironmentVariable("RefreshToken"),
                Environment.GetEnvironmentVariable("AppId"),
                Environment.GetEnvironmentVariable("AppSecret")).GetAwaiter().GetResult();

            token = new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }

        /// <summary>
        /// Use the partner operations to perform the test.
        /// </summary>
        /// <param name="test">Encapsulates a test to execute.</param>
        /// <returns>
        /// An instance of the <see cref="Task" /> class that represents the asynchronous operation.
        /// </returns>
        public async Task UsePartnerForAsync(Func<IPartner, Task> test)
        {
            IPartnerCredentials credentials = new TestPartnerCredentials(token);

            await test(PartnerService.Instance.CreatePartnerOperations(credentials, httpClient));
        }
    }
}