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

    public partial class MicrosoftgraphchatThread
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphchatThread class.
        /// </summary>
        public MicrosoftgraphchatThread()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphchatThread class.
        /// </summary>
        public MicrosoftgraphchatThread(string id = default(string), MicrosoftgraphchatMessage rootMessage = default(MicrosoftgraphchatMessage))
        {
            Id = id;
            RootMessage = rootMessage;
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
        [JsonProperty(PropertyName = "rootMessage")]
        public MicrosoftgraphchatMessage RootMessage { get; set; }

    }
}
