// -----------------------------------------------------------------------
// <copyright file="SupportTopic.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    /// <summary>
    /// Represents a service request support topic.
    /// </summary>
    public sealed class SupportTopic : ResourceBase
    {   
        /// <summary>
        /// Gets or sets the description of the support topic.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the support topic.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the support topic.
        /// </summary>
        public string Name { get; set; }
    }
}