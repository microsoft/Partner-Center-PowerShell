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

    /// <summary>
    /// conversationThread
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphConversationthreadallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphConversationthreadallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphConversationthreadallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphConversationthreadallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphConversationthreadallof1(IList<Microsoftgraphrecipient> toRecipients = default(IList<Microsoftgraphrecipient>), string topic = default(string), bool? hasAttachments = default(bool?), System.DateTime? lastDeliveredDateTime = default(System.DateTime?), IList<string> uniqueSenders = default(IList<string>), IList<Microsoftgraphrecipient> ccRecipients = default(IList<Microsoftgraphrecipient>), string preview = default(string), bool? isLocked = default(bool?), IList<Microsoftgraphpost> posts = default(IList<Microsoftgraphpost>))
        {
            ToRecipients = toRecipients;
            Topic = topic;
            HasAttachments = hasAttachments;
            LastDeliveredDateTime = lastDeliveredDateTime;
            UniqueSenders = uniqueSenders;
            CcRecipients = ccRecipients;
            Preview = preview;
            IsLocked = isLocked;
            Posts = posts;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "toRecipients")]
        public IList<Microsoftgraphrecipient> ToRecipients { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "topic")]
        public string Topic { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasAttachments")]
        public bool? HasAttachments { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastDeliveredDateTime")]
        public System.DateTime? LastDeliveredDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "uniqueSenders")]
        public IList<string> UniqueSenders { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ccRecipients")]
        public IList<Microsoftgraphrecipient> CcRecipients { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "preview")]
        public string Preview { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isLocked")]
        public bool? IsLocked { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "posts")]
        public IList<Microsoftgraphpost> Posts { get; set; }

    }
}
