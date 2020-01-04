// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Validations
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IValidator<in T>
    {
        /// <summary>
        /// Determines if the resource is valid.
        /// </summary>
        /// <param name="resource">The resource to be validate.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the resource is valid; otherwise <c>false</c>.</returns>
        Task<bool> IsValidAsync(T resource, CancellationToken cancellationToken = default);
    }
}