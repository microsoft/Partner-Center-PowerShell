// -----------------------------------------------------------------------
// <copyright file="ConfigurationPolicy.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a configuration policy associated with a customer.
    /// </summary>
    public sealed class ConfigurationPolicy : ResourceBase
    {
        /// <summary>
        /// Gets or sets the category of the policy.
        /// </summary>
        public PolicyCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the date the policy was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the description for a policy.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of devices assigned to a policy.
        /// </summary>
        public int DevicesAssignedCount { get; set; }

        /// <summary>
        /// Gets or sets the policy unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date the policy was modified.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the settings for a policy.
        /// </summary>
        public IEnumerable<PolicySettingsTypes> PolicySettings { get; set; }
    }
}