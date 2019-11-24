// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Profiles.Subscription
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Extension methods for SubscriptionOperationOperations.
    /// </summary>
    public static partial class SubscriptionOperationOperationsExtensions
    {
            /// <summary>
            /// Get the status of the pending Microsoft.Subscription API operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='operationId'>
            /// The operation ID, which can be found from the Location field in the
            /// generate recommendation response header.
            /// </param>
            public static SubscriptionCreationResult Get(this ISubscriptionOperationOperations operations, string operationId)
            {
                return operations.GetAsync(operationId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get the status of the pending Microsoft.Subscription API operations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='operationId'>
            /// The operation ID, which can be found from the Location field in the
            /// generate recommendation response header.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SubscriptionCreationResult> GetAsync(this ISubscriptionOperationOperations operations, string operationId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(operationId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
