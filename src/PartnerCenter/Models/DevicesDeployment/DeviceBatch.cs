// -----------------------------------------------------------------------
// <copyright file="DeviceBatch.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System;

    /// <summary>
    /// Represents a devices batch associated with a customer.
    /// </summary>
    public sealed class DeviceBatch : StandardResourceLinks
    {
        /// <summary>
        /// Gets or sets the name of the tenant who created the batch.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date the batch was created.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the count of devices in the batch.
        /// </summary>
        public int DevicesCount { get; set; }

        /// <summary>
        /// Gets or sets the link to the devices under the batch.
        /// </summary>
        public Link DevicesLink { get; set; }

        /// <summary>
        /// Gets or sets the devices batch unique identifier.
        /// </summary>
        public string Id { get; set; }
    }
}