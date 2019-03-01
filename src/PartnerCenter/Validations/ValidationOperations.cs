// -----------------------------------------------------------------------
// <copyright file="ValidationOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.ValidationCodes;

    /// <summary>
    /// Represents the behavior of a validation operations.
    /// </summary>
    internal class ValidationOperations : BasePartnerComponent<string>, IValidations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public ValidationOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets validation code which is used for Government Community Cloud customers qualification.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of validation codes.</returns>
        public async Task<IEnumerable<ValidationCode>> GetValidationCodesAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<IEnumerable<ValidationCode>>(
               new Uri(
                   $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetValidationCodes.Path}",
                   UriKind.Relative),
               cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if the address is valid or not.
        /// </summary>
        /// <param name="address">The address to be validated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the address is valid; otherwise <c>false</c>.</returns>
        public async Task<bool> IsAddressValidAsync(Address address, CancellationToken cancellationToken = default)
        {
            address.AssertNotNull(nameof(address));

            return await Partner.ServiceClient.PostAsync<Address, bool>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.AddressValidation.Path}",
                    UriKind.Relative),
                address,
                cancellationToken).ConfigureAwait(false);
        }
    }
}