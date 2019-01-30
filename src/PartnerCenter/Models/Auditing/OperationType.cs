// -----------------------------------------------------------------------
// <copyright file="OperationType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Auditing
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Enumeration to represent type of operation being performed.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum OperationType
    {
        /// <summary>
        /// The undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// Update Customer Qualification
        /// </summary>
        UpdateCustomerQualification,

        /// <summary>
        /// Updates an existing subscription.
        /// </summary>
        UpdateSubscription,

        /// <summary>
        /// Transition a subscription.
        /// </summary>
        UpgradeSubscription,

        /// <summary>
        /// Convert a trial subscription to a paid one.
        /// </summary>
        ConvertTrialSubscription,

        /// <summary>Adding a Customer</summary>
        AddCustomer,

        /// <summary>
        /// Update a Customer Billing Profile
        /// </summary>
        UpdateCustomerBillingProfile,

        /// <summary>
        /// Update a Customer's Partner Contract Company Name
        /// </summary>
        UpdateCustomerPartnerContractCompanyName,

        /// <summary>
        /// Updates a customer spending budget.
        /// </summary>
        UpdateCustomerSpendingBudget,

        /// <summary>
        /// Deleting a Customer.
        /// </summary>
        /// <remarks>
        /// Happens only in the sandbox integration accounts.
        /// </remarks>
        DeleteCustomer,

        /// <summary>
        /// Remove Partner Customer relationship.
        /// </summary>
        RemovePartnerCustomerRelationship,

        /// <summary>
        /// Create a new order.
        /// </summary>
        CreateOrder,

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        UpdateOrder,

        /// <summary>
        /// Creates a customer user.
        /// </summary>
        CreateCustomerUser,

        /// <summary>
        /// Deletes a customer user.
        /// </summary>
        DeleteCustomerUser,

        /// <summary>
        /// Updates a customer user.
        /// </summary>
        UpdateCustomerUser,

        /// <summary>
        /// Updates a customer user licenses.
        /// </summary>
        UpdateCustomerUserLicenses,

        /// <summary>
        /// Reset customer user password.
        /// </summary>
        ResetCustomerUserPassword,

        /// <summary>
        /// Update customer user UPN.
        /// </summary>
        UpdateCustomerUserPrincipalName,

        /// <summary>
        /// Restore customer user.
        /// </summary>
        RestoreCustomerUser,

        /// <summary>
        /// Create MPN association.
        /// </summary>
        CreateMpnAssociation,

        /// <summary>U
        /// pdate MPN association.
        /// </summary>
        UpdateMpnAssociation,

        /// <summary>
        /// Updates a Sfb customer user licenses.
        /// </summary>
        UpdateSfbCustomerUserLicenses,

        /// <summary>
        /// Update transfer.
        /// </summary>
        UpdateTransfer,

        /// <summary>
        /// Creates a partner relationship.
        /// </summary>
        CreatePartnerRelationship,

        /// <summary>
        /// Add and registers an application.
        /// </summary>
        RegisterApplication,

        /// <summary>
        /// Unregisters an application.
        /// </summary>
        UnregisterApplication,

        /// <summary>
        /// Adds an application credential.
        /// </summary>
        AddApplicationCredential,

        /// <summary>
        /// Adds an application credential.
        /// </summary>
        RemoveApplicationCredential,

        /// <summary>
        /// Creates a partner user.
        /// </summary>
        CreatePartnerUser,

        /// <summary>
        /// Updates a partner user.
        /// </summary>
        UpdatePartnerUser,

        /// <summary>
        /// Removes a partner user.
        /// </summary>
        RemovePartnerUser
    }
}