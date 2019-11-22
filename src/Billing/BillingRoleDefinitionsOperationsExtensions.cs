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
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Extension methods for BillingRoleDefinitionsOperations.
    /// </summary>
    public static partial class BillingRoleDefinitionsOperationsExtensions
    {
            /// <summary>
            /// Gets the role definition for a role
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingRoleDefinitionName'>
            /// role definition id.
            /// </param>
            public static BillingRoleDefinition GetByBillingAccount(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingRoleDefinitionName)
            {
                return operations.GetByBillingAccountAsync(billingAccountName, billingRoleDefinitionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the role definition for a role
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingRoleDefinitionName'>
            /// role definition id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BillingRoleDefinition> GetByBillingAccountAsync(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingRoleDefinitionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByBillingAccountWithHttpMessagesAsync(billingAccountName, billingRoleDefinitionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the role definition for a role
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='invoiceSectionName'>
            /// InvoiceSection Id.
            /// </param>
            /// <param name='billingRoleDefinitionName'>
            /// role definition id.
            /// </param>
            public static BillingRoleDefinition GetByInvoiceSection(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, string invoiceSectionName, string billingRoleDefinitionName)
            {
                return operations.GetByInvoiceSectionAsync(billingAccountName, billingProfileName, invoiceSectionName, billingRoleDefinitionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the role definition for a role
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='invoiceSectionName'>
            /// InvoiceSection Id.
            /// </param>
            /// <param name='billingRoleDefinitionName'>
            /// role definition id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BillingRoleDefinition> GetByInvoiceSectionAsync(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, string invoiceSectionName, string billingRoleDefinitionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByInvoiceSectionWithHttpMessagesAsync(billingAccountName, billingProfileName, invoiceSectionName, billingRoleDefinitionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the role definition for a role
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='billingRoleDefinitionName'>
            /// role definition id.
            /// </param>
            public static BillingRoleDefinition GetByBillingProfile(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, string billingRoleDefinitionName)
            {
                return operations.GetByBillingProfileAsync(billingAccountName, billingProfileName, billingRoleDefinitionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the role definition for a role
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='billingRoleDefinitionName'>
            /// role definition id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BillingRoleDefinition> GetByBillingProfileAsync(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, string billingRoleDefinitionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByBillingProfileWithHttpMessagesAsync(billingAccountName, billingProfileName, billingRoleDefinitionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the role definition for a billing account
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            public static BillingRoleDefinitionListResult ListByBillingAccount(this IBillingRoleDefinitionsOperations operations, string billingAccountName)
            {
                return operations.ListByBillingAccountAsync(billingAccountName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the role definition for a billing account
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BillingRoleDefinitionListResult> ListByBillingAccountAsync(this IBillingRoleDefinitionsOperations operations, string billingAccountName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByBillingAccountWithHttpMessagesAsync(billingAccountName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the role definition for an invoice Section
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='invoiceSectionName'>
            /// InvoiceSection Id.
            /// </param>
            public static BillingRoleDefinitionListResult ListByInvoiceSection(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, string invoiceSectionName)
            {
                return operations.ListByInvoiceSectionAsync(billingAccountName, billingProfileName, invoiceSectionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the role definition for an invoice Section
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='invoiceSectionName'>
            /// InvoiceSection Id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BillingRoleDefinitionListResult> ListByInvoiceSectionAsync(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, string invoiceSectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByInvoiceSectionWithHttpMessagesAsync(billingAccountName, billingProfileName, invoiceSectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the role definition for a Billing Profile
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            public static BillingRoleDefinitionListResult ListByBillingProfile(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName)
            {
                return operations.ListByBillingProfileAsync(billingAccountName, billingProfileName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the role definition for a Billing Profile
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='billingAccountName'>
            /// billing Account Id.
            /// </param>
            /// <param name='billingProfileName'>
            /// Billing Profile Id.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BillingRoleDefinitionListResult> ListByBillingProfileAsync(this IBillingRoleDefinitionsOperations operations, string billingAccountName, string billingProfileName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByBillingProfileWithHttpMessagesAsync(billingAccountName, billingProfileName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
