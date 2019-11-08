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
    /// recipient
    /// </summary>
    public partial class Microsoftgraphrecipient
    {
        /// <summary>
        /// Initializes a new instance of the Microsoftgraphrecipient class.
        /// </summary>
        public Microsoftgraphrecipient()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Microsoftgraphrecipient class.
        /// </summary>
        public Microsoftgraphrecipient(MicrosoftgraphemailAddress emailAddress = default(MicrosoftgraphemailAddress))
        {
            EmailAddress = emailAddress;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailAddress")]
        public MicrosoftgraphemailAddress EmailAddress { get; set; }

    }
}
