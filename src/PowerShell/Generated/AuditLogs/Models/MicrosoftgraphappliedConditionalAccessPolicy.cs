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
    /// appliedConditionalAccessPolicy
    /// </summary>
    public partial class MicrosoftgraphappliedConditionalAccessPolicy
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphappliedConditionalAccessPolicy class.
        /// </summary>
        public MicrosoftgraphappliedConditionalAccessPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftgraphappliedConditionalAccessPolicy class.
        /// </summary>
        /// <param name="conditionsSatisfied">Possible values include: 'none',
        /// 'application', 'users', 'devicePlatform', 'location', 'clientType',
        /// 'signInRisk', 'userRisk', 'time', 'deviceState', 'client'</param>
        /// <param name="conditionsNotSatisfied">Possible values include:
        /// 'none', 'application', 'users', 'devicePlatform', 'location',
        /// 'clientType', 'signInRisk', 'userRisk', 'time', 'deviceState',
        /// 'client'</param>
        /// <param name="result">Possible values include: 'success', 'failure',
        /// 'notApplied', 'notEnabled', 'unknown', 'unknownFutureValue',
        /// 'reportOnlySuccess', 'reportOnlyFailure', 'reportOnlyNotApplied',
        /// 'reportOnlyInterrupted'</param>
        public MicrosoftgraphappliedConditionalAccessPolicy(string id = default(string), string displayName = default(string), IList<string> enforcedGrantControls = default(IList<string>), IList<string> enforcedSessionControls = default(IList<string>), string conditionsSatisfied = default(string), string conditionsNotSatisfied = default(string), string result = default(string))
        {
            Id = id;
            DisplayName = displayName;
            EnforcedGrantControls = enforcedGrantControls;
            EnforcedSessionControls = enforcedSessionControls;
            ConditionsSatisfied = conditionsSatisfied;
            ConditionsNotSatisfied = conditionsNotSatisfied;
            Result = result;
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
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "enforcedGrantControls")]
        public IList<string> EnforcedGrantControls { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "enforcedSessionControls")]
        public IList<string> EnforcedSessionControls { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'none', 'application',
        /// 'users', 'devicePlatform', 'location', 'clientType', 'signInRisk',
        /// 'userRisk', 'time', 'deviceState', 'client'
        /// </summary>
        [JsonProperty(PropertyName = "conditionsSatisfied")]
        public string ConditionsSatisfied { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'none', 'application',
        /// 'users', 'devicePlatform', 'location', 'clientType', 'signInRisk',
        /// 'userRisk', 'time', 'deviceState', 'client'
        /// </summary>
        [JsonProperty(PropertyName = "conditionsNotSatisfied")]
        public string ConditionsNotSatisfied { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'success', 'failure',
        /// 'notApplied', 'notEnabled', 'unknown', 'unknownFutureValue',
        /// 'reportOnlySuccess', 'reportOnlyFailure', 'reportOnlyNotApplied',
        /// 'reportOnlyInterrupted'
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

    }
}
