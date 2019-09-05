// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.DevicesDeployment;

    public sealed class PSConfigurationPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSConfigurationPolicy" /> class.
        /// </summary>
        public PSConfigurationPolicy()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSConfigurationPolicy" /> class.
        /// </summary>
        /// <param name="configurationPolicy">The base configuration policy for this instance.</param>
        public PSConfigurationPolicy(ConfigurationPolicy configurationPolicy)
        {
            this.CopyFrom(configurationPolicy, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the category of the policy.
        /// </summary>
        public PolicyCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the date the policy was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the description for the policy.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of devices assigned to the policy.
        /// </summary>
        public int DevicesAssignedCount { get; set; }

        /// <summary>
        /// Gets or sets the date the policy was modified.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy unique identifier.
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets the settings for a policy.
        /// </summary>
        public IEnumerable<PolicySettingsTypes> PolicySettings { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="ConfigurationPolicy" /> to an instance of <see cref="PSConfigurationPolicy" />. 
        /// </summary>
        /// <param name="item">The item being cloned.</param>
        private void CloneAdditionalOperations(ConfigurationPolicy item)
        {
            PolicyId = item.Id;
        }
    }
}