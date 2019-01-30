// -----------------------------------------------------------------------
// <copyright file="CustomerUserOperations.cs" company="Microsoft">
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
    using Models.Users;

    /// <summary>
    /// Customer user operations class.
    /// </summary>
    internal class CustomerUserOperations : BasePartnerComponent<Tuple<string, string>>, ICustomerUser
    {
        /// <summary>
        /// Provides access to to the customer user directory role collection operations.
        /// </summary>
        private readonly Lazy<ICustomerUserRoleCollection> customerUserDirectoryRoles;

        /// <summary>
        /// Provides access to to the customer user license collection operations.
        /// </summary>
        private readonly Lazy<ICustomerUserLicenseCollection> customerUserLicenses;

        /// <summary>
        /// Provides access to to the customer user license update operations.
        /// </summary>
        private readonly Lazy<ICustomerUserLicenseUpdates> customerUserLicenseUpdates;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUserOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="userId">The user identifier.</param>
        public CustomerUserOperations(IPartner rootPartnerOperations, string customerId, string userId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, userId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));

            customerUserDirectoryRoles = new Lazy<ICustomerUserRoleCollection>(() => new CustomerUserRoleCollectionOperations(rootPartnerOperations, customerId, userId));
            customerUserLicenses = new Lazy<ICustomerUserLicenseCollection>(() => new CustomerUserLicenseCollectionOperations(rootPartnerOperations, customerId, userId));
            customerUserLicenseUpdates = new Lazy<ICustomerUserLicenseUpdates>(() => new CustomerUserLicenseUpdateOperations(rootPartnerOperations, customerId, userId));
        }

        /// <summary>
        /// Gets the current user's directory role collection operations.
        /// </summary>
        public ICustomerUserRoleCollection DirectoryRoles => customerUserDirectoryRoles.Value;

        /// <summary>
        /// Gets the current user's licenses collection operations.
        /// </summary>
        public ICustomerUserLicenseCollection Licenses => customerUserLicenses.Value;

        /// <summary>
        /// Gets the current user's license updates operations.
        /// </summary>
        public ICustomerUserLicenseUpdates LicenseUpdates => customerUserLicenseUpdates.Value;

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public void Delete(CancellationToken cancellationToken = default(CancellationToken))
        {
            PartnerService.SynchronousExecute(() => DeleteAsync(cancellationToken));
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Partner.ServiceClient.DeleteAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.DeleteCustomerUser.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the customer user.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer user.</returns>
        public CustomerUser Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the customer user.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer user.</returns>
        public async Task<CustomerUser> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<CustomerUser>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerUserDetails.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the customer user.
        /// </summary>
        /// <param name="entity">Customer user entity.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated user.</returns>
        public CustomerUser Patch(CustomerUser entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => PatchAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Updates the customer user.
        /// </summary>
        /// <param name="entity">Customer user entity.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated user.</returns>
        public async Task<CustomerUser> PatchAsync(CustomerUser entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<CustomerUser, CustomerUser>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateCustomerUser.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}