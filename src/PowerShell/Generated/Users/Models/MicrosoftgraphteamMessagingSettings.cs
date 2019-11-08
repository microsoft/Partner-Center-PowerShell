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
    /// teamMessagingSettings
    /// </summary>
    public partial class MicrosoftgraphteamMessagingSettings
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphteamMessagingSettings class.
        /// </summary>
        public MicrosoftgraphteamMessagingSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphteamMessagingSettings class.
        /// </summary>
        public MicrosoftgraphteamMessagingSettings(bool? allowUserEditMessages = default(bool?), bool? allowUserDeleteMessages = default(bool?), bool? allowOwnerDeleteMessages = default(bool?), bool? allowTeamMentions = default(bool?), bool? allowChannelMentions = default(bool?))
        {
            AllowUserEditMessages = allowUserEditMessages;
            AllowUserDeleteMessages = allowUserDeleteMessages;
            AllowOwnerDeleteMessages = allowOwnerDeleteMessages;
            AllowTeamMentions = allowTeamMentions;
            AllowChannelMentions = allowChannelMentions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "allowUserEditMessages")]
        public bool? AllowUserEditMessages { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "allowUserDeleteMessages")]
        public bool? AllowUserDeleteMessages { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "allowOwnerDeleteMessages")]
        public bool? AllowOwnerDeleteMessages { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "allowTeamMentions")]
        public bool? AllowTeamMentions { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "allowChannelMentions")]
        public bool? AllowChannelMentions { get; set; }

    }
}
