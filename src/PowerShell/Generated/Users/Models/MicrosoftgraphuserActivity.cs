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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class MicrosoftgraphuserActivity
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphuserActivity class.
        /// </summary>
        public MicrosoftgraphuserActivity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphuserActivity class.
        /// </summary>
        /// <param name="status">Possible values include: 'active', 'updated',
        /// 'deleted', 'ignored', 'unknownFutureValue'</param>
        public MicrosoftgraphuserActivity(string id = default(string), MicrosoftgraphvisualInfo visualElements = default(MicrosoftgraphvisualInfo), string activitySourceHost = default(string), string activationUrl = default(string), string appActivityId = default(string), string appDisplayName = default(string), string contentUrl = default(string), System.DateTime? createdDateTime = default(System.DateTime?), System.DateTime? expirationDateTime = default(System.DateTime?), string fallbackUrl = default(string), System.DateTime? lastModifiedDateTime = default(System.DateTime?), string userTimezone = default(string), object contentInfo = default(object), string status = default(string), IList<MicrosoftgraphactivityHistoryItem> historyItems = default(IList<MicrosoftgraphactivityHistoryItem>))
        {
            Id = id;
            VisualElements = visualElements;
            ActivitySourceHost = activitySourceHost;
            ActivationUrl = activationUrl;
            AppActivityId = appActivityId;
            AppDisplayName = appDisplayName;
            ContentUrl = contentUrl;
            CreatedDateTime = createdDateTime;
            ExpirationDateTime = expirationDateTime;
            FallbackUrl = fallbackUrl;
            LastModifiedDateTime = lastModifiedDateTime;
            UserTimezone = userTimezone;
            ContentInfo = contentInfo;
            Status = status;
            HistoryItems = historyItems;
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
        [JsonProperty(PropertyName = "visualElements")]
        public MicrosoftgraphvisualInfo VisualElements { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activitySourceHost")]
        public string ActivitySourceHost { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activationUrl")]
        public string ActivationUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "appActivityId")]
        public string AppActivityId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "appDisplayName")]
        public string AppDisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contentUrl")]
        public string ContentUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public System.DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "expirationDateTime")]
        public System.DateTime? ExpirationDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fallbackUrl")]
        public string FallbackUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedDateTime")]
        public System.DateTime? LastModifiedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userTimezone")]
        public string UserTimezone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contentInfo")]
        public object ContentInfo { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'active', 'updated',
        /// 'deleted', 'ignored', 'unknownFutureValue'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "historyItems")]
        public IList<MicrosoftgraphactivityHistoryItem> HistoryItems { get; set; }

    }
}
