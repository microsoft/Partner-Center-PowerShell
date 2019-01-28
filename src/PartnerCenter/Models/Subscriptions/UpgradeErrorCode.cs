// -----------------------------------------------------------------------
// <copyright file="UpgradeErrorCode.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// The type of errors that prevent subscription upgrading from happening.
    /// </summary>
    public enum UpgradeErrorCode
    {
        /// <summary>General error.</summary>
        Other,

        /// <summary>
        /// Upgrade cannot be performed because administrative permissions have been removed.
        /// </summary>
        DelegatedAdminPermissionsDisabled,

        /// <summary>
        /// Upgrade cannot be performed because the subscription status is suspended or deleted.
        /// </summary>
        SubscriptionStatusNotActive,

        /// <summary>
        /// Upgrade cannot be performed because of conflicting source service types.
        /// </summary>
        ConflictingServiceTypes,

        /// <summary>
        /// Upgrade cannot be performed due to concurrent subscription restrictions.
        /// </summary>
        ConcurrencyConflicts,

        /// <summary>
        /// Upgrade cannot be performed because the current request is using app context.
        /// </summary>
        UserContextRequired,

        /// <summary>
        /// Upgrade cannot be performed because the source subscription has previously purchased add-ons.
        /// </summary>
        SubscriptionAddOnsPresent,

        /// <summary>
        /// Upgrade cannot be performed because the source subscription does not have upgrade paths.
        /// </summary>
        SubscriptionDoesNotHaveAnyUpgradePaths,

        /// <summary>
        /// Upgrade cannot be performed because the specified upgrade path is not an available upgrade path.
        /// </summary>
        SubscriptionTargetOfferNotFound,

        /// <summary>
        /// The subscription is not provisioned yet.
        /// Happens when the order is still being processed. Eventually the subscription will be provisioned and an entitlement is created.
        /// </summary>
        SubscriptionNotProvisioned
    }
}