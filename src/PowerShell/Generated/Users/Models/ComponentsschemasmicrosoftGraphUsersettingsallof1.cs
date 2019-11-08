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
    /// userSettings
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphUsersettingsallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphUsersettingsallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphUsersettingsallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphUsersettingsallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphUsersettingsallof1(bool? contributionToContentDiscoveryDisabled = default(bool?), bool? contributionToContentDiscoveryAsOrganizationDisabled = default(bool?))
        {
            ContributionToContentDiscoveryDisabled = contributionToContentDiscoveryDisabled;
            ContributionToContentDiscoveryAsOrganizationDisabled = contributionToContentDiscoveryAsOrganizationDisabled;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contributionToContentDiscoveryDisabled")]
        public bool? ContributionToContentDiscoveryDisabled { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contributionToContentDiscoveryAsOrganizationDisabled")]
        public bool? ContributionToContentDiscoveryAsOrganizationDisabled { get; set; }

    }
}
