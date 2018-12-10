// -----------------------------------------------------------------------
// <copyright file="PartnerServiceClient.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Extensions;
    using Models;
    using Models.Authentication;
    using Models.JsonConverters;
    using Newtonsoft.Json;
    using RequestContext;
    using Rest;

    /// <summary>
    /// Acts as mediator betweeen the SDK and the partner service.
    /// </summary>
    public class PartnerServiceClient : ServiceClient<PartnerServiceClient>, IPartnerServiceClient
    {
        /// <summary>
        /// The value for the accept header.
        /// </summary>
        private const string AcceptType = "application/json";

        /// <summary>
        /// The name of the application name header. 
        /// </summary>
        private const string ApplicationNameHeader = "MS-PartnerCenter-Application";

        /// <summary>
        /// The authorization scheme used by the partner service.
        /// </summary>
        private const string AuthorizationScheme = "Bearer";

        /// <summary>
        /// The name of the client header.
        /// </summary>
        private const string ClientHeader = "MS-PartnerCenter-Client";

        /// <summary>
        /// The name of the correlation identifier header.
        /// </summary>
        private const string CorrelationIdHeaderName = "MS-CorrelationId";

        /// <summary>
        /// The name of the locale header.
        /// </summary>
        private const string LocaleHeaderName = "X-Locale";

        /// <summary>
        /// The HTTP patch method type.
        /// </summary>
        private const string PatchMethod = "PATCH";

        /// <summary>
        /// The name of the request identifier header.
        /// </summary>
        private const string RequestIdHeaderName = "MS-RequestId";

        /// <summary>
        /// The name of the SDK version header.
        /// </summary>
        public const string SdkVersionHeader = "MS-SdkVersion";

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerServiceClient" /> class.
        /// </summary>
        /// <param name="endpoint">The address of the resource being accessed.</param>
        public PartnerServiceClient(Uri endpoint)
        {
            Endpoint = endpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerServiceClient" /> class.
        /// </summary>
        /// <param name="endpoint">The address of the resource being accessed.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        public PartnerServiceClient(Uri endpoint, params DelegatingHandler[] handlers)
            : base(handlers)
        {
            Endpoint = endpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerServiceClient" /> class.
        /// </summary>
        /// <param name="endpoint">Address of the resource being accessed.</param>
        /// <param name="httpClient">The HTTP client to be used.</param>
        public PartnerServiceClient(Uri endpoint, HttpClient httpClient)
            : base(httpClient, false)
        {
            Endpoint = endpoint;
        }

        /// <summary>
        /// Gets or sets the address of the resource being accessed.
        /// </summary>
        public Uri Endpoint { get; private set; }

        /// <summary>
        /// Acquires an access token from the authority.
        /// </summary>
        /// <param name="authority"Address of the authority to issue the token.></param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="clientSecret">Secret of the client requesting the token.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of <see cref="AuthenticationResult"/> that represents the access token.</returns>
        public async Task<AuthenticationResult> AcquireTokenAsync(string authority, string resource, string clientId, string clientSecret, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, string> content;
            HttpResponseMessage response = null;
            AuthenticationResponse authResponse;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(authority)))
                {
                    content = new Dictionary<string, string>
                    {
                        ["client_id"] = clientId,
                        ["client_secret"] = clientSecret,
                        ["grant_type"] = "client_credentials",
                        ["resource"] = resource
                    };

                    request.Content = new FormUrlEncodedContent(content);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    authResponse = await HandleAuthenticationResponseAsync(response).ConfigureAwait(false);

                    return new AuthenticationResult(authResponse);
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Acquires an access token from the authority.
        /// </summary>
        /// <param name="authority"Address of the authority to issue the token.></param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
        /// <param name="redirectUri">Address to return to upon receiving a response from the authority.</param>
        /// <param name="code">The authorization code received from service authorization endpoint.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="clientSecret">Secret of the client requesting the token.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of <see cref="AuthenticationResult"/> that represents the access token.</returns>
        public async Task<AuthenticationResult> AcquireTokenByAuthorizationCodeAsync(string authority, string resource, Uri redirectUri, string code, string clientId, string clientSecret = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, string> content;
            HttpResponseMessage response = null;
            AuthenticationResponse authResponse;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(authority)))
                {
                    content = new Dictionary<string, string>
                    {
                        ["client_id"] = clientId,
                        ["code"] = code,
                        ["grant_type"] = "authorization_code",
                        ["redirect_uri"] = redirectUri.OriginalString,
                        ["resource"] = resource
                    };

                    if (!string.IsNullOrEmpty(clientSecret))
                    {
                        content.Add("client_secret", clientSecret);
                    }

                    request.Content = new FormUrlEncodedContent(content);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    authResponse = await HandleAuthenticationResponseAsync(response).ConfigureAwait(false);

                    return new AuthenticationResult(authResponse);
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a HTTP DELETE request against the partner service.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(IPartner rootPartnerOperations, Uri relativeUri, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, new Uri(Endpoint, relativeUri)))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a HTTP GET request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="link">A link object containing the request information.</param>
        /// <param name="converter">A JSON converter used to deserialize the response.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP GET request.</returns>
        public async Task<TResource> GetAsync<TResource>(Link link, JsonConverter converter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            string content;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(Endpoint, $"/{PartnerService.Instance.ApiVersion}/{link.Uri}")))
                {
                    foreach (KeyValuePair<string, string> header in link.Headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


                    return JsonConvert.DeserializeObject<TResource>(content, GetDeserializationSettings(converter));
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a HTTP GET request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP get request.</returns>
        public async Task<TResource> GetAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            string content;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(Endpoint, relativeUri)))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<TResource>(content, GetDeserializationSettings());
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a HTTP GET request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="parameters">Query string parameters that will be added to the address.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP GET request.</returns>
        public async Task<TResource> GetAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, IDictionary<string, string> parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            Uri uri;
            string content;

            try
            {
                uri = new Uri(Endpoint, relativeUri).AddQueryParemeters(parameters);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<TResource>(content, GetDeserializationSettings());
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a file content request against the partner service.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="mediaType">The media type to be accepted.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The file content stream.</returns>
        public async Task<Stream> GetFileContentAsync(IPartner rootPartnerOperations, Uri relativeUri, string mediaType, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            Stream stream;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(Endpoint, relativeUri)))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    if (response.Content == null)
                    {
                        return null;
                    }

                    stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                    return stream;
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a HTTP HEAD request against the partner service.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task<TResource> HeadAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            string responseContent;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, new Uri(Endpoint, relativeUri)))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<TResource>(responseContent, GetDeserializationSettings());
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a PATCH request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="content">The content for the body of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP PATCH request.</returns>
        public async Task<TResource> PatchAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, TResource content, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            string responseContent;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(PatchMethod), new Uri(Endpoint, relativeUri)))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    request.Content = new StringContent(JsonConvert.SerializeObject(content));
                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<TResource>(responseContent, GetDeserializationSettings());
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a POST request against the partner service.
        /// </summary>
        /// <typeparam name="TRequest">Type of resource being sent.</typeparam>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="content">The content for the body of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP POST request.</returns>
        public async Task<TResource> PostAsync<TRequest, TResource>(IPartner rootPartnerOperations, Uri relativeUri, TRequest content, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            string responseContent;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(Endpoint, relativeUri)))
                {

                    AddRequestHeaders(rootPartnerOperations, request);

                    request.Content = new StringContent(JsonConvert.SerializeObject(content));

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<TResource>(responseContent, GetDeserializationSettings());
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Executes a PUT request against the partner service.
        /// </summary>
        /// <typeparam name="TRequest">Type of resource being sent.</typeparam>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="content">The content for the body of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP PUT request.</returns>
        public async Task<TResource> PutAsync<TRequest, TResource>(IPartner rootPartnerOperations, Uri relativeUri, TRequest content, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = null;
            string responseContent;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, new Uri(Endpoint, relativeUri)))
                {
                    AddRequestHeaders(rootPartnerOperations, request);

                    request.Content = new StringContent(JsonConvert.SerializeObject(content));

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<TResource>(responseContent, GetDeserializationSettings());
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Refreshes the access token using a refresh token.
        /// </summary>
        /// <param name="authority">Address of the authority to issue the token.></param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
        /// <param name="refreshToken">The refresh token to be used to obtain a new access token.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="clientSecret">Secret of the client requesting the token.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of <see cref="AuthenticationResult"/> that represents the access token.</returns>
        public async Task<AuthenticationResult> RefreshAccessTokenAsync(string authority, string resource, string refreshToken, string clientId, string clientSecret = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, string> content;
            HttpResponseMessage response = null;
            AuthenticationResponse authResponse;

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(authority)))
                {
                    content = new Dictionary<string, string>
                    {
                        ["client_id"] = clientId,
                        ["grant_type"] = "refresh_token",
                        ["refresh_token"] = refreshToken,
                        ["resource"] = resource
                    };

                    if (!string.IsNullOrEmpty(clientSecret))
                    {
                        content.Add("client_secret", clientSecret);
                    }

                    request.Content = new FormUrlEncodedContent(content);

                    response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    authResponse = await HandleAuthenticationResponseAsync(response).ConfigureAwait(false);

                    return new AuthenticationResult(authResponse);
                }
            }
            finally
            {
                response?.Dispose();
            }
        }

        /// <summary>
        /// Adds the headers to the request.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="request">The HTTP request being made.</param>
        private static void AddRequestHeaders(IPartner rootPartnerOperations, HttpRequestMessage request)
        {
            IRequestContext context;

            if (rootPartnerOperations.RequestContext.RequestId == default(Guid))
            {
                context = RequestContextFactory.Create(
                    rootPartnerOperations.RequestContext.CorrelationId,
                    Guid.NewGuid(),
                    rootPartnerOperations.RequestContext.Locale);
            }
            else
            {
                context = rootPartnerOperations.RequestContext;
            }

            if (!string.IsNullOrEmpty(PartnerService.Instance.ApplicationName))
            {
                request.Headers.Add(ApplicationNameHeader, PartnerService.Instance.ApplicationName);
            }

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptType));

            request.Headers.Add(ClientHeader, PartnerService.Instance.Configuration.PartnerCenterClient);
            request.Headers.Add(CorrelationIdHeaderName, context.CorrelationId.ToString());
            request.Headers.Add(LocaleHeaderName, context.Locale);
            request.Headers.Add(RequestIdHeaderName, context.RequestId.ToString());
            request.Headers.Add(SdkVersionHeader, PartnerService.Instance.AssemblyVersion);

            if (rootPartnerOperations.Credentials.IsExpired())
            {
                throw new PartnerException(
                    "The credential refresh mechanism provided expired credentials.",
                    rootPartnerOperations.RequestContext,
                    PartnerErrorCategory.Unauthorized);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue(
                AuthorizationScheme,
                rootPartnerOperations.Credentials.PartnerServiceToken);
        }

        private JsonSerializerSettings GetDeserializationSettings(JsonConverter converter = null)
        {
            return new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    {
                        converter ?? new EnumJsonConverter()
                    }
                },
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
        }

        private async Task<AuthenticationResponse> HandleAuthenticationResponseAsync(HttpResponseMessage response)
        {
            AuthenticationResponse entity;
            string content;

            content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            entity = JsonConvert.DeserializeObject<AuthenticationResponse>(content, GetDeserializationSettings(null));

            if (response.IsSuccessStatusCode)
            {
                return entity;
            }

            throw new AuthenticationException(entity.Error, entity.ErrorDescription);
        }
    }
}