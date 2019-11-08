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
    /// itemActivityStat
    /// </summary>
    public partial class ComponentsschemasmicrosoftGraphItemactivitystatallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphItemactivitystatallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphItemactivitystatallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphItemactivitystatallof1 class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphItemactivitystatallof1(System.DateTime? startDateTime = default(System.DateTime?), System.DateTime? endDateTime = default(System.DateTime?), MicrosoftgraphitemActionStat access = default(MicrosoftgraphitemActionStat), MicrosoftgraphitemActionStat create = default(MicrosoftgraphitemActionStat), MicrosoftgraphitemActionStat delete = default(MicrosoftgraphitemActionStat), MicrosoftgraphitemActionStat edit = default(MicrosoftgraphitemActionStat), MicrosoftgraphitemActionStat move = default(MicrosoftgraphitemActionStat), bool? isTrending = default(bool?), MicrosoftgraphincompleteData incompleteData = default(MicrosoftgraphincompleteData), IList<MicrosoftgraphitemActivity> activities = default(IList<MicrosoftgraphitemActivity>))
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Access = access;
            Create = create;
            Delete = delete;
            Edit = edit;
            Move = move;
            IsTrending = isTrending;
            IncompleteData = incompleteData;
            Activities = activities;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "startDateTime")]
        public System.DateTime? StartDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endDateTime")]
        public System.DateTime? EndDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "access")]
        public MicrosoftgraphitemActionStat Access { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "create")]
        public MicrosoftgraphitemActionStat Create { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delete")]
        public MicrosoftgraphitemActionStat Delete { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "edit")]
        public MicrosoftgraphitemActionStat Edit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "move")]
        public MicrosoftgraphitemActionStat Move { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isTrending")]
        public bool? IsTrending { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incompleteData")]
        public MicrosoftgraphincompleteData IncompleteData { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activities")]
        public IList<MicrosoftgraphitemActivity> Activities { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Access != null)
            {
                Access.Validate();
            }
            if (Create != null)
            {
                Create.Validate();
            }
            if (Delete != null)
            {
                Delete.Validate();
            }
            if (Edit != null)
            {
                Edit.Validate();
            }
            if (Move != null)
            {
                Move.Validate();
            }
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
        }
    }
}
