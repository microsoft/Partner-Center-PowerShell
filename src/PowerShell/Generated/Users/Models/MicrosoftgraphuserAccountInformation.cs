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

    public partial class MicrosoftgraphuserAccountInformation
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphuserAccountInformation class.
        /// </summary>
        public MicrosoftgraphuserAccountInformation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphuserAccountInformation class.
        /// </summary>
        /// <param name="allowedAudiences">Possible values include: 'me',
        /// 'family', 'contacts', 'groupMembers', 'organization',
        /// 'federatedOrganizations', 'everyone', 'unknownFutureValue'</param>
        public MicrosoftgraphuserAccountInformation(string id = default(string), string allowedAudiences = default(string), MicrosoftgraphinferenceData inference = default(MicrosoftgraphinferenceData), System.DateTime? createdDateTime = default(System.DateTime?), MicrosoftgraphidentitySet createdBy = default(MicrosoftgraphidentitySet), System.DateTime? lastModifiedDateTime = default(System.DateTime?), MicrosoftgraphidentitySet lastModifiedBy = default(MicrosoftgraphidentitySet), string ageGroup = default(string), string countryCode = default(string), MicrosoftgraphlocaleInfo preferredLanguageTag = default(MicrosoftgraphlocaleInfo), string userPrincipalName = default(string))
        {
            Id = id;
            AllowedAudiences = allowedAudiences;
            Inference = inference;
            CreatedDateTime = createdDateTime;
            CreatedBy = createdBy;
            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedBy = lastModifiedBy;
            AgeGroup = ageGroup;
            CountryCode = countryCode;
            PreferredLanguageTag = preferredLanguageTag;
            UserPrincipalName = userPrincipalName;
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
        /// Gets or sets possible values include: 'me', 'family', 'contacts',
        /// 'groupMembers', 'organization', 'federatedOrganizations',
        /// 'everyone', 'unknownFutureValue'
        /// </summary>
        [JsonProperty(PropertyName = "allowedAudiences")]
        public string AllowedAudiences { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inference")]
        public MicrosoftgraphinferenceData Inference { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdBy")]
        public MicrosoftgraphidentitySet CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedBy")]
        public MicrosoftgraphidentitySet LastModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ageGroup")]
        public string AgeGroup { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "preferredLanguageTag")]
        public MicrosoftgraphlocaleInfo PreferredLanguageTag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userPrincipalName")]
        public string UserPrincipalName { get; set; }

    }
}
