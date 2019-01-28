// -----------------------------------------------------------------------
// <copyright file="IValidations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Validations
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.ValidationCodes;

    /// <summary>
    /// Represents the behavior of a validation operations.
    /// </summary>
    public interface IValidations : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets validation code which is used for Government Community Cloud customers qualification.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of validation codes.</returns>
        IEnumerable<ValidationCode> GetValidationCodes(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets validation code which is used for Government Community Cloud customers qualification.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of validation codes.</returns>
        Task<IEnumerable<ValidationCode>> GetValidationCodesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks if the address is valid or not.
        /// </summary>
        /// <param name="address">The address to be validated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the address is valid; otherwise <c>false</c>.</returns>
        bool IsAddressValid(Address address, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks if the address is valid or not.
        /// </summary>
        /// <param name="address">The address to be validated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the address is valid; otherwise <c>false</c>.</returns>
        Task<bool> IsAddressValidAsync(Address address, CancellationToken cancellationToken = default(CancellationToken));
    }
}