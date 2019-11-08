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
    /// list
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphListallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphListallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphListallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphListallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphListallof1(string displayName = default(string), MicrosoftgraphlistInfo list = default(MicrosoftgraphlistInfo), MicrosoftgraphsharepointIds sharepointIds = default(MicrosoftgraphsharepointIds), object system = default(object), IList<MicrosoftgraphitemActivityOLD> activities = default(IList<MicrosoftgraphitemActivityOLD>), IList<MicrosoftgraphcolumnDefinition> columns = default(IList<MicrosoftgraphcolumnDefinition>), IList<MicrosoftgraphcontentType> contentTypes = default(IList<MicrosoftgraphcontentType>), Microsoftgraphdrive drive = default(Microsoftgraphdrive), IList<MicrosoftgraphlistItem> items = default(IList<MicrosoftgraphlistItem>), IList<Microsoftgraphsubscription> subscriptions = default(IList<Microsoftgraphsubscription>))
        {
            DisplayName = displayName;
            List = list;
            SharepointIds = sharepointIds;
            System = system;
            Activities = activities;
            Columns = columns;
            ContentTypes = contentTypes;
            Drive = drive;
            Items = items;
            Subscriptions = subscriptions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public MicrosoftgraphlistInfo List { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sharepointIds")]
        public MicrosoftgraphsharepointIds SharepointIds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "system")]
        public object System { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activities")]
        public IList<MicrosoftgraphitemActivityOLD> Activities { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "columns")]
        public IList<MicrosoftgraphcolumnDefinition> Columns { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contentTypes")]
        public IList<MicrosoftgraphcontentType> ContentTypes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "drive")]
        public Microsoftgraphdrive Drive { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<MicrosoftgraphlistItem> Items { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subscriptions")]
        public IList<Microsoftgraphsubscription> Subscriptions { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Activities != null)
            {
                foreach (var element in Activities)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (Columns != null)
            {
                foreach (var element1 in Columns)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
            if (ContentTypes != null)
            {
                foreach (var element2 in ContentTypes)
                {
                    if (element2 != null)
                    {
                        element2.Validate();
                    }
                }
            }
            if (Drive != null)
            {
                Drive.Validate();
            }
            if (Items != null)
            {
                foreach (var element3 in Items)
                {
                    if (element3 != null)
                    {
                        element3.Validate();
                    }
                }
            }
        }
    }
}
