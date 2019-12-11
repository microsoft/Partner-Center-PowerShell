// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Graph;
    using Models.Authentication;
    using Network;

    [Cmdlet(VerbsCommon.Get, "PartnerUserSignInActivity"), OutputType(typeof(SignIn))]
    public class GetPartnerUserSignInActivity : PartnerAsyncCmdlet
    {
        /// <summary>
        /// The error code thrown when attempting to request sign activites at the tenant level from a tenant that does not have Azure AD Premium.
        /// </summary>
        private const string RequestFromNonPremiumTenant = "Authentication_RequestFromNonPremiumTenantOrB2CTenant";

        /// <summary>
        /// Represents the default amount of time used when calculating a random delta in the delay between retries.
        /// </summary>
        private static readonly TimeSpan DefaultClientBackoff = TimeSpan.FromSeconds(10.0);

        /// <summary>
        /// Represents the default maximum amount of time used when calculating the exponential delay between retries.
        /// </summary>
        private static readonly TimeSpan DefaultMaxBackoff = TimeSpan.FromSeconds(30.0);

        /// <summary>
        /// Represents the default minimum amount of time used when calculating the exponential delay between retries.
        /// </summary>
        private static readonly TimeSpan DefaultMinBackoff = TimeSpan.FromSeconds(1.0);

        /// <summary>
        /// The queue of paged Microsoft Graph request operations.
        /// </summary>
        private static readonly Queue<IBaseRequest> PagedRequests = new Queue<IBaseRequest>();

        /// <summary>
        /// Gets or sets the end date portion of the query.
        /// </summary>
        [Parameter(HelpMessage = "The end date of the activity logs.", Mandatory = false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start date portion of the query.
        /// </summary>
        [Parameter(HelpMessage = "The start date of the activity logs.", Mandatory = false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the user.", Mandatory = false)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as GraphServiceClient;
                IAuditLogRootSignInsCollectionPage collection;
                List<QueryOption> queryOptions = null;
                List<SignIn> signIns;
                string filter = string.Empty;

                client.AuthenticationProvider = new GraphAuthenticationProvider();

                if (StartDate != null)
                {
                    filter = AppendValue(filter, $"createdDateTime ge {StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
                }

                if (EndDate != null)
                {
                    filter = AppendValue(filter, $"createdDateTime le {EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
                }

                if (!string.IsNullOrEmpty(UserId))
                {
                    filter = AppendValue(filter, $"userId eq '{UserId}'");
                }

                if (!string.IsNullOrEmpty(filter))
                {
                    queryOptions = new List<QueryOption>
                    {
                        new QueryOption("$filter", $"({filter})")
                    };
                }

                try
                {
                    collection = await client.AuditLogs.SignIns.Request(queryOptions).Top(500).GetAsync(CancellationToken).ConfigureAwait(false);
                    signIns = new List<SignIn>(collection.CurrentPage);

                    while (collection.NextPageRequest != null)
                    {
                        collection = await collection.NextPageRequest.GetAsync(CancellationToken).ConfigureAwait(false);
                        signIns.AddRange(collection.CurrentPage);
                    }
                }
                catch (ServiceException ex)
                {
                    if (!ex.Error.Code.Equals(RequestFromNonPremiumTenant))
                    {
                        throw;
                    }

                    signIns = await GetSignInActivitiesAsync(client).ConfigureAwait(false);
                }

                WriteObject(signIns, true);
            }, true);
        }

        private async Task<List<SignIn>> GetSignInActivitiesAsync(IGraphServiceClient client)
        {
            BatchRequestContent batchRequestContent;
            BatchResponseContent batchResponseContent;
            IGraphServiceUsersCollectionPage userCollection;
            List<SignIn> signIns;
            List<User> users;
            string filter = string.Empty;

            userCollection = await client.Users.Request().Top(500).GetAsync().ConfigureAwait(false);
            users = new List<User>(userCollection.CurrentPage);

            while (userCollection.NextPageRequest != null)
            {
                userCollection = await userCollection.NextPageRequest.GetAsync().ConfigureAwait(false);
                users.AddRange(userCollection.CurrentPage);
            }

            if (StartDate != null)
            {
                filter = AppendValue(filter, $"createdDateTime ge {StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            }

            if (EndDate != null)
            {
                filter = AppendValue(filter, $"createdDateTime le {EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            }

            signIns = new List<SignIn>();

            foreach (IEnumerable<User> batch in Batch(users, 5))
            {
                batchRequestContent = new BatchRequestContent();

                foreach (User user in batch)
                {
                    batchRequestContent.AddBatchRequestStep(client.AuditLogs.SignIns.Request(new List<QueryOption>
                    {
                        new QueryOption("$filter", $"({AppendValue(filter, $"userId eq '{user.Id}'")})")
                    }));
                }

                batchResponseContent = await client.Batch.Request().PostAsync(batchRequestContent, CancellationToken).ConfigureAwait(false);
                await ParseBatchResponseAsync(client, batchRequestContent, batchResponseContent, signIns).ConfigureAwait(false);
            }

            while (PagedRequests.Count != 0)
            {
                await ProcessPagedRequestsAsync(client, signIns).ConfigureAwait(false);
            }

            return signIns;
        }

        private static string AppendValue(string baseValue, string appendValue)
        {
            if (string.IsNullOrEmpty(baseValue))
            {
                return appendValue;
            }

            return $"{baseValue} and {appendValue}";
        }

        private static IEnumerable<IEnumerable<T>> Batch<T>(IEnumerable<T> entities, int batchSize)
        {
            int size = 0;

            while (size < entities.Count())
            {
                yield return entities.Skip(size).Take(batchSize);
                size += batchSize;
            }
        }

        private bool IsTransient(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.RequestTimeout ||
                response.StatusCode == (HttpStatusCode)429 ||
                (response.StatusCode >= HttpStatusCode.InternalServerError &&
                    response.StatusCode != HttpStatusCode.NotImplemented &&
                    response.StatusCode != HttpStatusCode.HttpVersionNotSupported))
            {
                return true;
            }

            return false;
        }

        private async Task ParseBatchResponseAsync(IGraphServiceClient client, BatchRequestContent batchRequestContent, BatchResponseContent batchResponseContent, List<SignIn> signIns, int retryCount = 0)
        {
            AuditLogRootRestrictedSignInsCollectionResponse collection;
            Dictionary<string, HttpResponseMessage> responses;

            client.AssertNotNull(nameof(client));
            batchRequestContent.AssertNotNull(nameof(batchRequestContent));
            batchResponseContent.AssertNotNull(nameof(batchResponseContent));
            signIns.AssertNotNull(nameof(signIns));

            responses = await batchResponseContent.GetResponsesAsync().ConfigureAwait(false);

            foreach (KeyValuePair<string, HttpResponseMessage> item in responses.Where(item => item.Value.IsSuccessStatusCode))
            {
                collection = await batchResponseContent
                    .GetResponseByIdAsync<AuditLogRootRestrictedSignInsCollectionResponse>(item.Key).ConfigureAwait(false);

                collection.AdditionalData.TryGetValue("@odata.nextLink", out object nextPageLink);
                string nextPageLinkString = nextPageLink as string;

                if (!string.IsNullOrEmpty(nextPageLinkString))
                {
                    collection.Value.InitializeNextPageRequest(client, nextPageLinkString);
                }

                if (collection.Value.NextPageRequest != null)
                {
                    PagedRequests.Enqueue(collection.Value.NextPageRequest);
                }

                signIns.AddRange(collection.Value);
            }

            if (PagedRequests.Count >= 5)
            {
                await ProcessPagedRequestsAsync(client, signIns).ConfigureAwait(false);
            }

            await RetryRequestWithTransientFaultAsync(client, batchRequestContent, responses, signIns, ++retryCount).ConfigureAwait(false);
        }

        private async Task ProcessPagedRequestsAsync(IGraphServiceClient client, List<SignIn> signIns)
        {
            BatchRequestContent batchRequestContent;
            BatchResponseContent batchResponseContent;
            int numberOfRequests;

            client.AssertNotNull(nameof(client));
            signIns.AssertNotNull(nameof(signIns));

            if (PagedRequests.Count == 0)
            {
                return;
            }

            batchRequestContent = new BatchRequestContent();

            numberOfRequests = PagedRequests.Count > 5 ? 5 : PagedRequests.Count;

            for (int i = 0; i < numberOfRequests; i++)
            {
                batchRequestContent.AddBatchRequestStep(PagedRequests.Dequeue());
            }

            batchResponseContent = await client.Batch.Request().PostAsync(batchRequestContent, CancellationToken).ConfigureAwait(false);
            await ParseBatchResponseAsync(client, batchRequestContent, batchResponseContent, signIns).ConfigureAwait(false);
        }

        private async Task RetryRequestWithTransientFaultAsync(IGraphServiceClient client, BatchRequestContent batchRequestContent, Dictionary<string, HttpResponseMessage> responses, List<SignIn> signIns, int retryCount)
        {
            BatchRequestContent retryBatchRequestContent = new BatchRequestContent();
            BatchResponseContent batchResponseContent;
            Random random;
            double delta;

            client.AssertNotNull(nameof(client));
            batchRequestContent.AssertNotNull(nameof(batchRequestContent));
            responses.AssertNotNull(nameof(responses));


            if (responses.Any(r => IsTransient(r.Value)))
            {
                if (retryCount <= 3)
                {
                    foreach (KeyValuePair<string, HttpResponseMessage> item in responses.Where(r => IsTransient(r.Value)))
                    {
                        retryBatchRequestContent.AddBatchRequestStep(batchRequestContent.BatchRequestSteps[item.Key]);
                    }

                    random = new Random();
                    delta = (Math.Pow(2.0, retryCount) - 1.0) *
                        random.Next((int)(DefaultClientBackoff.TotalMilliseconds * 0.8), (int)(DefaultClientBackoff.TotalMilliseconds * 1.2));

                    await Task.Delay((int)Math.Min(DefaultMinBackoff.TotalMilliseconds + delta, DefaultMaxBackoff.TotalMilliseconds), CancellationToken).ConfigureAwait(false);

                    batchResponseContent = await client.Batch.Request().PostAsync(retryBatchRequestContent, CancellationToken).ConfigureAwait(false);

                    await ParseBatchResponseAsync(client, retryBatchRequestContent, batchResponseContent, signIns, retryCount).ConfigureAwait(false);
                }
                else
                {
                    ErrorResponse errorResponse;
                    List<ServiceException> exceptions = new List<ServiceException>();
                    ResponseHandler responseHandler = new ResponseHandler(new Serializer());
                    string rawResponseBody;

                    foreach (KeyValuePair<string, HttpResponseMessage> item in responses.Where(item => !item.Value.IsSuccessStatusCode))
                    {
                        rawResponseBody = null;

                        if (item.Value.Content?.Headers.ContentType.MediaType == "application/json")
                        {
                            rawResponseBody = await item.Value.Content.ReadAsStringAsync().ConfigureAwait(false);
                        }

                        errorResponse = await responseHandler.HandleResponse<ErrorResponse>(item.Value).ConfigureAwait(false);
                        exceptions.Add(new ServiceException(errorResponse.Error, item.Value.Headers, item.Value.StatusCode, rawResponseBody));
                    }

                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}