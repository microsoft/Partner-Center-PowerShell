// -----------------------------------------------------------------------
// <copyright file="CustomerUserLicenseUpdateOperations.cs" company="Microsoft">
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
    using Models.Licenses;

    /// <summary>
    /// Customer user license update collection operations class.
    /// </summary>
    internal class CustomerUserLicenseUpdateOperations : BasePartnerComponent<Tuple<string, string>>, ICustomerUserLicenseUpdates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUserLicenseUpdateOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="userId">The user identifier or UPN depending upon the method which is consuming it.</param>
        public CustomerUserLicenseUpdateOperations(IPartner rootPartnerOperations, string customerId, string userId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, userId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));
        }

        /// <summary>
        /// Assign licenses to a user.
        /// This method serves three scenarios:
        /// 1. Add license to a customer user.
        /// 2. Remove license from a customer user.
        /// 3. Update existing license for a customer user.
        /// </summary>
        /// <param name="entity">License update object.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An object that represents the license update.</returns>
        public async Task<LicenseUpdate> CreateAsync(LicenseUpdate newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<LicenseUpdate, LicenseUpdate>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture, 
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.SetCustomerUserLicenseUpdates.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}