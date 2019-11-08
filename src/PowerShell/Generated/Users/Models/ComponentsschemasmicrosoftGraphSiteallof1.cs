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
    /// site
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphSiteallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphSiteallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphSiteallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphSiteallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphSiteallof1(string displayName = default(string), object root = default(object), MicrosoftgraphsharepointIds sharepointIds = default(MicrosoftgraphsharepointIds), MicrosoftgraphsiteCollection siteCollection = default(MicrosoftgraphsiteCollection), MicrosoftgraphitemAnalytics analytics = default(MicrosoftgraphitemAnalytics), IList<MicrosoftgraphcolumnDefinition> columns = default(IList<MicrosoftgraphcolumnDefinition>), IList<MicrosoftgraphcontentType> contentTypes = default(IList<MicrosoftgraphcontentType>), Microsoftgraphdrive drive = default(Microsoftgraphdrive), IList<Microsoftgraphdrive> drives = default(IList<Microsoftgraphdrive>), IList<MicrosoftgraphbaseItem> items = default(IList<MicrosoftgraphbaseItem>), IList<Microsoftgraphlist> lists = default(IList<Microsoftgraphlist>), IList<MicrosoftgraphsitePage> pages = default(IList<MicrosoftgraphsitePage>), IList<Microsoftgraphsite> sites = default(IList<Microsoftgraphsite>), Microsoftgraphonenote onenote = default(Microsoftgraphonenote))
        {
            DisplayName = displayName;
            Root = root;
            SharepointIds = sharepointIds;
            SiteCollection = siteCollection;
            Analytics = analytics;
            Columns = columns;
            ContentTypes = contentTypes;
            Drive = drive;
            Drives = drives;
            Items = items;
            Lists = lists;
            Pages = pages;
            Sites = sites;
            Onenote = onenote;
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
        [JsonProperty(PropertyName = "root")]
        public object Root { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sharepointIds")]
        public MicrosoftgraphsharepointIds SharepointIds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "siteCollection")]
        public MicrosoftgraphsiteCollection SiteCollection { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "analytics")]
        public MicrosoftgraphitemAnalytics Analytics { get; set; }

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
        [JsonProperty(PropertyName = "drives")]
        public IList<Microsoftgraphdrive> Drives { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<MicrosoftgraphbaseItem> Items { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lists")]
        public IList<Microsoftgraphlist> Lists { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pages")]
        public IList<MicrosoftgraphsitePage> Pages { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sites")]
        public IList<Microsoftgraphsite> Sites { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "onenote")]
        public Microsoftgraphonenote Onenote { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Analytics != null)
            {
                Analytics.Validate();
            }
            if (Columns != null)
            {
                foreach (var element in Columns)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (ContentTypes != null)
            {
                foreach (var element1 in ContentTypes)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
            if (Drive != null)
            {
                Drive.Validate();
            }
            if (Drives != null)
            {
                foreach (var element2 in Drives)
                {
                    if (element2 != null)
                    {
                        element2.Validate();
                    }
                }
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
            if (Lists != null)
            {
                foreach (var element4 in Lists)
                {
                    if (element4 != null)
                    {
                        element4.Validate();
                    }
                }
            }
            if (Pages != null)
            {
                foreach (var element5 in Pages)
                {
                    if (element5 != null)
                    {
                        element5.Validate();
                    }
                }
            }
            if (Sites != null)
            {
                foreach (var element6 in Sites)
                {
                    if (element6 != null)
                    {
                        element6.Validate();
                    }
                }
            }
        }
    }
}
