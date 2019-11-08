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
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// onenoteEntityHierarchyModel
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphOnenoteentityhierarchymodelallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphOnenoteentityhierarchymodelallof1
        /// class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphOnenoteentityhierarchymodelallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphOnenoteentityhierarchymodelallof1
        /// class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphOnenoteentityhierarchymodelallof1(string displayName = default(string), MicrosoftgraphidentitySet createdBy = default(MicrosoftgraphidentitySet), MicrosoftgraphidentitySet lastModifiedBy = default(MicrosoftgraphidentitySet), System.DateTime? lastModifiedDateTime = default(System.DateTime?))
        {
            DisplayName = displayName;
            CreatedBy = createdBy;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdBy")]
        public MicrosoftgraphidentitySet CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedBy")]
        public MicrosoftgraphidentitySet LastModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

    }
}
