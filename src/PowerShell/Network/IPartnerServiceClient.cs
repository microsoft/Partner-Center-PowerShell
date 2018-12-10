// -----------------------------------------------------------------------
// <copyright file="IPartnerServiceClient.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Authentication;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the mediator between the SDK and partner service.
    /// </summary>
    public interface IPartnerServiceClient
    {
        /// <summary>
        /// Acquires an access token from the authority.
        /// </summary>
        /// <param name="authority">Address of the authority to issue the token.></param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="clientSecret">Secret of the client requesting the token.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of <see cref="AuthenticationResult"/> that represents the access token.</returns>
        Task<AuthenticationResult> AcquireTokenAsync(string authority, string resource, string clientId, string clientSecret, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Acquires an access token from the authority.
        /// </summary>
        /// <param name="authority">Address of the authority to issue the token.></param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
        /// <param name="redirectUri">Address to return to upon receiving a response from the authority.</param>
        /// <param name="code">The authorization code received from service authorization endpoint.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="clientSecret">Secret of the client requesting the token.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of <see cref="AuthenticationResult"/> that represents the access token.</returns>
        Task<AuthenticationResult> AcquireTokenByAuthorizationCodeAsync(string authority, string resource, Uri redirectUri, string code, string clientId, string clientSecret = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a HTTP DELETE request against the partner service.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(IPartner rootPartnerOperations, Uri relativeUri, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a HTTP GET request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="link">A link object containing the request information.</param>
        /// <param name="converter">A JSON converter used to deserialize the response.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP GET request.</returns>
        Task<TResource> GetAsync<TResource>(Link link, JsonConverter converter = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a HTTP GET request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP get request.</returns>
        Task<TResource> GetAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a HTTP GET request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="parameters">Query string parameters that will be added to the address.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP GET request.</returns>
        Task<TResource> GetAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, IDictionary<string, string> parameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a file content request against the partner service.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="mediaType">The media type to be accepted.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The file content stream.</returns>
        Task<Stream> GetFileContentAsync(IPartner rootPartnerOperations, Uri relativeUri, string mediaType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a HTTP HEAD request against the partner service.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        Task<TResource> HeadAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a PATCH request against the partner service.
        /// </summary>
        /// <typeparam name="TResource">Type of resource to be returned.</typeparam>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="relativeUri">Relative address of the request.</param>
        /// <param name="content">The content for the body of the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP PATCH request.</returns>
        Task<TResource> PatchAsync<TResource>(IPartner rootPartnerOperations, Uri relativeUri, TResource content, CancellationToken cancellationToken = default(CancellationToken));

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
        Task<TResource> PostAsync<TRequest, TResource>(IPartner rootPartnerOperations, Uri relativeUri, TRequest content, CancellationToken cancellationToken = default(CancellationToken));

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
        Task<TResource> PutAsync<TRequest, TResource>(IPartner rootPartnerOperations, Uri relativeUri, TRequest content, CancellationToken cancellationToken = default(CancellationToken));

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
        Task<AuthenticationResult> RefreshAccessTokenAsync(string authority, string resource, string refreshToken, string clientId, string clientSecret = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}