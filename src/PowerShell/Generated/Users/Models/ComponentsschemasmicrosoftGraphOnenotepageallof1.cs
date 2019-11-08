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
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// onenotePage
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphOnenotepageallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphOnenotepageallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphOnenotepageallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphOnenotepageallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphOnenotepageallof1(string title = default(string), string createdByAppId = default(string), MicrosoftgraphpageLinks links = default(MicrosoftgraphpageLinks), string contentUrl = default(string), byte[] content = default(byte[]), System.DateTime? lastModifiedDateTime = default(System.DateTime?), int? level = default(int?), int? order = default(int?), IList<string> userTags = default(IList<string>), MicrosoftgraphonenoteSection parentSection = default(MicrosoftgraphonenoteSection), Microsoftgraphnotebook parentNotebook = default(Microsoftgraphnotebook))
        {
            Title = title;
            CreatedByAppId = createdByAppId;
            Links = links;
            ContentUrl = contentUrl;
            Content = content;
            LastModifiedDateTime = lastModifiedDateTime;
            Level = level;
            Order = order;
            UserTags = userTags;
            ParentSection = parentSection;
            ParentNotebook = parentNotebook;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdByAppId")]
        public string CreatedByAppId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "links")]
        public MicrosoftgraphpageLinks Links { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contentUrl")]
        public string ContentUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "content")]
        public byte[] Content { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public int? Level { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public int? Order { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userTags")]
        public IList<string> UserTags { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parentSection")]
        public MicrosoftgraphonenoteSection ParentSection { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parentNotebook")]
        public Microsoftgraphnotebook ParentNotebook { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Level > 2147483647)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Level", 2147483647);
            }
            if (Level < -2147483648)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Level", -2147483648);
            }
            if (Order > 2147483647)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Order", 2147483647);
            }
            if (Order < -2147483648)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Order", -2147483648);
            }
        }
    }
}
