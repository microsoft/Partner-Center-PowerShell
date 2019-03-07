// -----------------------------------------------------------------------
// <copyright file="UserMemberOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;

    /// <summary>
    /// User member operations operations class.
    /// </summary>
    internal class UserMemberOperations : BasePartnerComponent<Tuple<string, string, string>>, IUserMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMemberOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="roleId">The directory role identifier.</param>
        /// <param name="userId">The user identifier.</param>
        public UserMemberOperations(IPartner rootPartnerOperations, string customerId, string roleId, string userId)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, roleId, userId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            roleId.AssertNotEmpty(nameof(roleId));
            userId.AssertNotEmpty(nameof(userId));
        }

        /// <summary>
        /// Remove directory user member from directory role.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            await Partner.ServiceClient.DeleteAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.RemoveCustomerUserMemberFromDirectoryRole.Path}",
                        Context.Item1,
                        Context.Item2,
                        Context.Item3),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}