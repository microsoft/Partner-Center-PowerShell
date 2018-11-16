// -----------------------------------------------------------------------
// <copyright file="CustomerCompanyProfileOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Customers.Profiles
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models.Customers;

    /// <summary>
    /// Implements the customer company profile operations.
    /// </summary>
    internal class CustomerCompanyProfileOperations : BasePartnerComponent, ICustomerReadonlyProfile<CustomerCompanyProfile>, IPartnerComponent<string>, IEntityGetOperations<CustomerCompanyProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCompanyProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer tenant Id.</param>
        public CustomerCompanyProfileOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
        }

        /// <summary>
        /// Gets the customer's company profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's company profile.</returns>
        public CustomerCompanyProfile Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync());
        }

        /// <summary>
        /// Gets the customer's company profile.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's company profile.</returns>
        public async Task<CustomerCompanyProfile> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<CustomerCompanyProfile>(
                Partner,
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerCompanyProfile.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}