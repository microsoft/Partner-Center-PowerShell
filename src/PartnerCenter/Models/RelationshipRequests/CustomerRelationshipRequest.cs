// -----------------------------------------------------------------------
// <copyright file="CustomerRelationshipRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.RelationshipRequests
{
    using System;

    /// <summary>
    /// Represents a customer relationship request with a partner.
    /// </summary>
    public sealed class CustomerRelationshipRequest : ResourceBase
    {
        /// <summary>
        /// Gets or sets the URL to be used by the customer to establish a relationship with a partner.
        /// </summary>
        public Uri Url { get; set; }
    }
}
