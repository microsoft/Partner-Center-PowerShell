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
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// BillingSubscriptionsOperations operations.
    /// </summary>
    public partial interface IBillingSubscriptionsOperations
    {
        /// <summary>
        /// Lists billing subscription by customer id.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/consumption/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='customerName'>
        /// Customer name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByCustomerWithHttpMessagesAsync(string billingAccountName, string customerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a single billing subscription by id.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/consumption/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='customerName'>
        /// Customer name.
        /// </param>
        /// <param name='billingSubscriptionName'>
        /// Billing Subscription Id.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscription>> GetByCustomerWithHttpMessagesAsync(string billingAccountName, string customerName, string billingSubscriptionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists billing subscriptions by billing account name.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByBillingAccountWithHttpMessagesAsync(string billingAccountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists billing subscriptions by billing profile name.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='billingProfileName'>
        /// Billing Profile Id.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscriptionsListResult>> ListByBillingProfileWithHttpMessagesAsync(string billingAccountName, string billingProfileName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists billing subscription by invoice section name.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='billingProfileName'>
        /// Billing Profile Id.
        /// </param>
        /// <param name='invoiceSectionName'>
        /// InvoiceSection Id.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscriptionsListResult>> ListByInvoiceSectionWithHttpMessagesAsync(string billingAccountName, string billingProfileName, string invoiceSectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a single billing subscription by name.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='billingProfileName'>
        /// Billing Profile Id.
        /// </param>
        /// <param name='invoiceSectionName'>
        /// InvoiceSection Id.
        /// </param>
        /// <param name='billingSubscriptionName'>
        /// Billing Subscription Id.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<BillingSubscription>> GetWithHttpMessagesAsync(string billingAccountName, string billingProfileName, string invoiceSectionName, string billingSubscriptionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Transfers the subscription from one invoice section to another
        /// within a billing account.
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='billingProfileName'>
        /// Billing Profile Id.
        /// </param>
        /// <param name='invoiceSectionName'>
        /// InvoiceSection Id.
        /// </param>
        /// <param name='billingSubscriptionName'>
        /// Billing Subscription Id.
        /// </param>
        /// <param name='parameters'>
        /// Request parameters supplied to the Transfer Billing Subscription
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<TransferBillingSubscriptionResult,BillingSubscriptionsTransferHeaders>> TransferWithHttpMessagesAsync(string billingAccountName, string billingProfileName, string invoiceSectionName, string billingSubscriptionName, TransferBillingSubscriptionRequestProperties parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Validates the transfer of billing subscriptions across invoice
        /// sections.
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='billingProfileName'>
        /// Billing Profile Id.
        /// </param>
        /// <param name='invoiceSectionName'>
        /// InvoiceSection Id.
        /// </param>
        /// <param name='billingSubscriptionName'>
        /// Billing Subscription Id.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Transfer Billing Subscription operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ValidateSubscriptionTransferEligibilityResult>> ValidateTransferWithHttpMessagesAsync(string billingAccountName, string billingProfileName, string invoiceSectionName, string billingSubscriptionName, TransferBillingSubscriptionRequestProperties parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Transfers the subscription from one invoice section to another
        /// within a billing account.
        /// </summary>
        /// <param name='billingAccountName'>
        /// billing Account Id.
        /// </param>
        /// <param name='billingProfileName'>
        /// Billing Profile Id.
        /// </param>
        /// <param name='invoiceSectionName'>
        /// InvoiceSection Id.
        /// </param>
        /// <param name='billingSubscriptionName'>
        /// Billing Subscription Id.
        /// </param>
        /// <param name='parameters'>
        /// Request parameters supplied to the Transfer Billing Subscription
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<TransferBillingSubscriptionResult,BillingSubscriptionsTransferHeaders>> BeginTransferWithHttpMessagesAsync(string billingAccountName, string billingProfileName, string invoiceSectionName, string billingSubscriptionName, TransferBillingSubscriptionRequestProperties parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists billing subscription by customer id.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/consumption/" />
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByCustomerNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists billing subscriptions by billing account name.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/billing/" />
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<BillingSubscription>>> ListByBillingAccountNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
