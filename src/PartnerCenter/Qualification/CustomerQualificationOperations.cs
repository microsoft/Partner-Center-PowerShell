// -----------------------------------------------------------------------
// <copyright file="CustomerQualificationOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Qualification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Customers;
    using Models.ValidationCodes;

    /// <summary>
    /// This class implements the operations available on a customer's qualification.
    /// </summary>
    internal class CustomerQualificationOperations : BasePartnerComponent<string>, ICustomerQualification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerQualificationOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerQualificationOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets the customer qualification.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer qualification.</returns>
        public async Task<CustomerQualification> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<CustomerQualification>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerQualification.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the customer qualification.
        /// </summary>
        /// <param name="entity">The new qualification value.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated customer qualification.</returns>
        public async Task<CustomerQualification> UpdateAsync(CustomerQualification entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PutAsync<CustomerQualification, CustomerQualification>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateCustomerQualification.Path}",
                        Context),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the customer qualification.  Use for GovernmentCommunityCloud with validation code after successful registration through Microsoft.
        /// </summary>
        /// <param name="customerQualification">Customer qualification to be updated.</param>
        /// <param name="governmentCommunityCloudValidationCode">Validation code necessary to complete only Government Community Cloud customer creation. List validation codes with GetValidationCodes in ValidationOperations.</param>
        /// <returns>The updated customer qualification.</returns>
        public async Task<CustomerQualification> UpdateAsync(CustomerQualification customerQualification, ValidationCode governmentCommunityCloudValidationCode, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.UpdateCustomerQualification.Parameters.GovernmentCommunityCloudValidationCode,
                    governmentCommunityCloudValidationCode.ValidationId
                }
            };

            return await Partner.ServiceClient.PutAsync<CustomerQualification, CustomerQualification>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateCustomerQualification.Path}",
                        Context),
                    UriKind.Relative),
                customerQualification,
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}