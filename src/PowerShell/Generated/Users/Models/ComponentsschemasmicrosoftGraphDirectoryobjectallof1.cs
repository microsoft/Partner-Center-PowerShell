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
    /// directoryObject
    /// </summary>
    /// <remarks>
    /// Represents an Azure Active Directory object. The directoryObject type
    /// is the base type for many other directory entity types.
    /// </remarks>
    public partial class ComponentsschemasmicrosoftGraphDirectoryobjectallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphDirectoryobjectallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphDirectoryobjectallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphDirectoryobjectallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphDirectoryobjectallof1(System.DateTime? deletedDateTime = default(System.DateTime?))
        {
            DeletedDateTime = deletedDateTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deletedDateTime")]
        public System.DateTime? DeletedDateTime { get; set; }

    }
}
