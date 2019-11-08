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
    /// defaultColumnValue
    /// </summary>
    public partial class MicrosoftgraphdefaultColumnValue
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphdefaultColumnValue
        /// class.
        /// </summary>
        public MicrosoftgraphdefaultColumnValue()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphdefaultColumnValue
        /// class.
        /// </summary>
        public MicrosoftgraphdefaultColumnValue(string formula = default(string), string value = default(string))
        {
            Formula = formula;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "formula")]
        public string Formula { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
