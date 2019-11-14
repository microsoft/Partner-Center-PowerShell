// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Billing
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for EnrollmentAccountsOperations.
    /// </summary>
    public static partial class EnrollmentAccountsOperationsExtensions
    {
            /// <summary>
            /// Lists all Enrollment Accounts for a user which he has access to.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='expand'>
            /// May be used to expand the department.
            /// </param>
            /// <param name='filter'>
            /// The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'. It does not
            /// currently support 'ne', 'or', or 'not'. Tag filter is a key value pair
            /// string where key and value is separated by a colon (:).
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EnrollmentAccountListResult> ListByBillingAccountNameAsync(this IEnrollmentAccountsOperations operations, string billingAccountName, string expand = default(string), string filter = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByBillingAccountNameWithHttpMessagesAsync(billingAccountName, expand, filter, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get the enrollment account by id.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='enrollmentAccountName'>
            /// Enrollment Account Id.
            /// </param>
            /// <param name='expand'>
            /// May be used to expand the Department.
            /// </param>
            /// <param name='filter'>
            /// The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'. It does not
            /// currently support 'ne', 'or', or 'not'. Tag filter is a key value pair
            /// string where key and value is separated by a colon (:).
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EnrollmentAccount> GetByEnrollmentAccountIdAsync(this IEnrollmentAccountsOperations operations, string billingAccountName, string enrollmentAccountName, string expand = default(string), string filter = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByEnrollmentAccountIdWithHttpMessagesAsync(billingAccountName, enrollmentAccountName, expand, filter, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
