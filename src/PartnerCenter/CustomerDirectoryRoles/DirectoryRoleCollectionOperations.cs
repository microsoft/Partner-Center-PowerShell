// -----------------------------------------------------------------------
// <copyright file="DirectoryRoleCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Roles;

    /// <summary>
    /// Directory role collection operations class.
    /// </summary>
    internal class DirectoryRoleCollectionOperations : BasePartnerComponent<string>, IDirectoryRoleCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryRoleCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public DirectoryRoleCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a directory role operations object.
        /// </summary>
        /// <param name="id">The directory role identifier.</param>
        /// <returns>The directory role operations object.</returns>
        public IDirectoryRole this[string id] => ById(id);

        /// <summary>
        /// Gets a directory role operations object.
        /// </summary>
        /// <param name="id">The directory role identifier.</param>
        /// <returns>The directory role operations object.</returns>
        public IDirectoryRole ById(string id)
        {
            return new DirectoryRoleOperations(Partner, Context, id);
        }

        /// <summary>
        /// Retrieves all customer directory roles.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer directory roles.</returns>
        public ResourceCollection<DirectoryRole> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all customer directory roles.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer directory roles.</returns>
        public async Task<ResourceCollection<DirectoryRole>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<DirectoryRole>>(
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerDirectoryRoles.Path}",
                    UriKind.Relative),
                new ResourceCollectionConverter<DirectoryRole>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}