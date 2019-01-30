// -----------------------------------------------------------------------
// <copyright file="CustomerUserLicenseCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Licenses;

    /// <summary>
    /// Customer user license collection operations class.
    /// </summary>
    internal class CustomerUserLicenseCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ICustomerUserLicenseCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUserLicenseCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="userId">The user identifier or UPN depending upon the method which is consuming it.</param>
        public CustomerUserLicenseCollectionOperations(IPartner rootPartnerOperations, string customerId, string userId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, userId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));
        }

        /// <summary>
        /// Gets the customer user licenses.
        /// </summary>
        /// <param name="licenseGroupIds">A collection of license group identifiers.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer user licenses.</returns>
        public ResourceCollection<License> Get(List<LicenseGroupId> licenseGroupIds = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(licenseGroupIds, cancellationToken));
        }

        /// <summary>
        /// Gets the customer user licenses.
        /// </summary>
        /// <param name="licenseGroupIds">A collection of license group identifiers.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer user licenses.</returns>
        public async Task<ResourceCollection<License>> GetAsync(List<LicenseGroupId> licenseGroupIds = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (licenseGroupIds != null)
            {
                foreach (LicenseGroupId licenseGroupId in licenseGroupIds)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerUserAssignedLicenses.Parameters.LicenseGroupIds,
                        licenseGroupId.ToString());
                }
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<License>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerUserAssignedLicenses.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<License>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
