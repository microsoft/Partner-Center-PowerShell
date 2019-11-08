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

    public partial class MicrosoftgraphbaseItem
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphbaseItem class.
        /// </summary>
        public MicrosoftgraphbaseItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphbaseItem class.
        /// </summary>
        public MicrosoftgraphbaseItem(string id = default(string), MicrosoftgraphidentitySet createdBy = default(MicrosoftgraphidentitySet), System.DateTime? createdDateTime = default(System.DateTime?), string description = default(string), string eTag = default(string), MicrosoftgraphidentitySet lastModifiedBy = default(MicrosoftgraphidentitySet), System.DateTime? lastModifiedDateTime = default(System.DateTime?), string name = default(string), MicrosoftgraphitemReference parentReference = default(MicrosoftgraphitemReference), string webUrl = default(string), Microsoftgraphuser createdByUser = default(Microsoftgraphuser), Microsoftgraphuser lastModifiedByUser = default(Microsoftgraphuser))
        {
            Id = id;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            Description = description;
            ETag = eTag;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            Name = name;
            ParentReference = parentReference;
            WebUrl = webUrl;
            CreatedByUser = createdByUser;
            LastModifiedByUser = lastModifiedByUser;
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
        [JsonProperty(PropertyName = "createdBy")]
        public MicrosoftgraphidentitySet CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "eTag")]
        public string ETag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedBy")]
        public MicrosoftgraphidentitySet LastModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parentReference")]
        public MicrosoftgraphitemReference ParentReference { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdByUser")]
        public Microsoftgraphuser CreatedByUser { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedByUser")]
        public Microsoftgraphuser LastModifiedByUser { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (CreatedByUser != null)
            {
                CreatedByUser.Validate();
            }
            if (LastModifiedByUser != null)
            {
                LastModifiedByUser.Validate();
            }
        }
    }
}
