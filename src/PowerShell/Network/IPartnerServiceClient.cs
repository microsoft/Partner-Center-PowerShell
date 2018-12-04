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
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the mediator between the SDK and partner service.
    /// </summary>
    public interface IPartnerServiceClient
    {
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

    }
}