// -----------------------------------------------------------------------
// <copyright file="DomainOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Domains
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Extensions;

    /// <summary>
    /// The domain operations implementation class.
    /// </summary>
    internal class DomainOperations : BasePartnerComponent<string>, IDomain
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="domain">The domain.</param>
        public DomainOperations(IPartner rootPartnerOperations, string domain)
          : base(rootPartnerOperations, domain)
        {
            domain.AssertNotEmpty(nameof(domain));
        }

        /// <summary>
        /// Checks the availability of a domain.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the domain is available; otherwise <c>false</c>.</returns>
        public bool Exists(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => ExistsAsync(cancellationToken));
        }

        /// <summary>
        /// Checks the availability of a domain.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the domain is available; otherwise <c>false</c>.</returns>
        public async Task<bool> ExistsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                await Partner.ServiceClient.HeadAsync<string>(
                    new Uri(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CheckDomainAvailability.Path}",
                            Context),
                        UriKind.Relative),
                    cancellationToken).ConfigureAwait(false);
            }
            catch (PartnerException ex)
            {
                if (ex.ErrorCategory == PartnerErrorCategory.NotFound)
                {
                    return false;
                }

                throw;
            }

            return true;
        }
    }
}