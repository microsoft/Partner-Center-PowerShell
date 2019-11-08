// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class MicrosoftgraphdeviceEnrollmentConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphdeviceEnrollmentConfiguration class.
        /// </summary>
        public MicrosoftgraphdeviceEnrollmentConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphdeviceEnrollmentConfiguration class.
        /// </summary>
        /// <param name="displayName">The display name of the device enrollment
        /// configuration</param>
        /// <param name="description">The description of the device enrollment
        /// configuration</param>
        /// <param name="priority">Priority is used when a user exists in
        /// multiple groups that are assigned enrollment configuration. Users
        /// are subject only to the configuration with the lowest priority
        /// value.</param>
        /// <param name="createdDateTime">Created date time in UTC of the
        /// device enrollment configuration</param>
        /// <param name="lastModifiedDateTime">Last modified date time in UTC
        /// of the device enrollment configuration</param>
        /// <param name="version">The version of the device enrollment
        /// configuration</param>
        public MicrosoftgraphdeviceEnrollmentConfiguration(string id = default(string), string displayName = default(string), string description = default(string), int? priority = default(int?), System.DateTime? createdDateTime = default(System.DateTime?), System.DateTime? lastModifiedDateTime = default(System.DateTime?), int? version = default(int?), IList<MicrosoftgraphenrollmentConfigurationAssignment> assignments = default(IList<MicrosoftgraphenrollmentConfigurationAssignment>))
        {
            Id = id;
            DisplayName = displayName;
            Description = description;
            Priority = priority;
            CreatedDateTime = createdDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Version = version;
            Assignments = assignments;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the device enrollment
        /// configuration
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the description of the device enrollment configuration
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets priority is used when a user exists in multiple groups
        /// that are assigned enrollment configuration. Users are subject only
        /// to the configuration with the lowest priority value.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets created date time in UTC of the device enrollment
        /// configuration
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets last modified date time in UTC of the device
        /// enrollment configuration
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the version of the device enrollment configuration
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int? Version { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assignments")]
        public IList<MicrosoftgraphenrollmentConfigurationAssignment> Assignments { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Priority > 2147483647)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Priority", 2147483647);
            }
            if (Priority < -2147483648)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Priority", -2147483648);
            }
            if (Version > 2147483647)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Version", 2147483647);
            }
            if (Version < -2147483648)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Version", -2147483648);
            }
        }
    }
}
