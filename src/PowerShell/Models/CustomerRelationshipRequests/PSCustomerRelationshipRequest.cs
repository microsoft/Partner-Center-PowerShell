// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerRelationshipRequests
{
    using System;
    using Extensions;
    using PartnerCenter.Models.RelationshipRequests;

    /// <summary>
    /// Represents a customer relationship request with a partner.
    /// </summary>
    public sealed class PSCustomerRelationshipRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerRelationshipRequest" /> class.
        /// </summary>
        public PSCustomerRelationshipRequest()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerRelationshipRequest" /> class.
        /// </summary>
        /// <param name="relationship">The base customer relationship request for this instance.</param>
        public PSCustomerRelationshipRequest(CustomerRelationshipRequest relationship)
        {
            this.CopyFrom(relationship);
        }

        /// <summary>
        /// Gets or sets the URL to be used by the customer to establish a relationship with a partner.
        /// </summary>
        public Uri Url { get; set; }
    }
}