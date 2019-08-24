// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.ServiceRequests
{
    using System.Globalization;
    using Extensions;
    using PartnerCenter.Models.ServiceRequests;

    /// <summary>
    /// Represents a service request.
    /// </summary>
    public sealed class PSSupportTopic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSupportTopic" /> class.
        /// </summary>
        public PSSupportTopic()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSupportTopic" /> class.
        /// </summary>
        /// <param name="topic">The base offer for this instance.</param>
        public PSSupportTopic(SupportTopic topic)
        {
            this.CopyFrom(topic, CloneAdditionalOperations);
        }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="SupportTopic "/> to an instance of <see cref="PSSupportTopic" />. 
        /// </summary>
        /// <param name="topic">The product being cloned.</param>
        private void CloneAdditionalOperations(SupportTopic topic)
        {
            SupportTopicId = topic.Id.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets or sets the support topic Id.
        /// </summary>
        public string SupportTopicId { get; set; }

        /// <summary>
        /// Gets or sets the name of the support topic.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the support topic.
        /// </summary>
        public string Description { get; set; }
    }
}