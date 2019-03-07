// -----------------------------------------------------------------------
// <copyright file="CustomerUserRoleCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Roles;

    /// <summary>
    /// Represents the behavior of the customers user's directory roles.
    /// </summary>
    internal class CustomerUserRoleCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ICustomerUserRoleCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUserRoleCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="userId">The user identifier.</param>
        public CustomerUserRoleCollectionOperations(IPartner rootPartnerOperations, string customerId, string userId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, userId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));
        }

        /// <summary>
        /// Gets the customer user's directory roles.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer user's directory roles.</returns>
        public async Task<ResourceCollection<DirectoryRole>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<DirectoryRole>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CustomerUserDirectoryRoles.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<DirectoryRole>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}