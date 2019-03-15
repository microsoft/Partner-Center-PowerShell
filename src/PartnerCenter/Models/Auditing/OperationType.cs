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
        Undefined = 0,

        /// <summary>
        /// Update Customer Qualification
        /// </summary>
        UpdateCustomerQualification = 1,

        /// <summary>
        /// Updates an existing subscription.
        /// </summary>
        UpdateSubscription = 2,

        /// <summary>
        /// Transition a subscription.
        /// </summary>
        UpgradeSubscription = 3,

        /// <summary>
        /// Convert a trial subscription to a paid one.
        /// </summary>
        ConvertTrialSubscription = 4,

        /// <summary>
        /// Adding a Customer
        /// </summary>
        AddCustomer = 5,

        /// <summary>
        /// Update a Customer Billing Profile
        /// </summary>
        UpdateCustomerBillingProfile = 6,

        /// <summary>
        /// Update a Customer's Partner Contract Company Name
        /// </summary>
        UpdateCustomerPartnerContractCompanyName = 7,

        /// <summary>
        /// Updates a customer spending budget.
        /// </summary>
        UpdateCustomerSpendingBudget = 8,

        /// <summary>
        /// Deleting a Customer.
        /// Happens only in the sandbox integration accounts.
        /// </summary>
        DeleteCustomer = 9,

        /// <summary>
        /// Remove Partner Customer relationship.
        /// </summary>
        RemovePartnerCustomerRelationship = 10,

        /// <summary>
        /// Create a new order.
        /// </summary>
        CreateOrder = 11,

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        UpdateOrder = 12,

        /// <summary>
        /// Creates a customer user.
        /// </summary>
        CreateCustomerUser = 13,

        /// <summary>
        /// Deletes a customer user.
        /// </summary>
        DeleteCustomerUser = 14,

        /// <summary>
        /// Updates a customer user.
        /// </summary>
        UpdateCustomerUser = 15,

        /// <summary>
        /// Updates a customer user licenses.
        /// </summary>
        UpdateCustomerUserLicenses = 16,

        /// <summary>
        /// Reset customer user password.
        /// </summary>
        ResetCustomerUserPassword = 17,

        /// <summary>
        /// Update customer user UPN.
        /// </summary>
        UpdateCustomerUserPrincipalName = 18,

        /// <summary>
        /// Restore customer user.
        /// </summary>
        RestoreCustomerUser = 19,

        /// <summary>
        /// Create MPN association.
        /// </summary>
        CreateMpnAssociation = 20,

        /// <summary>
        /// Update MPN association.
        /// </summary>
        UpdateMpnAssociation = 21,

        /// <summary>
        /// Updates a Sfb customer user licenses.
        /// </summary>
        UpdateSfbCustomerUserLicenses = 22,

        /// <summary>
        /// Update transfer.
        /// </summary>
        UpdateTransfer = 23,

        /// <summary>
        /// Creates a partner relationship.
        /// </summary>
        CreatePartnerRelationship = 24,

        /// <summary>
        /// Add and registers an application.
        /// </summary>
        RegisterApplication = 25,

        /// <summary>
        /// Unregisters an application.
        /// </summary>
        UnregisterApplication = 26,

        /// <summary>
        /// Adds an application credential.
        /// </summary>
        AddApplicationCredential = 27,

        /// <summary>
        /// Adds an application credential.
        /// </summary>
        RemoveApplicationCredential = 28,

        /// <summary>
        /// Creates a partner user.
        /// </summary>
        CreatePartnerUser = 29,

        /// <summary>
        /// Updates a partner user.
        /// </summary>
        UpdatePartnerUser = 30,

        /// <summary>
        /// Removes a partner user.
        /// </summary>
        RemovePartnerUser = 31,

        /// <summary>
        /// Create a referral
        /// </summary>
        CreateReferral = 32,

        /// <summary>
        /// Update a referral
        /// </summary>
        UpdateReferral = 33,

        /// <summary>
        /// Get software key
        /// </summary>
        GetSoftwareKey = 34,

        /// <summary>
        /// Get software download link
        /// </summary>
        GetSoftwareDownloadLink = 35,

        /// <summary>
        /// Increase credit limit
        /// </summary>
        IncreaseCreditLimit = 36,

        /// <summary>
        /// Create invoice
        /// </summary>
        CreateInvoice = 37
    }
}