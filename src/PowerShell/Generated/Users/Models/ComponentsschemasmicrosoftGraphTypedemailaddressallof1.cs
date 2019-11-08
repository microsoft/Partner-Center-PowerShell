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
    /// typedEmailAddress
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphTypedemailaddressallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphTypedemailaddressallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphTypedemailaddressallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphTypedemailaddressallof1 class.
        /// </summary>
        /// <param name="type">Possible values include: 'unknown', 'work',
        /// 'personal', 'main', 'other'</param>
        public ComponentsschemasmicrosoftGraphTypedemailaddressallof1(string type = default(string), string otherLabel = default(string))
        {
            Type = type;
            OtherLabel = otherLabel;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'unknown', 'work',
        /// 'personal', 'main', 'other'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "otherLabel")]
        public string OtherLabel { get; set; }

    }
}
