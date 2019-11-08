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

    public partial class MicrosoftgraphsecurityBaselineSettingState
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphsecurityBaselineSettingState class.
        /// </summary>
        public MicrosoftgraphsecurityBaselineSettingState()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphsecurityBaselineSettingState class.
        /// </summary>
        /// <param name="settingName">The setting name that is being
        /// reported</param>
        /// <param name="state">Possible values include: 'unknown', 'secure',
        /// 'notApplicable', 'notSecure', 'error', 'conflict'</param>
        /// <param name="settingCategoryId">The setting category id which this
        /// setting belongs to</param>
        public MicrosoftgraphsecurityBaselineSettingState(string id = default(string), string settingName = default(string), string state = default(string), string settingCategoryId = default(string))
        {
            Id = id;
            SettingName = settingName;
            State = state;
            SettingCategoryId = settingCategoryId;
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
        /// Gets or sets the setting name that is being reported
        /// </summary>
        [JsonProperty(PropertyName = "settingName")]
        public string SettingName { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'unknown', 'secure',
        /// 'notApplicable', 'notSecure', 'error', 'conflict'
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the setting category id which this setting belongs to
        /// </summary>
        [JsonProperty(PropertyName = "settingCategoryId")]
        public string SettingCategoryId { get; set; }

    }
}
