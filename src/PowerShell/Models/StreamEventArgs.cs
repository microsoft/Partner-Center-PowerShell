// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using System;

    /// <summary>
    /// Represents the stream event arguments.
    /// </summary>
    public class StreamEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a flag indiciating whether or not the collection should be enumerated.
        /// </summary>
        public bool EnumerateCollection { get; set; }

        /// <summary>
        /// Gets or sets the resource to be sent to the pipeline.
        /// </summary>
        public object Resource { get; set; }
    }
}