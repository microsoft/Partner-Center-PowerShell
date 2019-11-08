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

    public partial class MicrosoftgraphplannerTaskDetails
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphplannerTaskDetails
        /// class.
        /// </summary>
        public MicrosoftgraphplannerTaskDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphplannerTaskDetails
        /// class.
        /// </summary>
        /// <param name="previewType">Possible values include: 'automatic',
        /// 'noPreview', 'checklist', 'description', 'reference'</param>
        public MicrosoftgraphplannerTaskDetails(string id = default(string), string description = default(string), string previewType = default(string), object references = default(object), object checklist = default(object))
        {
            Id = id;
            Description = description;
            PreviewType = previewType;
            References = references;
            Checklist = checklist;
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
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'automatic', 'noPreview',
        /// 'checklist', 'description', 'reference'
        /// </summary>
        [JsonProperty(PropertyName = "previewType")]
        public string PreviewType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "references")]
        public object References { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "checklist")]
        public object Checklist { get; set; }

    }
}
