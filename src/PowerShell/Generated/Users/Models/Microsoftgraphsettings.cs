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
    /// settings
    /// </summary>
    public partial class Microsoftgraphsettings
    {
        /// <summary>
        /// Initializes a new instance of the Microsoftgraphsettings class.
        /// </summary>
        public Microsoftgraphsettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Microsoftgraphsettings class.
        /// </summary>
        public Microsoftgraphsettings(bool? hasLicense = default(bool?), bool? hasOptedOut = default(bool?), bool? hasGraphMailbox = default(bool?))
        {
            HasLicense = hasLicense;
            HasOptedOut = hasOptedOut;
            HasGraphMailbox = hasGraphMailbox;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasLicense")]
        public bool? HasLicense { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasOptedOut")]
        public bool? HasOptedOut { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasGraphMailbox")]
        public bool? HasGraphMailbox { get; set; }

    }
}
