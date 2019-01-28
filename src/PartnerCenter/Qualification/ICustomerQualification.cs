// -----------------------------------------------------------------------
// <copyright file="ICustomerQualification.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Qualification
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models.Customers;
    using Models.ValidationCodes;

    /// <summary>
    /// Defines the operations available on a customer's qualification.
    /// </summary>
    public interface ICustomerQualification : IPartnerComponent<string>, IEntityGetOperations<CustomerQualification>, IEntityUpdateOperations<CustomerQualification, CustomerQualification>
    {
        /// <summary>
        /// Updates the customer qualification.  Use for GovernmentCommunityCloud with validation code after successful registration through Microsoft.
        /// </summary>
        /// <param name="customerQualification">Customer qualification to be updated.</param>
        /// <param name="governmentCommunityCloudValidationCode">Validation code necessary to complete only Government Community Cloud customer creation.  List validation codes with GetValidationCodes in ValidationOperations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated customer qualification.</returns>
        CustomerQualification Update(CustomerQualification customerQualification, ValidationCode governmentCommunityCloudValidationCode, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the customer qualification.  Use for GovernmentCommunityCloud with validation code after successful registration through Microsoft.
        /// </summary>
        /// <param name="customerQualification">Customer qualification to be updated.</param>
        /// <param name="governmentCommunityCloudValidationCode">Validation code necessary to complete only Government Community Cloud customer creation.  List validation codes with GetValidationCodes in ValidationOperations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated customer qualification.</returns>
        Task<CustomerQualification> UpdateAsync(CustomerQualification customerQualification, ValidationCode governmentCommunityCloudValidationCode, CancellationToken cancellationToken = default(CancellationToken));
    }
}