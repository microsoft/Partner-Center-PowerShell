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

    public partial class MicrosoftgraphuserTeamwork
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphuserTeamwork class.
        /// </summary>
        public MicrosoftgraphuserTeamwork()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftgraphuserTeamwork class.
        /// </summary>
        public MicrosoftgraphuserTeamwork(string id = default(string), IList<MicrosoftgraphteamsAppInstallation> installedApps = default(IList<MicrosoftgraphteamsAppInstallation>))
        {
            Id = id;
            InstalledApps = installedApps;
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
        [JsonProperty(PropertyName = "installedApps")]
        public IList<MicrosoftgraphteamsAppInstallation> InstalledApps { get; set; }

    }
}
